namespace iCantine.Views
{
    partial class FormMenu
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
            this.listBoxTime = new System.Windows.Forms.ListBox();
            this.listBoxPlate = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxExtra = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxMenu = new System.Windows.Forms.ListBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCreateMenu = new System.Windows.Forms.Button();
            this.buttonDeleteMenu = new System.Windows.Forms.Button();
            this.comboBoxPlateType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Criar Menus";
            // 
            // listBoxTime
            // 
            this.listBoxTime.FormattingEnabled = true;
            this.listBoxTime.Location = new System.Drawing.Point(18, 79);
            this.listBoxTime.Name = "listBoxTime";
            this.listBoxTime.Size = new System.Drawing.Size(125, 316);
            this.listBoxTime.TabIndex = 1;
            // 
            // listBoxPlate
            // 
            this.listBoxPlate.FormattingEnabled = true;
            this.listBoxPlate.Location = new System.Drawing.Point(149, 105);
            this.listBoxPlate.Name = "listBoxPlate";
            this.listBoxPlate.Size = new System.Drawing.Size(193, 290);
            this.listBoxPlate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(14, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Horas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(149, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pratos";
            // 
            // listBoxExtra
            // 
            this.listBoxExtra.FormattingEnabled = true;
            this.listBoxExtra.Location = new System.Drawing.Point(348, 79);
            this.listBoxExtra.Name = "listBoxExtra";
            this.listBoxExtra.Size = new System.Drawing.Size(193, 316);
            this.listBoxExtra.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(344, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Extras";
            // 
            // listBoxMenu
            // 
            this.listBoxMenu.FormattingEnabled = true;
            this.listBoxMenu.Location = new System.Drawing.Point(547, 79);
            this.listBoxMenu.Name = "listBoxMenu";
            this.listBoxMenu.Size = new System.Drawing.Size(193, 316);
            this.listBoxMenu.TabIndex = 7;
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(18, 402);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(125, 36);
            this.buttonBack.TabIndex = 8;
            this.buttonBack.Text = "Voltar";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(543, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Menus";
            // 
            // buttonCreateMenu
            // 
            this.buttonCreateMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateMenu.Location = new System.Drawing.Point(416, 401);
            this.buttonCreateMenu.Name = "buttonCreateMenu";
            this.buttonCreateMenu.Size = new System.Drawing.Size(125, 36);
            this.buttonCreateMenu.TabIndex = 10;
            this.buttonCreateMenu.Text = "Criar Menu";
            this.buttonCreateMenu.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteMenu
            // 
            this.buttonDeleteMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteMenu.Location = new System.Drawing.Point(615, 402);
            this.buttonDeleteMenu.Name = "buttonDeleteMenu";
            this.buttonDeleteMenu.Size = new System.Drawing.Size(125, 36);
            this.buttonDeleteMenu.TabIndex = 11;
            this.buttonDeleteMenu.Text = "Eliminar";
            this.buttonDeleteMenu.UseVisualStyleBackColor = true;
            // 
            // comboBoxPlateType
            // 
            this.comboBoxPlateType.FormattingEnabled = true;
            this.comboBoxPlateType.Location = new System.Drawing.Point(149, 79);
            this.comboBoxPlateType.Name = "comboBoxPlateType";
            this.comboBoxPlateType.Size = new System.Drawing.Size(193, 21);
            this.comboBoxPlateType.TabIndex = 12;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 450);
            this.Controls.Add(this.comboBoxPlateType);
            this.Controls.Add(this.buttonDeleteMenu);
            this.Controls.Add(this.buttonCreateMenu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.listBoxMenu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxExtra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxPlate);
            this.Controls.Add(this.listBoxTime);
            this.Controls.Add(this.label1);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxTime;
        private System.Windows.Forms.ListBox listBoxPlate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxExtra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxMenu;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCreateMenu;
        private System.Windows.Forms.Button buttonDeleteMenu;
        private System.Windows.Forms.ComboBox comboBoxPlateType;
    }
}