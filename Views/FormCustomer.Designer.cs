namespace iCantine.Views
{
    partial class FormCustomer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonProfessor = new System.Windows.Forms.RadioButton();
            this.radioButtonStudent = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNIF = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNumStudent = new System.Windows.Forms.Label();
            this.textBoxNumStudent = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonBalance = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.comboBoxFilters = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clientes:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonProfessor);
            this.groupBox1.Controls.Add(this.radioButtonStudent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNIF);
            this.groupBox1.Controls.Add(this.textBoxEmail);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labelNumStudent);
            this.groupBox1.Controls.Add(this.textBoxNumStudent);
            this.groupBox1.Location = new System.Drawing.Point(346, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 250);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonProfessor
            // 
            this.radioButtonProfessor.AutoSize = true;
            this.radioButtonProfessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonProfessor.Location = new System.Drawing.Point(217, 21);
            this.radioButtonProfessor.Name = "radioButtonProfessor";
            this.radioButtonProfessor.Size = new System.Drawing.Size(100, 24);
            this.radioButtonProfessor.TabIndex = 21;
            this.radioButtonProfessor.TabStop = true;
            this.radioButtonProfessor.Text = "Docente";
            this.radioButtonProfessor.UseVisualStyleBackColor = true;
            this.radioButtonProfessor.CheckedChanged += new System.EventHandler(this.radioButtonProfessor_CheckedChanged);
            // 
            // radioButtonStudent
            // 
            this.radioButtonStudent.AutoSize = true;
            this.radioButtonStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonStudent.Location = new System.Drawing.Point(6, 21);
            this.radioButtonStudent.Name = "radioButtonStudent";
            this.radioButtonStudent.Size = new System.Drawing.Size(114, 24);
            this.radioButtonStudent.TabIndex = 20;
            this.radioButtonStudent.TabStop = true;
            this.radioButtonStudent.Text = "Estudante";
            this.radioButtonStudent.UseVisualStyleBackColor = true;
            this.radioButtonStudent.CheckedChanged += new System.EventHandler(this.radioButtonStudent_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "NIF:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "E-mail:";
            // 
            // textBoxNIF
            // 
            this.textBoxNIF.Location = new System.Drawing.Point(94, 125);
            this.textBoxNIF.Name = "textBoxNIF";
            this.textBoxNIF.ReadOnly = true;
            this.textBoxNIF.Size = new System.Drawing.Size(173, 22);
            this.textBoxNIF.TabIndex = 18;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(94, 221);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.ReadOnly = true;
            this.textBoxEmail.Size = new System.Drawing.Size(173, 22);
            this.textBoxEmail.TabIndex = 15;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(94, 77);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(173, 22);
            this.textBoxName.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nome:";
            // 
            // labelNumStudent
            // 
            this.labelNumStudent.AutoSize = true;
            this.labelNumStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumStudent.Location = new System.Drawing.Point(90, 150);
            this.labelNumStudent.Name = "labelNumStudent";
            this.labelNumStudent.Size = new System.Drawing.Size(194, 20);
            this.labelNumStudent.TabIndex = 12;
            this.labelNumStudent.Text = "Número de estudante:";
            // 
            // textBoxNumStudent
            // 
            this.textBoxNumStudent.Location = new System.Drawing.Point(94, 173);
            this.textBoxNumStudent.Name = "textBoxNumStudent";
            this.textBoxNumStudent.ReadOnly = true;
            this.textBoxNumStudent.Size = new System.Drawing.Size(173, 22);
            this.textBoxNumStudent.TabIndex = 14;
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(17, 399);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(96, 39);
            this.buttonBack.TabIndex = 11;
            this.buttonBack.Text = "Atrás";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonBalance
            // 
            this.buttonBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBalance.Location = new System.Drawing.Point(440, 349);
            this.buttonBalance.Name = "buttonBalance";
            this.buttonBalance.Size = new System.Drawing.Size(96, 39);
            this.buttonBalance.TabIndex = 12;
            this.buttonBalance.Text = "Carregar";
            this.buttonBalance.UseVisualStyleBackColor = true;
            this.buttonBalance.Click += new System.EventHandler(this.buttonBalance_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Location = new System.Drawing.Point(540, 349);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(96, 39);
            this.buttonEdit.TabIndex = 13;
            this.buttonEdit.Text = "Editar";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(642, 349);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(96, 39);
            this.buttonDelete.TabIndex = 14;
            this.buttonDelete.Text = "Apagar";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.Location = new System.Drawing.Point(338, 349);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(96, 39);
            this.buttonRegister.TabIndex = 15;
            this.buttonRegister.Text = "Registar ";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmployee.Location = new System.Drawing.Point(656, 20);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(49, 20);
            this.labelEmployee.TabIndex = 17;
            this.labelEmployee.Text = "label";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(485, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 29);
            this.label5.TabIndex = 18;
            this.label5.Text = "Funcionario:";
            // 
            // listBoxClients
            // 
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.HorizontalScrollbar = true;
            this.listBoxClients.ItemHeight = 16;
            this.listBoxClients.Location = new System.Drawing.Point(17, 67);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(312, 244);
            this.listBoxClients.TabIndex = 19;
            // 
            // comboBoxFilters
            // 
            this.comboBoxFilters.FormattingEnabled = true;
            this.comboBoxFilters.Location = new System.Drawing.Point(17, 357);
            this.comboBoxFilters.Name = "comboBoxFilters";
            this.comboBoxFilters.Size = new System.Drawing.Size(211, 24);
            this.comboBoxFilters.TabIndex = 20;
            this.comboBoxFilters.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilters_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Filtrar:";
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxFilters);
            this.Controls.Add(this.listBoxClients);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonBalance);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "FormCustomer";
            this.Text = "FormCustomer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonBalance;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNIF;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNumStudent;
        private System.Windows.Forms.TextBox textBoxNumStudent;
        private System.Windows.Forms.RadioButton radioButtonStudent;
        private System.Windows.Forms.RadioButton radioButtonProfessor;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.ComboBox comboBoxFilters;
        private System.Windows.Forms.Label label6;
    }
}