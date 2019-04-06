using System;
using System.Windows.Forms;

namespace l1
{
    public partial class Graph1 : Form
    {
        public Graph1()
        {
            InitializeComponent();

            chart1.SetBounds(8, 10, this.Size.Width / 2 - 20, this.Size.Height - 170);

            this.Load += (s, e) => {
                chart1.Series.Clear();
                chart1.ResetAutoValues();
                chart1.Series.Add(GraphHelper.DataSer1);
            };
        }

        private void Graph1_Load(object sender, EventArgs e)
        {
            label1.Text = "Константа Зипфа для первого закона: " + GraphHelper.ZipfC1.ToString();
        }
    }
}
