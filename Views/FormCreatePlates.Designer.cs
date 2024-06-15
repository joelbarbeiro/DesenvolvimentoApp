namespace iCantine.Views
{
    partial class FormCreatePlates
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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.listBoxPlates = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.stockUpDown = new System.Windows.Forms.NumericUpDown();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stockUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(378, 378);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(143, 50);
            this.buttonDelete.TabIndex = 21;
            this.buttonDelete.Text = "Eliminar Prato";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Location = new System.Drawing.Point(646, 378);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(116, 50);
            this.buttonEdit.TabIndex = 20;
            this.buttonEdit.Text = "Editar Prato";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // listBoxPlates
            // 
            this.listBoxPlates.FormattingEnabled = true;
            this.listBoxPlates.Location = new System.Drawing.Point(378, 82);
            this.listBoxPlates.Name = "listBoxPlates";
            this.listBoxPlates.Size = new System.Drawing.Size(384, 290);
            this.listBoxPlates.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(374, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 24);
            this.label4.TabIndex = 18;
            this.label4.Text = "Pratos disponíveis";
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(30, 378);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(95, 50);
            this.buttonBack.TabIndex = 17;
            this.buttonBack.Text = "Voltar";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click_1);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(121, 223);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(132, 23);
            this.buttonAdd.TabIndex = 16;
            this.buttonAdd.Text = "Adicionar";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Descrição:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(54, 97);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(199, 20);
            this.textBoxDescription.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Criar Pratos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tipo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "Stock:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(657, 18);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(105, 24);
            this.labelUsername.TabIndex = 26;
            this.labelUsername.Text = "Username";
            // 
            // stockUpDown
            // 
            this.stockUpDown.Location = new System.Drawing.Point(54, 197);
            this.stockUpDown.Name = "stockUpDown";
            this.stockUpDown.Size = new System.Drawing.Size(199, 20);
            this.stockUpDown.TabIndex = 27;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(54, 146);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(199, 21);
            this.comboBoxType.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(523, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 24);
            this.label7.TabIndex = 31;
            this.label7.Text = "Funcionário:";
            // 
            // FormCreatePlates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.stockUpDown);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.listBoxPlates);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.label5);
            this.Name = "FormCreatePlates";
            this.Text = "  ";
            ((System.ComponentModel.ISupportInitialize)(this.stockUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ListBox listBoxPlates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.NumericUpDown stockUpDown;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label7;
    }
}