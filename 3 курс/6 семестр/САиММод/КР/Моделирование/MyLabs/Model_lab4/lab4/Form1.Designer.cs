namespace lab4
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
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.gbInputParams = new System.Windows.Forms.GroupBox();
            this.textBox_queue1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ch1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_queue2 = new System.Windows.Forms.TextBox();
            this.textBox_ch2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_λmax = new System.Windows.Forms.TextBox();
            this.textBox_λmin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_step = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_intensity = new System.Windows.Forms.TextBox();
            this.gbOutputParams = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_denialCount1 = new System.Windows.Forms.Label();
            this.label_denial = new System.Windows.Forms.Label();
            this.textBox_denial1 = new System.Windows.Forms.TextBox();
            this.textBox_denial2 = new System.Windows.Forms.TextBox();
            this.textBox_denial = new System.Windows.Forms.TextBox();
            this.tbdenialCount1 = new System.Windows.Forms.TextBox();
            this.tbdenialCount2 = new System.Windows.Forms.TextBox();
            this.tbdenialCount = new System.Windows.Forms.TextBox();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.gbInputParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbOutputParams.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSimulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSimulate.Location = new System.Drawing.Point(12, 359);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(477, 33);
            this.buttonSimulate.TabIndex = 1;
            this.buttonSimulate.Text = "ПУСК";
            this.buttonSimulate.UseVisualStyleBackColor = false;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // gbInputParams
            // 
            this.gbInputParams.Controls.Add(this.textBox_queue1);
            this.gbInputParams.Controls.Add(this.textBox_ch1);
            this.gbInputParams.Controls.Add(this.textBox_intensity);
            this.gbInputParams.Controls.Add(this.textBox_number);
            this.gbInputParams.Controls.Add(this.label1);
            this.gbInputParams.Controls.Add(this.label2);
            this.gbInputParams.Controls.Add(this.textBox_ch2);
            this.gbInputParams.Controls.Add(this.textBox_step);
            this.gbInputParams.Controls.Add(this.label11);
            this.gbInputParams.Controls.Add(this.textBox_λmax);
            this.gbInputParams.Controls.Add(this.textBox_λmin);
            this.gbInputParams.Controls.Add(this.label10);
            this.gbInputParams.Controls.Add(this.label16);
            this.gbInputParams.Controls.Add(this.pictureBox1);
            this.gbInputParams.Controls.Add(this.label4);
            this.gbInputParams.Controls.Add(this.label3);
            this.gbInputParams.Controls.Add(this.label6);
            this.gbInputParams.Controls.Add(this.textBox_queue2);
            this.gbInputParams.Controls.Add(this.label5);
            this.gbInputParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbInputParams.Location = new System.Drawing.Point(12, 3);
            this.gbInputParams.Name = "gbInputParams";
            this.gbInputParams.Size = new System.Drawing.Size(477, 208);
            this.gbInputParams.TabIndex = 21;
            this.gbInputParams.TabStop = false;
            this.gbInputParams.Text = "Исходные данные:";
            // 
            // textBox_queue1
            // 
            this.textBox_queue1.Location = new System.Drawing.Point(96, 107);
            this.textBox_queue1.Name = "textBox_queue1";
            this.textBox_queue1.Size = new System.Drawing.Size(59, 24);
            this.textBox_queue1.TabIndex = 19;
            this.textBox_queue1.Text = "2";
            this.textBox_queue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "n1:";
            // 
            // textBox_ch1
            // 
            this.textBox_ch1.Location = new System.Drawing.Point(96, 133);
            this.textBox_ch1.Name = "textBox_ch1";
            this.textBox_ch1.Size = new System.Drawing.Size(59, 24);
            this.textBox_ch1.TabIndex = 17;
            this.textBox_ch1.Text = "5,0";
            this.textBox_ch1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "μ1:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "μ2:";
            // 
            // textBox_queue2
            // 
            this.textBox_queue2.Location = new System.Drawing.Point(203, 107);
            this.textBox_queue2.Name = "textBox_queue2";
            this.textBox_queue2.Size = new System.Drawing.Size(59, 24);
            this.textBox_queue2.TabIndex = 23;
            this.textBox_queue2.Text = "2";
            this.textBox_queue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_ch2
            // 
            this.textBox_ch2.Location = new System.Drawing.Point(203, 133);
            this.textBox_ch2.Name = "textBox_ch2";
            this.textBox_ch2.Size = new System.Drawing.Size(59, 24);
            this.textBox_ch2.TabIndex = 21;
            this.textBox_ch2.Text = "5,0";
            this.textBox_ch2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 18);
            this.label5.TabIndex = 22;
            this.label5.Text = "n2:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Image = global::lab4.Properties.Resources.Схема;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(461, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(74, 175);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 18);
            this.label16.TabIndex = 25;
            this.label16.Text = "λ изменяется от ";
            // 
            // textBox_λmax
            // 
            this.textBox_λmax.Location = new System.Drawing.Point(266, 174);
            this.textBox_λmax.Name = "textBox_λmax";
            this.textBox_λmax.Size = new System.Drawing.Size(33, 24);
            this.textBox_λmax.TabIndex = 28;
            this.textBox_λmax.Text = "6";
            this.textBox_λmax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_λmin
            // 
            this.textBox_λmin.Location = new System.Drawing.Point(196, 174);
            this.textBox_λmin.Name = "textBox_λmin";
            this.textBox_λmin.Size = new System.Drawing.Size(33, 24);
            this.textBox_λmin.TabIndex = 26;
            this.textBox_λmin.Text = "1";
            this.textBox_λmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(236, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 18);
            this.label10.TabIndex = 27;
            this.label10.Text = "до";
            // 
            // textBox_step
            // 
            this.textBox_step.Location = new System.Drawing.Point(369, 174);
            this.textBox_step.Name = "textBox_step";
            this.textBox_step.Size = new System.Drawing.Size(33, 24);
            this.textBox_step.TabIndex = 30;
            this.textBox_step.Text = "0,5";
            this.textBox_step.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(305, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 18);
            this.label11.TabIndex = 29;
            this.label11.Text = "с шагом          .";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "N:";
            // 
            // textBox_number
            // 
            this.textBox_number.Location = new System.Drawing.Point(308, 107);
            this.textBox_number.Name = "textBox_number";
            this.textBox_number.Size = new System.Drawing.Size(100, 24);
            this.textBox_number.TabIndex = 32;
            this.textBox_number.Text = "1000";
            this.textBox_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 18);
            this.label2.TabIndex = 33;
            this.label2.Text = "λ:";
            // 
            // textBox_intensity
            // 
            this.textBox_intensity.Location = new System.Drawing.Point(308, 133);
            this.textBox_intensity.Name = "textBox_intensity";
            this.textBox_intensity.Size = new System.Drawing.Size(100, 24);
            this.textBox_intensity.TabIndex = 34;
            this.textBox_intensity.Text = "5,0";
            this.textBox_intensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbOutputParams
            // 
            this.gbOutputParams.Controls.Add(this.groupBox1);
            this.gbOutputParams.Controls.Add(this.label_denial);
            this.gbOutputParams.Controls.Add(this.label_denialCount1);
            this.gbOutputParams.Controls.Add(this.groupBox3);
            this.gbOutputParams.Controls.Add(this.groupBox2);
            this.gbOutputParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbOutputParams.Location = new System.Drawing.Point(12, 222);
            this.gbOutputParams.Name = "gbOutputParams";
            this.gbOutputParams.Size = new System.Drawing.Size(477, 119);
            this.gbOutputParams.TabIndex = 22;
            this.gbOutputParams.TabStop = false;
            this.gbOutputParams.Text = "Выходные параметры:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbdenialCount1);
            this.groupBox1.Controls.Add(this.textBox_denial1);
            this.groupBox1.Location = new System.Drawing.Point(91, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "gbOutputParams";
            this.groupBox1.Text = "Первая фаза:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbdenialCount2);
            this.groupBox2.Controls.Add(this.textBox_denial2);
            this.groupBox2.Location = new System.Drawing.Point(215, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 84);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "gbOutputParams";
            this.groupBox2.Text = "Вторая фаза:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbdenialCount);
            this.groupBox3.Controls.Add(this.textBox_denial);
            this.groupBox3.Location = new System.Drawing.Point(344, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 84);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "gbOutputParams";
            this.groupBox3.Text = "СМО:";
            // 
            // label_denialCount1
            // 
            this.label_denialCount1.AutoSize = true;
            this.label_denialCount1.Location = new System.Drawing.Point(10, 48);
            this.label_denialCount1.Name = "label_denialCount1";
            this.label_denialCount1.Size = new System.Drawing.Size(84, 18);
            this.label_denialCount1.TabIndex = 10;
            this.label_denialCount1.Text = "N отказов:";
            // 
            // label_denial
            // 
            this.label_denial.AutoSize = true;
            this.label_denial.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label_denial.Location = new System.Drawing.Point(48, 76);
            this.label_denial.Name = "label_denial";
            this.label_denial.Size = new System.Drawing.Size(46, 18);
            this.label_denial.TabIndex = 11;
            this.label_denial.Text = "Pотк:";
            // 
            // textBox_denial1
            // 
            this.textBox_denial1.Location = new System.Drawing.Point(8, 50);
            this.textBox_denial1.Name = "textBox_denial1";
            this.textBox_denial1.ReadOnly = true;
            this.textBox_denial1.Size = new System.Drawing.Size(105, 24);
            this.textBox_denial1.TabIndex = 12;
            // 
            // textBox_denial2
            // 
            this.textBox_denial2.Location = new System.Drawing.Point(8, 50);
            this.textBox_denial2.Name = "textBox_denial2";
            this.textBox_denial2.ReadOnly = true;
            this.textBox_denial2.Size = new System.Drawing.Size(105, 24);
            this.textBox_denial2.TabIndex = 19;
            // 
            // textBox_denial
            // 
            this.textBox_denial.Location = new System.Drawing.Point(8, 50);
            this.textBox_denial.Name = "textBox_denial";
            this.textBox_denial.ReadOnly = true;
            this.textBox_denial.Size = new System.Drawing.Size(105, 24);
            this.textBox_denial.TabIndex = 22;
            // 
            // tbdenialCount1
            // 
            this.tbdenialCount1.Location = new System.Drawing.Point(8, 23);
            this.tbdenialCount1.Name = "tbdenialCount1";
            this.tbdenialCount1.ReadOnly = true;
            this.tbdenialCount1.Size = new System.Drawing.Size(105, 24);
            this.tbdenialCount1.TabIndex = 13;
            // 
            // tbdenialCount2
            // 
            this.tbdenialCount2.Location = new System.Drawing.Point(8, 23);
            this.tbdenialCount2.Name = "tbdenialCount2";
            this.tbdenialCount2.ReadOnly = true;
            this.tbdenialCount2.Size = new System.Drawing.Size(105, 24);
            this.tbdenialCount2.TabIndex = 14;
            // 
            // tbdenialCount
            // 
            this.tbdenialCount.Location = new System.Drawing.Point(8, 23);
            this.tbdenialCount.Name = "tbdenialCount";
            this.tbdenialCount.ReadOnly = true;
            this.tbdenialCount.Size = new System.Drawing.Size(105, 24);
            this.tbdenialCount.TabIndex = 20;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(509, 12);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(496, 380);
            this.zedGraphControl.TabIndex = 25;
            this.zedGraphControl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1016, 401);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.gbOutputParams);
            this.Controls.Add(this.gbInputParams);
            this.Controls.Add(this.buttonSimulate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №4";
            this.gbInputParams.ResumeLayout(false);
            this.gbInputParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbOutputParams.ResumeLayout(false);
            this.gbOutputParams.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.GroupBox gbInputParams;
        private System.Windows.Forms.TextBox textBox_step;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_λmax;
        private System.Windows.Forms.TextBox textBox_λmin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_queue1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ch1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_queue2;
        private System.Windows.Forms.TextBox textBox_ch2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_intensity;
        private System.Windows.Forms.TextBox textBox_number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbOutputParams;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_denialCount1;
        private System.Windows.Forms.Label label_denial;
        private System.Windows.Forms.TextBox textBox_denial1;
        private System.Windows.Forms.TextBox tbdenialCount1;
        private System.Windows.Forms.TextBox tbdenialCount;
        private System.Windows.Forms.TextBox textBox_denial;
        private System.Windows.Forms.TextBox tbdenialCount2;
        private System.Windows.Forms.TextBox textBox_denial2;
        private ZedGraph.ZedGraphControl zedGraphControl;
    }
}

