using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1
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
            label1.Text = "a = "; textBox1.Text = "5";
            label2.Text = "b = "; textBox2.Text = "10";
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
            label1.Text = "η = "; textBox1.Text = "18";
            label2.Text = "λ = "; textBox2.Text = "2,5";
            label3.Text = "N = "; textBox3.Text = "10000";
        }

        private void radioButton_triangle_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_triangle.Checked) return;
            label1.Text = "a = "; textBox1.Text = "3";
            label2.Text = "b = "; textBox2.Text = "9";
            label3.Text = "N = "; textBox3.Text = "10000";
        }

        private void radioButton_simpson_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_simpson.Checked) return;
            label1.Text = "a = "; textBox1.Text = "18";
            label2.Text = "b = "; textBox2.Text = "30";
            label3.Text = "N = "; textBox3.Text = "10000";
        }

         private void UniformDistribution() 
        {
            Random rand = new Random();
            int N = int.Parse(textBox3.Text);
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);

            randArray = new double[N];

            for (int i = 0; i < N; i++)
                randArray[i] = a + (b - a) * rand.NextDouble();

            CalculateStatValues();
            DrawHistogram();
            dataGridView1.RowCount = N;
            for (int j = 0; j < N; j++)
            {
                dataGridView1.Rows[j].Cells[0].Value = randArray[j];
            }
            
        }
      private void GaussDistribution()
        {
            Random rand = new Random();
            int N = int.Parse(textBox4.Text);          // Количество генерируемых чисел
            double m = double.Parse(textBox1.Text);    // Мат. ожидание
            double sko = double.Parse(textBox2.Text);  // СКО
            int n = int.Parse(textBox3.Text);          // Число суммируемых равномерно распределённых чисел

            randArray = new double[N];
            for (int i = 0; i < N; i++)
            {
                double tmp = 0;
                for (int j = 0; j < n; j++)
                    tmp += rand.NextDouble();

                randArray[i] = m + sko*Math.Sqrt(12.0/n)*(tmp - (double) n/2);
            }

            CalculateStatValues();
            DrawHistogram();
            dataGridView1.RowCount = N;
            for (int j = 0; j < N; j++)
            {
                dataGridView1.Rows[j].Cells[0].Value = randArray[j];
            }
            
        }

        // Экспоненциальное распределение
        private void ExponentialDistribution()
        {
            Random rand = new Random();
            int N = int.Parse(textBox2.Text);          // Количество генерируемых чисел
            double λ = double.Parse(textBox1.Text);    // Параметр экспоненциального распределения

            randArray = new double[N];
            for (int i = 0; i < N; i++)
                randArray[i] = - Math.Log(rand.NextDouble()) / λ;

            CalculateStatValues();
            DrawHistogram();
            dataGridView1.RowCount = N;
            for (int j = 0; j < N; j++)
            {
                dataGridView1.Rows[j].Cells[0].Value = randArray[j];
            }
            
        }

        // Гамма-распределение
        private void GammaDistribution()
        {
            Random rand = new Random();
            int N = int.Parse(textBox3.Text);          // Количество генерируемых чисел
            int η = int.Parse(textBox1.Text);   
            double λ = double.Parse(textBox2.Text);

            randArray = new double[N];
            for (int i = 0; i < N; i++)
            {
                double tmp = 1;
                for (int j = 0; j < η; j++)
                    tmp *= rand.NextDouble();

                randArray[i] = -Math.Log(tmp) / λ;
            }

            CalculateStatValues();
            DrawHistogram();
            dataGridView1.RowCount = N;
            for (int j = 0; j < N; j++)
            {
                dataGridView1.Rows[j].Cells[0].Value = randArray[j];
            }
            
        }

        // Треугольное распределение
        private void TriangleDistribution()
        {
            Random rand = new Random();
            int N = int.Parse(textBox3.Text);
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);

            randArray = new double[N];

            for (int i = 0; i < N; i++)
            {
                double R1 = rand.NextDouble();
                double R2 = rand.NextDouble();
                randArray[i] = a + (b - a) * Math.Max(R1, R2);
            }
                

            CalculateStatValues();
            DrawHistogram();
            dataGridView1.RowCount = N;
            for (int j = 0; j < N; j++)
            {
                dataGridView1.Rows[j].Cells[0].Value = randArray[j];
            }
            
        }

        // Распределение Симпсона
        private void SimpsonDistribution()
        {
            Random rand = new Random();
            int N = int.Parse(textBox3.Text);
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);

            randArray = new double[N];

            for (int i = 0; i < N; i++)
                randArray[i] = a/2 + (b/2 - a/2)*rand.NextDouble() + a/2 + (b/2 - a/2)*rand.NextDouble();

            CalculateStatValues();
            DrawHistogram();
            dataGridView1.RowCount = N;
            for (int j = 0; j < N; j++)
            {
                dataGridView1.Rows[j].Cells[0].Value = randArray[j];
            }
            
        }


      
        // Вычисление математического ожидания, дисперсии и СКО
        private void CalculateStatValues()
        {
            double Mx = randArray.Sum() / randArray.Length;
            textBox6.Text = Mx.ToString();

            double Dx = randArray.Sum(t => (t - Mx) * (t - Mx)) / (randArray.Length - 1);
            textBox7.Text = Dx.ToString();

            textBox8.Text = (Math.Sqrt(Dx)).ToString();
        }

        private void  DrawHistogram()
        {
            

            List<double> numbers = new List<double>(randArray);
            numbers.Sort();

            const int intervalsCount = 20;
            double width = numbers.Last() - numbers.First();

            double widthOfInterval = width / intervalsCount;

            double[] heights = new double[intervalsCount];    // Высота столбцов гистограммы
            double[] X_values = new double[intervalsCount];  // Значение по оси x

            X_values[0] = Math.Round(0.0245 * width + numbers.First(),3);
            for (int i = 1; i < intervalsCount; i++)
                X_values[i] = Math.Round(X_values[i - 1] + widthOfInterval,3);

            double xLeft = numbers.First();           // Начало диаграммы по оси x
            double xRight = xLeft + widthOfInterval;  // Конец текущего интервала по оси x
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

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.Series["Series1"]["PointWidth"] = "1";
            chart1.Series["Series1"].Points.DataBindXY(X_values,heights);
            
        }
                  
        private void button1_Click(object sender, EventArgs e)
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
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

            
        
    }
}
