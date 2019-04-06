using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace l7_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text file|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                int percent = 0;
                int.TryParse(percentTextBox.Text, out percent);
                var source = "";
                using (TextReader reader = new StreamReader(dlg.FileName, Encoding.Default))
                {
                    source = reader.ReadToEnd().ToLower();
                }
                var manager = new ReviewManager(percent);
                using (TextReader reader = new StreamReader(@"E:\WorkMaterials\ИОФС\l7_\l7_\bin\Debug\stop-words.txt", Encoding.Default))
                {
                    manager.LoadStopWords(reader.ReadToEnd().ToLower());
                }
                reviewTextBox.Text = manager.GetReview(source);
            }
        }
    }
}
