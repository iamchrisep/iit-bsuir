namespace Lab6
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
            this.addTopicButton = new System.Windows.Forms.Button();
            this.newTopicTextBox = new System.Windows.Forms.TextBox();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.topicComboBox = new System.Windows.Forms.ComboBox();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addTopicButton
            // 
            this.addTopicButton.Location = new System.Drawing.Point(9, 10);
            this.addTopicButton.Margin = new System.Windows.Forms.Padding(2);
            this.addTopicButton.Name = "addTopicButton";
            this.addTopicButton.Size = new System.Drawing.Size(122, 31);
            this.addTopicButton.TabIndex = 0;
            this.addTopicButton.Text = "Добавить тему";
            this.addTopicButton.UseVisualStyleBackColor = true;
            this.addTopicButton.Click += new System.EventHandler(this.addTopicButton_Click);
            // 
            // newTopicTextBox
            // 
            this.newTopicTextBox.Location = new System.Drawing.Point(136, 16);
            this.newTopicTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.newTopicTextBox.Name = "newTopicTextBox";
            this.newTopicTextBox.Size = new System.Drawing.Size(101, 20);
            this.newTopicTextBox.TabIndex = 1;
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(9, 46);
            this.loadFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(122, 31);
            this.loadFileButton.TabIndex = 2;
            this.loadFileButton.Text = "Добавить пример";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // topicComboBox
            // 
            this.topicComboBox.FormattingEnabled = true;
            this.topicComboBox.Location = new System.Drawing.Point(136, 52);
            this.topicComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.topicComboBox.Name = "topicComboBox";
            this.topicComboBox.Size = new System.Drawing.Size(101, 21);
            this.topicComboBox.TabIndex = 4;
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(9, 81);
            this.analyzeButton.Margin = new System.Windows.Forms.Padding(2);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(122, 33);
            this.analyzeButton.TabIndex = 5;
            this.analyzeButton.Text = "Классифицировать";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(149, 101);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 152);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.topicComboBox);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.newTopicTextBox);
            this.Controls.Add(this.addTopicButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Lab6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addTopicButton;
        private System.Windows.Forms.TextBox newTopicTextBox;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.ComboBox topicComboBox;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Label resultLabel;
    }
}

