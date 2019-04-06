using System;
using System.Windows.Forms;

namespace l1
{
    public partial class GridForm : Form
    {
        public GridForm()
        {
            InitializeComponent();

            var col1 = new DataGridViewColumn
            {
                HeaderText = "Словоформа",
                Name = "word",
                ReadOnly = true,
                Resizable = DataGridViewTriState.True,
                Width = 150,                
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var col2 = new DataGridViewColumn
            {
                HeaderText = "Повторений",
                Name = "repeats",
                ReadOnly = true,
                Resizable = DataGridViewTriState.True,
                Width = 80,
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var col3 = new DataGridViewColumn
            {
                HeaderText = "Ранг",
                Name = "rank",
                ReadOnly = true,
                Resizable = DataGridViewTriState.True,
                Width = 50,
                CellTemplate = new DataGridViewTextBoxCell()
            };

            var col4 = new DataGridViewColumn
            {
                HeaderText = "Частота",
                Name = "freq",
                ReadOnly = true,
                Resizable = DataGridViewTriState.True,
                Width = 60,
                CellTemplate = new DataGridViewTextBoxCell()
            };
            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);
            dataGridView1.Columns.Add(col4);

            this.Load += (s, e) => {
                //DataGridViewRow[] rows = new DataGridViewRow[GraphHelper.GridRows.Count];
                //GraphHelper.GridRows.CopyTo(rows, 0);

                foreach (DataGridViewRow x in GraphHelper.GridRows)
                    dataGridView1.Rows.Add(x.Cells[0].Value, x.Cells[1].Value, x.Cells[2].Value, x.Cells[3].Value);
            };

            this.Focus();
        }

        private void GridForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
