using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ZedGraph;

namespace lab4{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }

        private void Imitate(){
            int requestsNumber = int.Parse(textBox_number.Text);    
            double λ = double.Parse(textBox_intensity.Text);        
            double μ1 = double.Parse(textBox_ch1.Text);             
            double μ2 = double.Parse(textBox_ch2.Text);             
            int maxQueueCount1 = int.Parse(textBox_queue1.Text);    
            int maxQueueCount2 = int.Parse(textBox_queue2.Text);   

            QueuingSystem qs = new QueuingSystem(λ, μ1, μ2, maxQueueCount1, maxQueueCount2);
            qs.Imitate(requestsNumber); 
        
            tbdenialCount1.Text = qs.DenialCount1.ToString();
            textBox_denial1.Text = Math.Round(qs.DenialProbability1, 6).ToString();            
           
            tbdenialCount2.Text = qs.DenialCount2.ToString();
            textBox_denial2.Text = Math.Round(qs.DenialProbability2, 6).ToString();             
            
            tbdenialCount.Text = qs.DenialCount.ToString();
            textBox_denial.Text = Math.Round(qs.DenialProbability, 6).ToString();
        }

        private void DrawGraph(){
            zedGraphControl.Visible = true;
 
            double μ1 = double.Parse(textBox_ch1.Text);            
            double μ2 = double.Parse(textBox_ch2.Text);             
            int maxQueueCount1 = int.Parse(textBox_queue1.Text);    
            int maxQueueCount2 = int.Parse(textBox_queue2.Text);    

            double λmin = double.Parse(textBox_λmin.Text);
            double λmax = double.Parse(textBox_λmax.Text);
            double step = double.Parse(textBox_step.Text);
           
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
            
            GraphPane pane = zedGraphControl.GraphPane;

            pane.XAxis.Title.Text = "λ, интенсивность входного потока заявок";
            pane.YAxis.Title.Text = "Вероятность отказа";
            pane.Title.Text = "График зависимости P от λ";            
            pane.CurveList.Clear();

            LineItem denial1Curve = pane.AddCurve("Первая фаза", denialProbability1Points, Color.Yellow, SymbolType.Default);
            LineItem denial2Curve = pane.AddCurve("Вторая фаза", denialProbability2Points, Color.Green, SymbolType.Default);
            LineItem denialCurve = pane.AddCurve("СМО", denialProbabilityPoints, Color.Red, SymbolType.Default);

            denialCurve.Line.Width = 3f;
            denialCurve.Symbol.Fill = new Fill(Color.Red);

            denial1Curve.Line.Width = 3f;
            denial1Curve.Symbol.Fill = new Fill(Color.Yellow);

            denial2Curve.Line.Width = 3f;
            denial2Curve.Symbol.Fill = new Fill(Color.Green);

            zedGraphControl.AxisChange();            
            zedGraphControl.Invalidate();
        }

        private void buttonSimulate_Click(object sender, EventArgs e){
            Imitate();
            DrawGraph();
        }
    }
}
