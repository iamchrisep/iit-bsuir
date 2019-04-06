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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int X = Convert.ToInt32(textBox1.Text);
            int a = Convert.ToInt32(textBox2.Text);
            int c = Convert.ToInt32(textBox3.Text);
            int m = Convert.ToInt32(textBox4.Text);
            int N = Convert.ToInt32(textBox5.Text);

            double[] result=new double[N];
            double temp=X;

            //Рассчет значений Xi
            for (int i = 0; i < N; i++)
            {
                double f = (a * temp + c) % m;
                result[i] = f / m;
                temp = f;
            }
            //Random rand = new Random();
            //for (int i = 0; i < N; i++)
            //{
            //    result[i] = rand.NextDouble();
            //}

            //Выведение результатов из массива на экран
            dataGridView1.RowCount = N;
            for(int i=0;i<N;i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = result[i];
            }
            
            //Расчет мат.ожидания,дисперсии и СКО
            double mat = 0, disp = 0, sko = 0;
            
            mat = Math.Round(((1.0/(double)N)*result.Sum()),6);
            textBox6.Text = mat.ToString();
            //-------------------------------------------------
            for (int q = 0; q < N; q++ )
            {
                disp += Math.Pow((result[q] - mat), 2);
            }
            disp = Math.Round(((1.0 / (double)N) * disp),6);
            textBox7.Text = disp.ToString();
            //-------------------------------------------------
            sko = Math.Round(Math.Sqrt(disp),6);
            textBox8.Text = sko.ToString();
            //-------------------------------------------------

            #region Построение гистограммы
            List<double> numbers = new List<double>(result);
            numbers.Sort();

            const int intervalsCount = 20;
            double width = numbers.Last() - numbers.First();

            double widthOfInterval = width / intervalsCount;

            double[] heights = new double[intervalsCount];    // Высота столбцов гистограммы
            double[] X_values = new double[intervalsCount];  // Значение по оси x

            X_values[0] = Math.Round(0.0245 * width + numbers.First(), 3);
            for (int i = 1; i < intervalsCount; i++)
                X_values[i] = Math.Round(X_values[i - 1] + widthOfInterval, 3);

            double xLeft = numbers.First();           // Начало диаграммы по оси x
            double xRight = xLeft + widthOfInterval;  // Конец текущего интервала по оси x
            int j = 0;
            for (int i = 0; i < intervalsCount; i++)
            {
                while (j < numbers.Count && xLeft <= numbers[j] && xRight > numbers[j])
                {
                    heights[i]++;
                    j++;
                }
                heights[i] /= numbers.Count;
                xLeft = xRight;
                xRight += widthOfInterval;
            }

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.Series["Series1"]["PointWidth"] = "1";
            chart1.Series["Series1"].Points.DataBindXY(X_values, heights);
            #endregion

           

            //Равномерность косвенная
            int K = 0;
            for(int i=1;i<N;i++)
            {
                if((Math.Pow(result[i-1],2)+Math.Pow(result[i],2))<1)
                {
                    K += 1;
                }
            }
            double kosres=(2.0 * (double)K) / (double)N;
            textBox11.Text = kosres.ToString();           


            //Определение длины периода

            double V = result[N - 1];
            int i1=0, i2=0;
            int flag=0;
            for(int v=0;v<N;v++)
            {
                if(result[v]==V)
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        i1 = v;
                    }
                    else { i2 = v; break; }
                }
            }
            int P = i2 - i1;
            textBox9.Text = P.ToString();

            //Определение длины отрезка апериодичности

            int i3 = 0;
            while (result[i3] != result[i3 + P])
            {
                i3++;
            }
            int aperiod = i3 + P;
            textBox10.Text = aperiod.ToString();
        }
    }
}
