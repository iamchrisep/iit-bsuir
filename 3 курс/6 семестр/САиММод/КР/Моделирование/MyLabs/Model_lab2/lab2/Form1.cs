using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Linq;


namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton_uniform.Checked = true;
        }

        private double[] randArray;

        private void radioButton_uniform_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_uniform.Checked) return;
            label1.Text = "a = "; textBox1.Text = "0";
            label2.Text = "b = "; textBox2.Text = "1";
            label3.Text = "N = "; textBox3.Text = "10000";
        }

        private void radioButton_gauss_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_gauss.Checked)
            {
                label1.Text = "m = ";
                textBox1.Text = "5";
                label2.Text = "σ = ";
                textBox2.Text = "10";
                label3.Text = "n = ";
                textBox3.Text = "6";
                label4.Text = "N = ";
                textBox4.Text = "10000";
                label4.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBox4.Visible = false;
            }
            
        }

        private void radioButton_exp_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_exp.Checked)
            {
                label1.Text = "λ = "; textBox1.Text = "10";
                label2.Text = "N = "; textBox2.Text = "10000";
                label3.Visible = false;
                textBox3.Visible = false;
            }
            else
            {
                label3.Visible = true;
                textBox3.Visible = true;
            }
            
        }

        private void radioButton_gamma_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_gamma.Checked) return;
            label1.Text = "η = "; textBox1.Text = "2";
            label2.Text = "λ = "; textBox2.Text = "2,5";
            label3.Text = "N = "; textBox3.Text = "10000";
        }

        private void radioButton_triangle_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_triangle.Checked) return;
            label1.Text = "a = "; textBox1.Text = "0";
            label2.Text = "b = "; textBox2.Text = "1";
            label3.Text = "N = "; textBox3.Text = "10000";
        }

        private void radioButton_simpson_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_simpson.Checked) return;
            label1.Text = "a = "; textBox1.Text = "0";
            label2.Text = "b = "; textBox2.Text = "1";
            label3.Text = "N = "; textBox3.Text = "10000";
        }

        private void calculate_button_Click(object sender, EventArgs e)
        {
            if (radioButton_uniform.Checked)
                UniformDistribution();
            
            else if (radioButton_gauss.Checked)
                GaussDistribution();
            
            else if (radioButton_exp.Checked)
                ExponentialDistribution();
            
            else if (radioButton_gamma.Checked)
                GammaDistribution();
            
            else if (radioButton_triangle.Checked)
                TriangleDistribution();
            
            else if (radioButton_simpson.Checked)
                SimpsonDistribution();

            double N = randArray.Count();
            dgvRes.RowCount = (int)N;
            for (int i = 0; i < N; i++){
                dgvRes.Rows[i].Cells[0].Value = randArray[i];
            }

            double Count = 0;
            for (int i = 1; i < N / 2; i++) { 
                if (Math.Pow(randArray[2*i-1], 2) + Math.Pow(randArray[2*i], 2) < 1) {
                    Count++;
                }
            }

            tbEvidence.Text = (Count / (N / 2)).ToString();
        }

        private void UniformDistribution()
        {
            LRandom rand = new LRandom(ulong.Parse(textBox_a.Text), ulong.Parse(textBox_m.Text), ulong.Parse(textBox_R0.Text));

            int N = int.Parse(textBox3.Text);
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);

            randArray = new double[N];

            for (int i = 0; i < N; i++)
                randArray[i] = a + (b - a) * rand.Next();

            CalculateStatValues();
            DrawHistogram();            
        }

        private void GaussDistribution()
        {
            LRandom rand = new LRandom(ulong.Parse(textBox_a.Text), ulong.Parse(textBox_m.Text), ulong.Parse(textBox_R0.Text));
            int N = int.Parse(textBox4.Text);          
            double m = double.Parse(textBox1.Text);    
            double sko = double.Parse(textBox2.Text);  
            int n = int.Parse(textBox3.Text);          

            randArray = new double[N];
            for (int i = 0; i < N; i++)
            {
                double tmp = 0;
                for (int j = 0; j < n; j++)
                    tmp += rand.Next();

                randArray[i] = m + sko*Math.Sqrt(12.0/n)*(tmp - (double) n/2);
            }

            CalculateStatValues();
            DrawHistogram();            
        }

        private void ExponentialDistribution()
        {
            LRandom rand = new LRandom(ulong.Parse(textBox_a.Text), ulong.Parse(textBox_m.Text), ulong.Parse(textBox_R0.Text));
            int N = int.Parse(textBox2.Text);          
            double λ = double.Parse(textBox1.Text);    

            randArray = new double[N];
            for (int i = 0; i < N; i++)
                randArray[i] = - Math.Log(rand.Next()) / λ;

            CalculateStatValues();
            DrawHistogram();            
        }

        private void GammaDistribution()
        {
            LRandom rand = new LRandom(ulong.Parse(textBox_a.Text), ulong.Parse(textBox_m.Text), ulong.Parse(textBox_R0.Text));
            int N = int.Parse(textBox3.Text);          
            int η = int.Parse(textBox1.Text);   
            double λ = double.Parse(textBox2.Text);

            randArray = new double[N];
            for (int i = 0; i < N; i++)
            {
                double tmp = 1;
                for (int j = 0; j < η; j++)
                    tmp *= rand.Next();

                randArray[i] = -Math.Log(tmp) / λ;
            }

            CalculateStatValues();
            DrawHistogram();            
        }

        private void TriangleDistribution()
        {
            LRandom rand = new LRandom(ulong.Parse(textBox_a.Text), ulong.Parse(textBox_m.Text), ulong.Parse(textBox_R0.Text));
            int N = int.Parse(textBox3.Text);
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);

            randArray = new double[N];

            for (int i = 0; i < N; i++)
            {
                double R1 = rand.Next();
                double R2 = rand.Next();
                randArray[i] = a + (b - a) * Math.Max(R1, R2);
            }
                

            CalculateStatValues();
            DrawHistogram();            
        }

        private void SimpsonDistribution()
        {
            LRandom rand = new LRandom(ulong.Parse(textBox_a.Text), ulong.Parse(textBox_m.Text), ulong.Parse(textBox_R0.Text));
            int N = int.Parse(textBox3.Text);
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);

            randArray = new double[N];

            for (int i = 0; i < N; i++)
                randArray[i] = a/2 + (b/2 - a/2)*rand.Next() + a/2 + (b/2 - a/2)*rand.Next();

            CalculateStatValues();
            DrawHistogram();            
        }

        private void CalculateStatValues()
        {
            double Mx = randArray.Sum() / randArray.Length;
            textBox_Mx.Text = Mx.ToString();

            double Dx = randArray.Sum(t => (t - Mx) * (t - Mx)) / (randArray.Length - 1);
            textBox_Dx.Text = Dx.ToString();

            textBox_sko.Text = (Math.Sqrt(Dx)).ToString();
        }

        private void DrawHistogram()
        {
            zedGraphControl1.Visible = true;

            List<double> numbers = new List<double>(randArray);
            numbers.Sort();

            const int intervalsCount = 20;
            double width = numbers.Last() - numbers.First();

            double widthOfInterval = width / intervalsCount;

            double[] heights = new double[intervalsCount];    
            double[] X_values = new double[intervalsCount];   

            X_values[0] = 0.025 * width + numbers.First();
            for (int i = 1; i < intervalsCount; i++)
                X_values[i] = X_values[i - 1] + widthOfInterval;

            double xLeft = numbers.First();          
            double xRight = xLeft + widthOfInterval; 
            int j = 0;
            for (int i = 0; i < intervalsCount; i++)
            {
                while (j < numbers.Count && xLeft <= numbers[j] && xRight > numbers[j])
                {
                    heights[i] ++;
                    j++;
                }
                heights[i] /= numbers.Count;
                xLeft = xRight;
                xRight += widthOfInterval;
            }
            
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.XAxis.Title.Text = "Значение величины";
            pane.YAxis.Title.Text = "Частота попадания в интервал";
            pane.Title.Text = "Гистограмма непрерывного распределения";            
            pane.CurveList.Clear();

            BarItem bar = pane.AddBar("", X_values, heights, Color.DarkGreen);
            
            pane.BarSettings.MinClusterGap = 0.0f;

            pane.XAxis.Scale.Min = numbers.First();
            pane.XAxis.Scale.Max = numbers.Last();
            pane.XAxis.Scale.AlignH = AlignH.Center;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

    }
}
