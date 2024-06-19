namespace iCantine.Views
{
    partial class FormBalance
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
            this.label2 = new System.Windows.Forms.Label();
            this.labelClient = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.numericBalance = new System.Windows.Forms.NumericUpDown();
            this.buttonCharge = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.buttonEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente:";
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClient.Location = new System.Drawing.Point(124, 58);
            this.labelClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(42, 16);
            this.labelClient.TabIndex = 18;
            this.labelClient.Text = "label";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 208);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Saldo Atual:";
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBalance.Location = new System.Drawing.Point(259, 212);
            this.labelBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(42, 16);
            this.labelBalance.TabIndex = 20;
            this.labelBalance.Text = "label";
            // 
            // numericBalance
            // 
            this.numericBalance.Location = new System.Drawing.Point(177, 106);
            this.numericBalance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericBalance.Name = "numericBalance";
            this.numericBalance.Size = new System.Drawing.Size(90, 20);
            this.numericBalance.TabIndex = 21;
            // 
            // buttonCharge
            // 
            this.buttonCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCharge.Location = new System.Drawing.Point(168, 130);
            this.buttonCharge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCharge.Name = "buttonCharge";
            this.buttonCharge.Size = new System.Drawing.Size(109, 40);
            this.buttonCharge.TabIndex = 22;
            this.buttonCharge.Text = "Carregar";
            this.buttonCharge.UseVisualStyleBackColor = true;
            this.buttonCharge.Click += new System.EventHandler(this.buttonCharge_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(363, 283);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(96, 39);
            this.buttonBack.TabIndex = 23;
            this.buttonBack.Text = "Voltar";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 24);
            this.label3.TabIndex = 24;
            this.label3.Text = "Funcionario:";
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmployee.Location = new System.Drawing.Point(174, 12);
            this.labelEmployee.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(42, 16);
            this.labelEmployee.TabIndex = 25;
            this.labelEmployee.Text = "label";
            // 
            // buttonEmployee
            // 
            this.buttonEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEmployee.Location = new System.Drawing.Point(327, 7);
            this.buttonEmployee.Name = "buttonEmployee";
            this.buttonEmployee.Size = new System.Drawing.Size(132, 41);
            this.buttonEmployee.TabIndex = 28;
            this.buttonEmployee.Text = "Funcionário";
            this.buttonEmployee.UseVisualStyleBackColor = true;
            this.buttonEmployee.Click += new System.EventHandler(this.buttonEmployee_Click);
            // 
            // FormBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 333);
            this.Controls.Add(this.buttonEmployee);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonCharge);
            this.Controls.Add(this.numericBalance);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormBalance";
            this.Text = "FormBalance";
            ((System.ComponentModel.ISupportInitialize)(this.numericBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.NumericUpDown numericBalance;
        private System.Windows.Forms.Button buttonCharge;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.Button buttonEmployee;
    }
}