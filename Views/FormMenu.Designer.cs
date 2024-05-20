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
            this.labelUsername = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxPriceStudent = new System.Windows.Forms.TextBox();
            this.textBoxPriceProfessor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonEditMenu = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
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
            this.listBoxTime.Location = new System.Drawing.Point(18, 92);
            this.listBoxTime.Name = "listBoxTime";
            this.listBoxTime.Size = new System.Drawing.Size(125, 264);
            this.listBoxTime.TabIndex = 1;
            this.listBoxTime.SelectedIndexChanged += new System.EventHandler(this.listBoxTime_SelectedIndexChanged);
            // 
            // listBoxPlate
            // 
            this.listBoxPlate.FormattingEnabled = true;
            this.listBoxPlate.Location = new System.Drawing.Point(149, 118);
            this.listBoxPlate.Name = "listBoxPlate";
            this.listBoxPlate.Size = new System.Drawing.Size(125, 238);
            this.listBoxPlate.TabIndex = 2;
            this.listBoxPlate.SelectedIndexChanged += new System.EventHandler(this.listBoxPlate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(14, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Horas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(149, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pratos";
            // 
            // listBoxExtra
            // 
            this.listBoxExtra.FormattingEnabled = true;
            this.listBoxExtra.Location = new System.Drawing.Point(281, 92);
            this.listBoxExtra.Name = "listBoxExtra";
            this.listBoxExtra.Size = new System.Drawing.Size(125, 264);
            this.listBoxExtra.TabIndex = 5;
            this.listBoxExtra.SelectedIndexChanged += new System.EventHandler(this.listBoxExtra_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(277, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Extras";
            // 
            // listBoxMenu
            // 
            this.listBoxMenu.FormattingEnabled = true;
            this.listBoxMenu.Location = new System.Drawing.Point(412, 93);
            this.listBoxMenu.Name = "listBoxMenu";
            this.listBoxMenu.Size = new System.Drawing.Size(193, 316);
            this.listBoxMenu.TabIndex = 7;
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(18, 415);
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
            this.label5.Location = new System.Drawing.Point(408, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Menus";
            // 
            // buttonCreateMenu
            // 
            this.buttonCreateMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateMenu.Location = new System.Drawing.Point(149, 415);
            this.buttonCreateMenu.Name = "buttonCreateMenu";
            this.buttonCreateMenu.Size = new System.Drawing.Size(125, 36);
            this.buttonCreateMenu.TabIndex = 10;
            this.buttonCreateMenu.Text = "Adicionar";
            this.buttonCreateMenu.UseVisualStyleBackColor = true;
            this.buttonCreateMenu.Click += new System.EventHandler(this.buttonCreateMenu_Click);
            // 
            // buttonDeleteMenu
            // 
            this.buttonDeleteMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteMenu.Location = new System.Drawing.Point(412, 415);
            this.buttonDeleteMenu.Name = "buttonDeleteMenu";
            this.buttonDeleteMenu.Size = new System.Drawing.Size(125, 36);
            this.buttonDeleteMenu.TabIndex = 11;
            this.buttonDeleteMenu.Text = "Eliminar";
            this.buttonDeleteMenu.UseVisualStyleBackColor = true;
            // 
            // comboBoxPlateType
            // 
            this.comboBoxPlateType.FormattingEnabled = true;
            this.comboBoxPlateType.Location = new System.Drawing.Point(149, 92);
            this.comboBoxPlateType.Name = "comboBoxPlateType";
            this.comboBoxPlateType.Size = new System.Drawing.Size(125, 21);
            this.comboBoxPlateType.TabIndex = 12;
            this.comboBoxPlateType.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlateType_SelectedIndexChanged);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(408, 15);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(105, 24);
            this.labelUsername.TabIndex = 13;
            this.labelUsername.Text = "Username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(15, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Quantidade";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(146, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Preço Estudante";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(18, 389);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(125, 20);
            this.textBoxQuantity.TabIndex = 16;
            // 
            // textBoxPriceStudent
            // 
            this.textBoxPriceStudent.Location = new System.Drawing.Point(149, 389);
            this.textBoxPriceStudent.Name = "textBoxPriceStudent";
            this.textBoxPriceStudent.Size = new System.Drawing.Size(125, 20);
            this.textBoxPriceStudent.TabIndex = 17;
            // 
            // textBoxPriceProfessor
            // 
            this.textBoxPriceProfessor.Location = new System.Drawing.Point(281, 389);
            this.textBoxPriceProfessor.Name = "textBoxPriceProfessor";
            this.textBoxPriceProfessor.Size = new System.Drawing.Size(125, 20);
            this.textBoxPriceProfessor.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(277, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Preço Professor";
            // 
            // buttonEditMenu
            // 
            this.buttonEditMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditMenu.Location = new System.Drawing.Point(281, 415);
            this.buttonEditMenu.Name = "buttonEditMenu";
            this.buttonEditMenu.Size = new System.Drawing.Size(125, 36);
            this.buttonEditMenu.TabIndex = 20;
            this.buttonEditMenu.Text = "Editar";
            this.buttonEditMenu.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(18, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 482);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonEditMenu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPriceProfessor);
            this.Controls.Add(this.textBoxPriceStudent);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelUsername);
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
            this.Load += new System.EventHandler(this.FormMenu_Load);
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
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.TextBox textBoxPriceStudent;
        private System.Windows.Forms.TextBox textBoxPriceProfessor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonEditMenu;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}