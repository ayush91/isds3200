namespace Project2
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
            this.Balance = new System.Windows.Forms.Label();
            this.Amount = new System.Windows.Forms.Label();
            this.Money = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Withdraw = new System.Windows.Forms.Button();
            this.Deposit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Balance
            // 
            this.Balance.AutoSize = true;
            this.Balance.Location = new System.Drawing.Point(45, 40);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(46, 13);
            this.Balance.TabIndex = 0;
            this.Balance.Text = "Balance";
            // 
            // Amount
            // 
            this.Amount.AutoSize = true;
            this.Amount.Location = new System.Drawing.Point(48, 88);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(43, 13);
            this.Amount.TabIndex = 1;
            this.Amount.Text = "Amount";
            // 
            // Money
            // 
            this.Money.AutoSize = true;
            this.Money.Location = new System.Drawing.Point(190, 40);
            this.Money.Name = "Money";
            this.Money.Size = new System.Drawing.Size(52, 13);
            this.Money.TabIndex = 2;
            this.Money.Text = "$1000.00";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // Withdraw
            // 
            this.Withdraw.Location = new System.Drawing.Point(76, 237);
            this.Withdraw.Name = "Withdraw";
            this.Withdraw.Size = new System.Drawing.Size(75, 23);
            this.Withdraw.TabIndex = 4;
            this.Withdraw.Text = "Withdraw";
            this.Withdraw.UseVisualStyleBackColor = true;
            this.Withdraw.Click += new System.EventHandler(this.Withdraw_Click);
            // 
            // Deposit
            // 
            this.Deposit.Location = new System.Drawing.Point(193, 237);
            this.Deposit.Name = "Deposit";
            this.Deposit.Size = new System.Drawing.Size(75, 23);
            this.Deposit.TabIndex = 5;
            this.Deposit.Text = "Deposit";
            this.Deposit.UseVisualStyleBackColor = true;
            this.Deposit.Click += new System.EventHandler(this.Deposit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 319);
            this.Controls.Add(this.Deposit);
            this.Controls.Add(this.Withdraw);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Money);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.Balance);
            this.Name = "Form1";
            this.Text = "Bank";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Balance;
        private System.Windows.Forms.Label Amount;
        private System.Windows.Forms.Label Money;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Withdraw;
        private System.Windows.Forms.Button Deposit;
    }
}

