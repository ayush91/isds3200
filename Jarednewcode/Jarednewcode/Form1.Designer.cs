namespace Jarednewcode
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lstConvertFrom = new System.Windows.Forms.ListBox();
            this.lstConvertTo = new System.Windows.Forms.ListBox();
            this.lblSolution = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // lstConvertFrom
            // 
            this.lstConvertFrom.FormattingEnabled = true;
            this.lstConvertFrom.Items.AddRange(new object[] {
            "Yard",
            "Foot",
            "Inches"});
            this.lstConvertFrom.Location = new System.Drawing.Point(12, 175);
            this.lstConvertFrom.Name = "lstConvertFrom";
            this.lstConvertFrom.Size = new System.Drawing.Size(120, 95);
            this.lstConvertFrom.TabIndex = 3;
            // 
            // lstConvertTo
            // 
            this.lstConvertTo.FormattingEnabled = true;
            this.lstConvertTo.Items.AddRange(new object[] {
            "Yard",
            "Foot",
            "Inches"});
            this.lstConvertTo.Location = new System.Drawing.Point(287, 175);
            this.lstConvertTo.Name = "lstConvertTo";
            this.lstConvertTo.Size = new System.Drawing.Size(120, 95);
            this.lstConvertTo.TabIndex = 4;
            // 
            // lblSolution
            // 
            this.lblSolution.AutoSize = true;
            this.lblSolution.Location = new System.Drawing.Point(200, 309);
            this.lblSolution.Name = "lblSolution";
            this.lblSolution.Size = new System.Drawing.Size(35, 13);
            this.lblSolution.TabIndex = 5;
            this.lblSolution.Text = "label2";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(203, 345);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "button1";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 415);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.lblSolution);
            this.Controls.Add(this.lstConvertTo);
            this.Controls.Add(this.lstConvertFrom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lstConvertFrom;
        private System.Windows.Forms.ListBox lstConvertTo;
        private System.Windows.Forms.Label lblSolution;
        private System.Windows.Forms.Button btnConvert;
    }
}

