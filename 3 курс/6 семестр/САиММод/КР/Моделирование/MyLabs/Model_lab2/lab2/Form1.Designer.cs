namespace lab2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_simpson = new System.Windows.Forms.RadioButton();
            this.radioButton_triangle = new System.Windows.Forms.RadioButton();
            this.radioButton_gamma = new System.Windows.Forms.RadioButton();
            this.radioButton_exp = new System.Windows.Forms.RadioButton();
            this.radioButton_gauss = new System.Windows.Forms.RadioButton();
            this.radioButton_uniform = new System.Windows.Forms.RadioButton();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.calculate_button = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_sko = new System.Windows.Forms.TextBox();
            this.textBox_Dx = new System.Windows.Forms.TextBox();
            this.textBox_Mx = new System.Windows.Forms.TextBox();
            this.label_sko = new System.Windows.Forms.Label();
            this.labelDx = new System.Windows.Forms.Label();
            this.labelMx = new System.Windows.Forms.Label();
            this.distNameLabel = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_R0 = new System.Windows.Forms.TextBox();
            this.textBox_m = new System.Windows.Forms.TextBox();
            this.textBox_a = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvRes = new System.Windows.Forms.DataGridView();
            this.Res = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbEvidence = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRes)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_simpson);
            this.groupBox1.Controls.Add(this.radioButton_triangle);
            this.groupBox1.Controls.Add(this.radioButton_gamma);
            this.groupBox1.Controls.Add(this.radioButton_exp);
            this.groupBox1.Controls.Add(this.radioButton_gauss);
            this.groupBox1.Controls.Add(this.radioButton_uniform);
            this.groupBox1.Location = new System.Drawing.Point(213, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид распределения";
            // 
            // radioButton_simpson
            // 
            this.radioButton_simpson.AutoSize = true;
            this.radioButton_simpson.Location = new System.Drawing.Point(254, 55);
            this.radioButton_simpson.Name = "radioButton_simpson";
            this.radioButton_simpson.Size = new System.Drawing.Size(76, 17);
            this.radioButton_simpson.TabIndex = 5;
            this.radioButton_simpson.Text = "Симпсона";
            this.radioButton_simpson.UseVisualStyleBackColor = true;
            this.radioButton_simpson.CheckedChanged += new System.EventHandler(this.radioButton_simpson_CheckedChanged);
            // 
            // radioButton_triangle
            // 
            this.radioButton_triangle.AutoSize = true;
            this.radioButton_triangle.Location = new System.Drawing.Point(254, 32);
            this.radioButton_triangle.Name = "radioButton_triangle";
            this.radioButton_triangle.Size = new System.Drawing.Size(90, 17);
            this.radioButton_triangle.TabIndex = 4;
            this.radioButton_triangle.Text = "Треугольное";
            this.radioButton_triangle.UseVisualStyleBackColor = true;
            this.radioButton_triangle.CheckedChanged += new System.EventHandler(this.radioButton_triangle_CheckedChanged);
            // 
            // radioButton_gamma
            // 
            this.radioButton_gamma.AutoSize = true;
            this.radioButton_gamma.Location = new System.Drawing.Point(113, 55);
            this.radioButton_gamma.Name = "radioButton_gamma";
            this.radioButton_gamma.Size = new System.Drawing.Size(140, 17);
            this.radioButton_gamma.TabIndex = 3;
            this.radioButton_gamma.Text = "Гамма-распределение";
            this.radioButton_gamma.UseVisualStyleBackColor = true;
            this.radioButton_gamma.CheckedChanged += new System.EventHandler(this.radioButton_gamma_CheckedChanged);
            // 
            // radioButton_exp
            // 
            this.radioButton_exp.AutoSize = true;
            this.radioButton_exp.Location = new System.Drawing.Point(113, 32);
            this.radioButton_exp.Name = "radioButton_exp";
            this.radioButton_exp.Size = new System.Drawing.Size(122, 17);
            this.radioButton_exp.TabIndex = 2;
            this.radioButton_exp.Text = "Экспоненциальное";
            this.radioButton_exp.UseVisualStyleBackColor = true;
            this.radioButton_exp.CheckedChanged += new System.EventHandler(this.radioButton_exp_CheckedChanged);
            // 
            // radioButton_gauss
            // 
            this.radioButton_gauss.AutoSize = true;
            this.radioButton_gauss.Location = new System.Drawing.Point(13, 55);
            this.radioButton_gauss.Name = "radioButton_gauss";
            this.radioButton_gauss.Size = new System.Drawing.Size(90, 17);
            this.radioButton_gauss.TabIndex = 1;
            this.radioButton_gauss.Text = "Гауссовское";
            this.radioButton_gauss.UseVisualStyleBackColor = true;
            this.radioButton_gauss.CheckedChanged += new System.EventHandler(this.radioButton_gauss_CheckedChanged);
            // 
            // radioButton_uniform
            // 
            this.radioButton_uniform.AutoSize = true;
            this.radioButton_uniform.Location = new System.Drawing.Point(13, 32);
            this.radioButton_uniform.Name = "radioButton_uniform";
            this.radioButton_uniform.Size = new System.Drawing.Size(94, 17);
            this.radioButton_uniform.TabIndex = 0;
            this.radioButton_uniform.Text = "Равномерное";
            this.radioButton_uniform.UseVisualStyleBackColor = true;
            this.radioButton_uniform.CheckedChanged += new System.EventHandler(this.radioButton_uniform_CheckedChanged);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.IsEnableHPan = false;
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVPan = false;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.IsShowContextMenu = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(213, 125);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(707, 268);
            this.zedGraphControl1.TabIndex = 16;
            this.zedGraphControl1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(581, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 96);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(216, 59);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 7;
            this.textBox4.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(216, 32);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(57, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // calculate_button
            // 
            this.calculate_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.calculate_button.Location = new System.Drawing.Point(12, 408);
            this.calculate_button.Name = "calculate_button";
            this.calculate_button.Size = new System.Drawing.Size(183, 47);
            this.calculate_button.TabIndex = 17;
            this.calculate_button.Text = "Генерировать";
            this.calculate_button.UseVisualStyleBackColor = false;
            this.calculate_button.Click += new System.EventHandler(this.calculate_button_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_sko);
            this.groupBox3.Controls.Add(this.textBox_Dx);
            this.groupBox3.Controls.Add(this.textBox_Mx);
            this.groupBox3.Controls.Add(this.label_sko);
            this.groupBox3.Controls.Add(this.labelDx);
            this.groupBox3.Controls.Add(this.labelMx);
            this.groupBox3.Location = new System.Drawing.Point(213, 403);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(554, 52);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Вероятностные характеристики";
            // 
            // textBox_sko
            // 
            this.textBox_sko.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_sko.Location = new System.Drawing.Point(400, 21);
            this.textBox_sko.Name = "textBox_sko";
            this.textBox_sko.ReadOnly = true;
            this.textBox_sko.Size = new System.Drawing.Size(140, 20);
            this.textBox_sko.TabIndex = 11;
            // 
            // textBox_Dx
            // 
            this.textBox_Dx.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Dx.Location = new System.Drawing.Point(222, 21);
            this.textBox_Dx.Name = "textBox_Dx";
            this.textBox_Dx.ReadOnly = true;
            this.textBox_Dx.Size = new System.Drawing.Size(140, 20);
            this.textBox_Dx.TabIndex = 10;
            // 
            // textBox_Mx
            // 
            this.textBox_Mx.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Mx.Location = new System.Drawing.Point(45, 21);
            this.textBox_Mx.Name = "textBox_Mx";
            this.textBox_Mx.ReadOnly = true;
            this.textBox_Mx.Size = new System.Drawing.Size(140, 20);
            this.textBox_Mx.TabIndex = 9;
            // 
            // label_sko
            // 
            this.label_sko.AutoSize = true;
            this.label_sko.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sko.Location = new System.Drawing.Point(370, 22);
            this.label_sko.Name = "label_sko";
            this.label_sko.Size = new System.Drawing.Size(32, 17);
            this.label_sko.TabIndex = 8;
            this.label_sko.Text = "σ = ";
            // 
            // labelDx
            // 
            this.labelDx.AutoSize = true;
            this.labelDx.Location = new System.Drawing.Point(191, 24);
            this.labelDx.Name = "labelDx";
            this.labelDx.Size = new System.Drawing.Size(32, 13);
            this.labelDx.TabIndex = 7;
            this.labelDx.Text = "Dx = ";
            // 
            // labelMx
            // 
            this.labelMx.AutoSize = true;
            this.labelMx.Location = new System.Drawing.Point(14, 24);
            this.labelMx.Name = "labelMx";
            this.labelMx.Size = new System.Drawing.Size(33, 13);
            this.labelMx.TabIndex = 6;
            this.labelMx.Text = "Mx = ";
            // 
            // distNameLabel
            // 
            this.distNameLabel.AutoSize = true;
            this.distNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.distNameLabel.Location = new System.Drawing.Point(521, 7);
            this.distNameLabel.Name = "distNameLabel";
            this.distNameLabel.Size = new System.Drawing.Size(0, 20);
            this.distNameLabel.TabIndex = 20;
            this.distNameLabel.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_R0);
            this.groupBox4.Controls.Add(this.textBox_m);
            this.groupBox4.Controls.Add(this.textBox_a);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(183, 96);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры алгоритма Лемера";
            // 
            // textBox_R0
            // 
            this.textBox_R0.Location = new System.Drawing.Point(40, 71);
            this.textBox_R0.Name = "textBox_R0";
            this.textBox_R0.Size = new System.Drawing.Size(100, 20);
            this.textBox_R0.TabIndex = 5;
            this.textBox_R0.Text = "846";
            // 
            // textBox_m
            // 
            this.textBox_m.Location = new System.Drawing.Point(40, 45);
            this.textBox_m.Name = "textBox_m";
            this.textBox_m.Size = new System.Drawing.Size(100, 20);
            this.textBox_m.TabIndex = 4;
            this.textBox_m.Text = "7108";
            // 
            // textBox_a
            // 
            this.textBox_a.Location = new System.Drawing.Point(40, 19);
            this.textBox_a.Name = "textBox_a";
            this.textBox_a.Size = new System.Drawing.Size(100, 20);
            this.textBox_a.TabIndex = 3;
            this.textBox_a.Text = "634";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "X0:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "m:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "a:";
            // 
            // dgvRes
            // 
            this.dgvRes.AllowUserToAddRows = false;
            this.dgvRes.AllowUserToDeleteRows = false;
            this.dgvRes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Res});
            this.dgvRes.GridColor = System.Drawing.SystemColors.Window;
            this.dgvRes.Location = new System.Drawing.Point(13, 125);
            this.dgvRes.Name = "dgvRes";
            this.dgvRes.ReadOnly = true;
            this.dgvRes.RowHeadersVisible = false;
            this.dgvRes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRes.Size = new System.Drawing.Size(182, 268);
            this.dgvRes.TabIndex = 23;
            // 
            // Res
            // 
            this.Res.Frozen = true;
            this.Res.HeaderText = "РРСЧ";
            this.Res.Name = "Res";
            this.Res.ReadOnly = true;
            this.Res.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Res.Width = 180;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbEvidence);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(779, 404);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(141, 51);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Косвенные признаки";
            // 
            // tbEvidence
            // 
            this.tbEvidence.Location = new System.Drawing.Point(62, 21);
            this.tbEvidence.Name = "tbEvidence";
            this.tbEvidence.Size = new System.Drawing.Size(69, 20);
            this.tbEvidence.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "2K/N =";
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(lab2.Form1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(937, 467);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dgvRes);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.distNameLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.calculate_button);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRes)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_simpson;
        private System.Windows.Forms.RadioButton radioButton_triangle;
        private System.Windows.Forms.RadioButton radioButton_gamma;
        private System.Windows.Forms.RadioButton radioButton_exp;
        private System.Windows.Forms.RadioButton radioButton_gauss;
        private System.Windows.Forms.RadioButton radioButton_uniform;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button calculate_button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_sko;
        private System.Windows.Forms.TextBox textBox_Dx;
        private System.Windows.Forms.TextBox textBox_Mx;
        private System.Windows.Forms.Label label_sko;
        private System.Windows.Forms.Label labelDx;
        private System.Windows.Forms.Label labelMx;
        private System.Windows.Forms.Label distNameLabel;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_R0;
        private System.Windows.Forms.TextBox textBox_m;
        private System.Windows.Forms.TextBox textBox_a;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.DataGridView dgvRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Res;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbEvidence;
        private System.Windows.Forms.Label label8;
    }
}

