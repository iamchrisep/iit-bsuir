using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ZedGraph;

namespace lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Imitate()
        {
            int requestsNumber = int.Parse(textBox_number.Text);    // Количество заявок во входном потоке
            double λ = double.Parse(textBox_intensity.Text);        // Интенсивность входного потока заявок
            double μ1 = double.Parse(textBox_ch1.Text);             // Интенсивность обработки заявок канала 1
            double μ2 = double.Parse(textBox_ch2.Text);             // Интенсивность обработки заявок канала 2
            int maxQueueCount1 = int.Parse(textBox_queue1.Text);    // Число мест ожидания 1-й фазы
            int maxQueueCount2 = int.Parse(textBox_queue2.Text);    // Число мест ожидания 2-й фазы

            QueuingSystem qs = new QueuingSystem(λ, μ1, μ2, maxQueueCount1, maxQueueCount2);

            qs.Imitate(requestsNumber); 


            label_denialCount1.Text = @"Количество отказов 1: " + qs.DenialCount1;
            textBox_denial1.Text = qs.DenialProbability1.ToString(CultureInfo.InvariantCulture);

            label_denialCount2.Text = @"Количество отказов 2: " + qs.DenialCount2;
            textBox_denial2.Text = qs.DenialProbability2.ToString(CultureInfo.InvariantCulture);

            label_denialCount.Text = @"Количество отказов: " + qs.DenialCount;
            textBox_denial.Text = qs.DenialProbability.ToString(CultureInfo.InvariantCulture);
        }

        private void task_a()
        {
            double μ1 = double.Parse(textBox_ch1.Text);             // Интенсивность обработки заявок канала 1
            double μ2 = double.Parse(textBox_ch2.Text);             // Интенсивность обработки заявок канала 2
            int maxQueueCount1 = int.Parse(textBox_queue1.Text);    // Число мест ожидания 1-й фазы
            int maxQueueCount2 = int.Parse(textBox_queue2.Text);    // Число мест ожидания 2-й фазы

            double λmin = double.Parse(textBox_λmin.Text);
            double λmax = double.Parse(textBox_λmax.Text);
            double step = double.Parse(textBox_step.Text);

            // Создадим список точек
            PointPairList denialProbabilityPoints = new PointPairList();
            PointPairList denialProbability1Points = new PointPairList();
            PointPairList denialProbability2Points = new PointPairList();

            for (double λ = λmin; λ <= λmax; λ += step)
            {
                QueuingSystem qs = new QueuingSystem(λ, μ1, μ2, maxQueueCount1, maxQueueCount2);
                qs.Imitate();

                denialProbabilityPoints.Add(λ, qs.DenialProbability);
                denialProbability1Points.Add(λ, qs.DenialProbability1);
                denialProbability2Points.Add(λ, qs.DenialProbability2);
            }

            // Получим панель для рисования
            GraphPane pane = zedGraphControl_a.GraphPane;

            pane.XAxis.Title.Text = "λ, интенсивность входного потока заявок";
            pane.YAxis.Title.Text = "Вероятность";
            pane.Title.Text = "";

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();


            LineItem denialCurve = pane.AddCurve("Вероятность отказа", denialProbabilityPoints, Color.Blue, SymbolType.Default);
            LineItem denial1Curve = pane.AddCurve("Вероятность отказа 1", denialProbability1Points, Color.Black, SymbolType.Default);
            LineItem denial2Curve = pane.AddCurve("Вероятность отказа 2", denialProbability2Points, Color.Green, SymbolType.Default);

            denialCurve.Line.Width = 1.2f;
            denialCurve.Symbol.Fill = new Fill(Color.Blue);

            denial1Curve.Line.Width = 1.2f;
            denial1Curve.Symbol.Fill = new Fill(Color.Black);

            denial2Curve.Line.Width = 1.2f;
            denial2Curve.Symbol.Fill = new Fill(Color.Green);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphControl_a.AxisChange();

            // Обновляем график
            zedGraphControl_a.Invalidate();
        }

        private void task_b()
        {
            double μ1 = double.Parse(textBox_ch1.Text);             // Интенсивность обработки заявок канала 1
            double μ2 = double.Parse(textBox_ch2.Text);             // Интенсивность обработки заявок канала 2
            int maxQueueCount2 = int.Parse(textBox_queue2.Text);    // Число мест ожидания 2-й фазы

            int n1_min = int.Parse(textBox_n1_min.Text);
            int n1_max = int.Parse(textBox_n1_max.Text);
            double λ = double.Parse(textBox_λ.Text);

            // Создадим список точек
            PointPairList denialProbabilityPoints = new PointPairList();
            PointPairList denialProbability1Points = new PointPairList();
            PointPairList denialProbability2Points = new PointPairList();

            for (int n1 = n1_min; n1 <= n1_max; n1++)
            {
                QueuingSystem qs = new QueuingSystem(λ, μ1, μ2, n1, maxQueueCount2);
                qs.Imitate();

                denialProbabilityPoints.Add(n1, qs.DenialProbability);
                denialProbability1Points.Add(n1, qs.DenialProbability1);
                denialProbability2Points.Add(n1, qs.DenialProbability2);
            }

            // Получим панель для рисования
            GraphPane pane = zedGraphControl_b.GraphPane;

            pane.XAxis.Title.Text = "n1, число мест ожидания 1-й фазы";
            pane.YAxis.Title.Text = "Вероятность";
            pane.Title.Text = "";

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();


            LineItem denialCurve = pane.AddCurve("Вероятность отказа", denialProbabilityPoints, Color.Blue, SymbolType.Default);
            LineItem denial1Curve = pane.AddCurve("Вероятность отказа 1", denialProbability1Points, Color.Black, SymbolType.Default);
            LineItem denial2Curve = pane.AddCurve("Вероятность отказа 2", denialProbability2Points, Color.Green, SymbolType.Default);

            denialCurve.Line.Width = 1.2f;
            denialCurve.Symbol.Fill = new Fill(Color.Blue);

            denial1Curve.Line.Width = 1.2f;
            denial1Curve.Symbol.Fill = new Fill(Color.Black);

            denial2Curve.Line.Width = 1.2f;
            denial2Curve.Symbol.Fill = new Fill(Color.Green);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphControl_b.AxisChange();

            // Обновляем график
            zedGraphControl_b.Invalidate();
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    Imitate();
                    break;
                case 1:
                    task_a();
                    break;
                case 2:
                    task_b();
                    break;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_queue1.Enabled = tabControl1.SelectedIndex != 2;
        }
    }
}
