using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            QueuingSystem smo = new QueuingSystem(double.Parse(textBox_p.Text), double.Parse(textBox_p1.Text), double.Parse(textBox_p2.Text));
            int ticksCount = int.Parse(textBox_ticks.Text);

            for (int i = 0; i < ticksCount - 1; i++)
                smo.GenerateNextState();
            
            
            textBox_denial.Text = (smo.DenialCounter / (double)ticksCount).ToString(); // Pотк - вероятность отказа
            textBox_k1.Text = (smo.Counter1/(double) ticksCount).ToString(); // Коэффициент загрузки канала 1
            textBox_k2.Text = (smo.Counter2 /(double)ticksCount).ToString(); // Коэффициент загрузки канала 2

            label_denial.Text = "Количество отказов: " + smo.DenialCounter.ToString();
            label_k1.Text = "Количество тактов с занятым каналом 1: " + smo.Counter1.ToString();
            label_k2.Text = "Количество тактов с занятым каналом 2: " + smo.Counter2.ToString();
            label_ticks.Text = "Количество тактов: " + ticksCount.ToString();
        }

    }
}
