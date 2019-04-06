namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Res = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.radioButton_uniform = new System.Windows.Forms.RadioButton();
            this.radioButton_gauss = new System.Windows.Forms.RadioButton();
            this.radioButton_exp = new System.Windows.Forms.RadioButton();
            this.radioButton_gamma = new System.Windows.Forms.RadioButton();
            this.radioButton_triangle = new System.Windows.Forms.RadioButton();
            this.radioButton_simpson = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "c";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "m";
            this.label4.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(53, 68);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(53, 102);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(53, 137);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 8;
            this.textBox4.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 38);
            this.button1.TabIndex = 10;
            this.button1.Text = "Начать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Res});
            this.dataGridView1.Location = new System.Drawing.Point(457, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.Size = new System.Drawing.Size(152, 308);
            this.dataGridView1.TabIndex = 11;
            // 
            // Res
            // 
            this.Res.FillWeight = 150F;
            this.Res.Frozen = true;
            this.Res.HeaderText = "Результаты";
            this.Res.Name = "Res";
            this.Res.ReadOnly = true;
            this.Res.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Res.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Res.Width = 150;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(659, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "M";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(711, 25);
            this.textBox6.MaxLength = 10;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(105, 20);
            this.textBox6.TabIndex = 13;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(711, 55);
            this.textBox7.MaxLength = 10;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(105, 20);
            this.textBox7.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(659, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "D";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(711, 86);
            this.textBox8.MaxLength = 10;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(105, 20);
            this.textBox8.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(659, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "CKO";
            // 
            // chart1
            // 
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisX.Title = "Xk";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.Title = "Ck";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(23, 368);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.BorderColor = System.Drawing.Color.Red;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.IsXValueIndexed = true;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(910, 239);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // radioButton_uniform
            // 
            this.radioButton_uniform.AutoSize = true;
            this.radioButton_uniform.Location = new System.Drawing.Point(6, 28);
            this.radioButton_uniform.Name = "radioButton_uniform";
            this.radioButton_uniform.Size = new System.Drawing.Size(94, 17);
            this.radioButton_uniform.TabIndex = 19;
            this.radioButton_uniform.TabStop = true;
            this.radioButton_uniform.Text = "Равномерное";
            this.radioButton_uniform.UseVisualStyleBackColor = true;
            this.radioButton_uniform.CheckedChanged += new System.EventHandler(this.radioButton_uniform_CheckedChanged);
            // 
            // radioButton_gauss
            // 
            this.radioButton_gauss.AutoSize = true;
            this.radioButton_gauss.Location = new System.Drawing.Point(6, 143);
            this.radioButton_gauss.Name = "radioButton_gauss";
            this.radioButton_gauss.Size = new System.Drawing.Size(90, 17);
            this.radioButton_gauss.TabIndex = 20;
            this.radioButton_gauss.TabStop = true;
            this.radioButton_gauss.Text = "Гауссовское";
            this.radioButton_gauss.UseVisualStyleBackColor = true;
            this.radioButton_gauss.Visible = false;
            this.radioButton_gauss.CheckedChanged += new System.EventHandler(this.radioButton_gauss_CheckedChanged);
            // 
            // radioButton_exp
            // 
            this.radioButton_exp.AutoSize = true;
            this.radioButton_exp.Location = new System.Drawing.Point(6, 51);
            this.radioButton_exp.Name = "radioButton_exp";
            this.radioButton_exp.Size = new System.Drawing.Size(122, 17);
            this.radioButton_exp.TabIndex = 21;
            this.radioButton_exp.TabStop = true;
            this.radioButton_exp.Text = "Экспоненциальное";
            this.radioButton_exp.UseVisualStyleBackColor = true;
            this.radioButton_exp.CheckedChanged += new System.EventHandler(this.radioButton_exp_CheckedChanged);
            // 
            // radioButton_gamma
            // 
            this.radioButton_gamma.AutoSize = true;
            this.radioButton_gamma.Location = new System.Drawing.Point(6, 97);
            this.radioButton_gamma.Name = "radioButton_gamma";
            this.radioButton_gamma.Size = new System.Drawing.Size(140, 17);
            this.radioButton_gamma.TabIndex = 22;
            this.radioButton_gamma.TabStop = true;
            this.radioButton_gamma.Text = "Гамма-распределение";
            this.radioButton_gamma.UseVisualStyleBackColor = true;
            this.radioButton_gamma.Visible = false;
            this.radioButton_gamma.CheckedChanged += new System.EventHandler(this.radioButton_gamma_CheckedChanged);
            // 
            // radioButton_triangle
            // 
            this.radioButton_triangle.AutoSize = true;
            this.radioButton_triangle.Location = new System.Drawing.Point(6, 120);
            this.radioButton_triangle.Name = "radioButton_triangle";
            this.radioButton_triangle.Size = new System.Drawing.Size(90, 17);
            this.radioButton_triangle.TabIndex = 23;
            this.radioButton_triangle.TabStop = true;
            this.radioButton_triangle.Text = "Треугольное";
            this.radioButton_triangle.UseVisualStyleBackColor = true;
            this.radioButton_triangle.Visible = false;
            this.radioButton_triangle.CheckedChanged += new System.EventHandler(this.radioButton_triangle_CheckedChanged);
            // 
            // radioButton_simpson
            // 
            this.radioButton_simpson.AutoSize = true;
            this.radioButton_simpson.Location = new System.Drawing.Point(6, 74);
            this.radioButton_simpson.Name = "radioButton_simpson";
            this.radioButton_simpson.Size = new System.Drawing.Size(76, 17);
            this.radioButton_simpson.TabIndex = 24;
            this.radioButton_simpson.TabStop = true;
            this.radioButton_simpson.Text = "Симпсона";
            this.radioButton_simpson.UseVisualStyleBackColor = true;
            this.radioButton_simpson.CheckedChanged += new System.EventHandler(this.radioButton_simpson_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_simpson);
            this.groupBox1.Controls.Add(this.radioButton_gamma);
            this.groupBox1.Controls.Add(this.radioButton_triangle);
            this.groupBox1.Controls.Add(this.radioButton_exp);
            this.groupBox1.Controls.Add(this.radioButton_gauss);
            this.groupBox1.Controls.Add(this.radioButton_uniform);
            this.groupBox1.Location = new System.Drawing.Point(23, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 182);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор распределения";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(234, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 182);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 619);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Лабораторная работа № 2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Res;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.RadioButton radioButton_uniform;
        private System.Windows.Forms.RadioButton radioButton_gauss;
        private System.Windows.Forms.RadioButton radioButton_exp;
        private System.Windows.Forms.RadioButton radioButton_gamma;
        private System.Windows.Forms.RadioButton radioButton_triangle;
        private System.Windows.Forms.RadioButton radioButton_simpson;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

