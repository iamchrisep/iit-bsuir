using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _analyzer = new Analyzer();
            using (TextReader reader = new StreamReader(@"E:\WorkMaterials\ИОФС\l7_\l7_\bin\Debug\stop-words.txt", Encoding.Default))
            {
                _analyzer.LoadStopWords(reader.ReadToEnd().ToLower());
            }
        }
        private Analyzer _analyzer { get; set; }

        private void addTopicButton_Click(object sender, EventArgs e)
        {
            var topic = newTopicTextBox.Text;
            if(!string.IsNullOrEmpty(topic))
            {
                topicComboBox.Items.Add(topic);
            }
        }

        private void loadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text file|*.txt";
            if (topicComboBox.Items.Count > 0)
            {
                var topic = topicComboBox.SelectedItem as string;
                if (!string.IsNullOrEmpty(topic))
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        var source = "";

                        using (TextReader reader = new StreamReader(dlg.FileName, Encoding.Default))
                        {
                            source = reader.ReadToEnd().ToLower();
                        }

                        _analyzer.AddExample(source, topic);
                    }
                }
            }
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text file|*.txt";
            if (topicComboBox.Items.Count > 0)
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var source = "";

                    using (TextReader reader = new StreamReader(dlg.FileName, Encoding.Default))
                    {
                        source = reader.ReadToEnd().ToLower();
                    }

                    resultLabel.Text = _analyzer.Analyze(source);

                }
                
            }
        }
    }
}
