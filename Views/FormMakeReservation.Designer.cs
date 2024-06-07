namespace iCantine.Views
{
    partial class FormMakeReservation
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
            this.label = new System.Windows.Forms.Label();
            this.listBoxExtras = new System.Windows.Forms.ListBox();
            this.listBoxReservations = new System.Windows.Forms.ListBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonReserve = new System.Windows.Forms.Button();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxPlates = new System.Windows.Forms.ListBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxMenus = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButtonDinner = new System.Windows.Forms.RadioButton();
            this.radioButtonLunch = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.buttonAddReserve = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pratos";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(622, 75);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(197, 24);
            this.label.TabIndex = 4;
            this.label.Text = "Reservas Adicionadas";
            // 
            // listBoxExtras
            // 
            this.listBoxExtras.FormattingEnabled = true;
            this.listBoxExtras.Location = new System.Drawing.Point(435, 75);
            this.listBoxExtras.Name = "listBoxExtras";
            this.listBoxExtras.Size = new System.Drawing.Size(141, 303);
            this.listBoxExtras.TabIndex = 5;
            // 
            // listBoxReservations
            // 
            this.listBoxReservations.FormattingEnabled = true;
            this.listBoxReservations.HorizontalScrollbar = true;
            this.listBoxReservations.Location = new System.Drawing.Point(626, 101);
            this.listBoxReservations.Name = "listBoxReservations";
            this.listBoxReservations.Size = new System.Drawing.Size(246, 225);
            this.listBoxReservations.TabIndex = 6;
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(16, 394);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(90, 44);
            this.buttonBack.TabIndex = 7;
            this.buttonBack.Text = "Voltar";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(533, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cliente:";
            // 
            // buttonReserve
            // 
            this.buttonReserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReserve.Location = new System.Drawing.Point(770, 396);
            this.buttonReserve.Name = "buttonReserve";
            this.buttonReserve.Size = new System.Drawing.Size(97, 44);
            this.buttonReserve.TabIndex = 10;
            this.buttonReserve.Text = "Reservar";
            this.buttonReserve.UseVisualStyleBackColor = true;
            this.buttonReserve.Click += new System.EventHandler(this.buttonReserve_Click);
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(612, 409);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(152, 21);
            this.comboBoxClient.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(617, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 24);
            this.label7.TabIndex = 33;
            this.label7.Text = "Funcionário:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(751, 9);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(105, 24);
            this.labelUsername.TabIndex = 32;
            this.labelUsername.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(431, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "Extras";
            // 
            // listBoxPlates
            // 
            this.listBoxPlates.FormattingEnabled = true;
            this.listBoxPlates.Location = new System.Drawing.Point(262, 75);
            this.listBoxPlates.Name = "listBoxPlates";
            this.listBoxPlates.Size = new System.Drawing.Size(167, 303);
            this.listBoxPlates.TabIndex = 35;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(181, 13);
            this.dateTimePicker.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 36;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 24);
            this.label3.TabIndex = 37;
            this.label3.Text = "Data para Reserva";
            // 
            // listBoxMenus
            // 
            this.listBoxMenus.FormattingEnabled = true;
            this.listBoxMenus.Location = new System.Drawing.Point(102, 75);
            this.listBoxMenus.Name = "listBoxMenus";
            this.listBoxMenus.Size = new System.Drawing.Size(154, 303);
            this.listBoxMenus.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(98, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 24);
            this.label5.TabIndex = 39;
            this.label5.Text = "Menus";
            // 
            // radioButtonDinner
            // 
            this.radioButtonDinner.AutoSize = true;
            this.radioButtonDinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDinner.Location = new System.Drawing.Point(12, 109);
            this.radioButtonDinner.Name = "radioButtonDinner";
            this.radioButtonDinner.Size = new System.Drawing.Size(78, 28);
            this.radioButtonDinner.TabIndex = 40;
            this.radioButtonDinner.TabStop = true;
            this.radioButtonDinner.Text = "Jantar";
            this.radioButtonDinner.UseVisualStyleBackColor = true;
            // 
            // radioButtonLunch
            // 
            this.radioButtonLunch.AutoSize = true;
            this.radioButtonLunch.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonLunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLunch.Location = new System.Drawing.Point(12, 75);
            this.radioButtonLunch.Name = "radioButtonLunch";
            this.radioButtonLunch.Size = new System.Drawing.Size(93, 28);
            this.radioButtonLunch.TabIndex = 41;
            this.radioButtonLunch.TabStop = true;
            this.radioButtonLunch.Text = "Almoço";
            this.radioButtonLunch.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(627, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 24);
            this.label6.TabIndex = 43;
            this.label6.Text = "Total:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(696, 329);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(105, 24);
            this.labelPrice.TabIndex = 42;
            this.labelPrice.Text = "Username";
            // 
            // buttonAddReserve
            // 
            this.buttonAddReserve.Location = new System.Drawing.Point(578, 191);
            this.buttonAddReserve.Name = "buttonAddReserve";
            this.buttonAddReserve.Size = new System.Drawing.Size(42, 44);
            this.buttonAddReserve.TabIndex = 44;
            this.buttonAddReserve.Text = ">";
            this.buttonAddReserve.UseVisualStyleBackColor = true;
            this.buttonAddReserve.Click += new System.EventHandler(this.buttonAddReserve_Click_1);
            // 
            // FormMakeReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 450);
            this.Controls.Add(this.buttonAddReserve);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.radioButtonDinner);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxMenus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.listBoxPlates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.buttonReserve);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.listBoxReservations);
            this.Controls.Add(this.listBoxExtras);
            this.Controls.Add(this.label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonLunch);
            this.Name = "FormMakeReservation";
            this.Text = "Form Efetuar Reservas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ListBox listBoxExtras;
        private System.Windows.Forms.ListBox listBoxReservations;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonReserve;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxPlates;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxMenus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonDinner;
        private System.Windows.Forms.RadioButton radioButtonLunch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Button buttonAddReserve;
    }
}