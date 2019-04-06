namespace l7
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectDir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDirPath = new System.Windows.Forms.TextBox();
            this.folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.tbTerms = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetTerms = new System.Windows.Forms.Button();
            this.tbEssay = new System.Windows.Forms.TextBox();
            this.btnGetEssay = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Location = new System.Drawing.Point(206, 59);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(191, 23);
            this.btnSelectDir.TabIndex = 0;
            this.btnSelectDir.Text = "Обзор...";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выбор директории:";
            // 
            // tbDirPath
            // 
            this.tbDirPath.Enabled = false;
            this.tbDirPath.Location = new System.Drawing.Point(12, 33);
            this.tbDirPath.Name = "tbDirPath";
            this.tbDirPath.Size = new System.Drawing.Size(385, 20);
            this.tbDirPath.TabIndex = 2;
            // 
            // tbTerms
            // 
            this.tbTerms.Location = new System.Drawing.Point(12, 106);
            this.tbTerms.Multiline = true;
            this.tbTerms.Name = "tbTerms";
            this.tbTerms.Size = new System.Drawing.Size(385, 45);
            this.tbTerms.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Текущий каталог:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ключевые слова:";
            // 
            // btnGetTerms
            // 
            this.btnGetTerms.Location = new System.Drawing.Point(12, 157);
            this.btnGetTerms.Name = "btnGetTerms";
            this.btnGetTerms.Size = new System.Drawing.Size(385, 23);
            this.btnGetTerms.TabIndex = 6;
            this.btnGetTerms.Text = "Найти термины";
            this.btnGetTerms.UseVisualStyleBackColor = true;
            this.btnGetTerms.Click += new System.EventHandler(this.btnGetTerms_Click);
            // 
            // tbEssay
            // 
            this.tbEssay.Location = new System.Drawing.Point(12, 213);
            this.tbEssay.Multiline = true;
            this.tbEssay.Name = "tbEssay";
            this.tbEssay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbEssay.Size = new System.Drawing.Size(385, 279);
            this.tbEssay.TabIndex = 8;
            // 
            // btnGetEssay
            // 
            this.btnGetEssay.Location = new System.Drawing.Point(12, 498);
            this.btnGetEssay.Name = "btnGetEssay";
            this.btnGetEssay.Size = new System.Drawing.Size(385, 23);
            this.btnGetEssay.TabIndex = 9;
            this.btnGetEssay.Text = "Создать реферат";
            this.btnGetEssay.UseVisualStyleBackColor = true;
            this.btnGetEssay.Click += new System.EventHandler(this.btnGetEssay_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Реферат:";
            // 
            // tbSize
            // 
            this.tbSize.Location = new System.Drawing.Point(359, 187);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(37, 20);
            this.tbSize.TabIndex = 11;
            this.tbSize.Text = "100%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(243, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Величина реферата:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 536);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGetEssay);
            this.Controls.Add(this.tbEssay);
            this.Controls.Add(this.btnGetTerms);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTerms);
            this.Controls.Add(this.tbDirPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectDir);
            this.Name = "Form1";
            this.Text = "Автоматическое реферирование текста";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDirPath;
        private System.Windows.Forms.FolderBrowserDialog folderDlg;
        private System.Windows.Forms.TextBox tbTerms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetTerms;
        private System.Windows.Forms.TextBox tbEssay;
        private System.Windows.Forms.Button btnGetEssay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Label label5;
    }
}

