using System;
using System.Windows.Forms;

namespace l1
{
    public partial class Graph2 : Form
    {
        public Graph2()
        {
            InitializeComponent();

            chart2.SetBounds(8, 10, this.Size.Width / 2 - 20, this.Size.Height - 170);

            this.Load += (s, e) =>
            {
                chart2.Series.Clear();
                chart2.ResetAutoValues();
                chart2.Series.Add(GraphHelper.DataSer2);
            };

        }

        private void Graph2_Load(object sender, EventArgs e)
        {
            label1.Text = "Константа Зипфа для второго закона: " + GraphHelper.ZipfC2.ToString();
        }
    }
}
