namespace iCantine
{
    partial class MainForm
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
            this.labelUsername = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonPlates = new System.Windows.Forms.Button();
            this.buttonMenus = new System.Windows.Forms.Button();
            this.buttonReservations = new System.Windows.Forms.Button();
            this.buttonCustomers = new System.Windows.Forms.Button();
            this.buttonTickets = new System.Windows.Forms.Button();
            this.buttonExtras = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxMondayLunch = new System.Windows.Forms.ListBox();
            this.listBoxTuesdayLunch = new System.Windows.Forms.ListBox();
            this.listBoxWednesdayLunch = new System.Windows.Forms.ListBox();
            this.listBoxThursdayLunch = new System.Windows.Forms.ListBox();
            this.listBoxFridayLunch = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonEmployee = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.listBoxFridayDinner = new System.Windows.Forms.ListBox();
            this.listBoxThursdayDinner = new System.Windows.Forms.ListBox();
            this.listBoxWednesdayDinner = new System.Windows.Forms.ListBox();
            this.listBoxTuesdayDinner = new System.Windows.Forms.ListBox();
            this.listBoxMondayDinner = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelSelectedWeek = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(665, 9);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(105, 24);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(1063, 13);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(106, 28);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonPlates
            // 
            this.buttonPlates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlates.Location = new System.Drawing.Point(221, 68);
            this.buttonPlates.Name = "buttonPlates";
            this.buttonPlates.Size = new System.Drawing.Size(147, 69);
            this.buttonPlates.TabIndex = 4;
            this.buttonPlates.Text = "Pratos";
            this.buttonPlates.UseVisualStyleBackColor = true;
            this.buttonPlates.Click += new System.EventHandler(this.buttonPlates_Click);
            // 
            // buttonMenus
            // 
            this.buttonMenus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenus.Location = new System.Drawing.Point(19, 68);
            this.buttonMenus.Name = "buttonMenus";
            this.buttonMenus.Size = new System.Drawing.Size(147, 69);
            this.buttonMenus.TabIndex = 5;
            this.buttonMenus.Text = "Menus";
            this.buttonMenus.UseVisualStyleBackColor = true;
            this.buttonMenus.Click += new System.EventHandler(this.buttonMenus_Click);
            // 
            // buttonReservations
            // 
            this.buttonReservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReservations.Location = new System.Drawing.Point(623, 68);
            this.buttonReservations.Name = "buttonReservations";
            this.buttonReservations.Size = new System.Drawing.Size(147, 69);
            this.buttonReservations.TabIndex = 6;
            this.buttonReservations.Text = "Reservas";
            this.buttonReservations.UseVisualStyleBackColor = true;
            this.buttonReservations.Click += new System.EventHandler(this.buttonReservations_Click);
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomers.Location = new System.Drawing.Point(422, 68);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(147, 69);
            this.buttonCustomers.TabIndex = 7;
            this.buttonCustomers.Text = "Clientes";
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonTickets
            // 
            this.buttonTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTickets.Location = new System.Drawing.Point(1022, 68);
            this.buttonTickets.Name = "buttonTickets";
            this.buttonTickets.Size = new System.Drawing.Size(147, 69);
            this.buttonTickets.TabIndex = 8;
            this.buttonTickets.Text = "Multas";
            this.buttonTickets.UseVisualStyleBackColor = true;
            this.buttonTickets.Click += new System.EventHandler(this.buttonTickets_Click);
            // 
            // buttonExtras
            // 
            this.buttonExtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExtras.Location = new System.Drawing.Point(820, 68);
            this.buttonExtras.Name = "buttonExtras";
            this.buttonExtras.Size = new System.Drawing.Size(147, 69);
            this.buttonExtras.TabIndex = 9;
            this.buttonExtras.Text = "Extras";
            this.buttonExtras.UseVisualStyleBackColor = true;
            this.buttonExtras.Click += new System.EventHandler(this.buttonExtras_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Segunda-Feira";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1001, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sexta-Feira";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(764, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Quinta-Feira";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(540, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Quarta-Feira";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(293, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Terça-Feira";
            // 
            // listBoxMondayLunch
            // 
            this.listBoxMondayLunch.FormattingEnabled = true;
            this.listBoxMondayLunch.HorizontalScrollbar = true;
            this.listBoxMondayLunch.Location = new System.Drawing.Point(19, 252);
            this.listBoxMondayLunch.Name = "listBoxMondayLunch";
            this.listBoxMondayLunch.Size = new System.Drawing.Size(187, 82);
            this.listBoxMondayLunch.TabIndex = 20;
            // 
            // listBoxTuesdayLunch
            // 
            this.listBoxTuesdayLunch.FormattingEnabled = true;
            this.listBoxTuesdayLunch.HorizontalScrollbar = true;
            this.listBoxTuesdayLunch.Location = new System.Drawing.Point(253, 252);
            this.listBoxTuesdayLunch.Name = "listBoxTuesdayLunch";
            this.listBoxTuesdayLunch.Size = new System.Drawing.Size(187, 82);
            this.listBoxTuesdayLunch.TabIndex = 21;
            // 
            // listBoxWednesdayLunch
            // 
            this.listBoxWednesdayLunch.FormattingEnabled = true;
            this.listBoxWednesdayLunch.HorizontalScrollbar = true;
            this.listBoxWednesdayLunch.Location = new System.Drawing.Point(492, 253);
            this.listBoxWednesdayLunch.Name = "listBoxWednesdayLunch";
            this.listBoxWednesdayLunch.Size = new System.Drawing.Size(187, 82);
            this.listBoxWednesdayLunch.TabIndex = 22;
            // 
            // listBoxThursdayLunch
            // 
            this.listBoxThursdayLunch.FormattingEnabled = true;
            this.listBoxThursdayLunch.HorizontalScrollbar = true;
            this.listBoxThursdayLunch.Location = new System.Drawing.Point(724, 253);
            this.listBoxThursdayLunch.Name = "listBoxThursdayLunch";
            this.listBoxThursdayLunch.Size = new System.Drawing.Size(187, 82);
            this.listBoxThursdayLunch.TabIndex = 23;
            // 
            // listBoxFridayLunch
            // 
            this.listBoxFridayLunch.FormattingEnabled = true;
            this.listBoxFridayLunch.HorizontalScrollbar = true;
            this.listBoxFridayLunch.Location = new System.Drawing.Point(964, 253);
            this.listBoxFridayLunch.Name = "listBoxFridayLunch";
            this.listBoxFridayLunch.Size = new System.Drawing.Size(187, 82);
            this.listBoxFridayLunch.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(584, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "Funcionario:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(394, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 24);
            this.label7.TabIndex = 25;
            this.label7.Text = "Funcionário:";
            // 
            // buttonEmployee
            // 
            this.buttonEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEmployee.Location = new System.Drawing.Point(942, 13);
            this.buttonEmployee.Name = "buttonEmployee";
            this.buttonEmployee.Size = new System.Drawing.Size(106, 28);
            this.buttonEmployee.TabIndex = 26;
            this.buttonEmployee.Text = "Funcionário";
            this.buttonEmployee.UseVisualStyleBackColor = true;
            this.buttonEmployee.Click += new System.EventHandler(this.buttonEmployee_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(77, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "Almoço";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(308, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Almoço";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(561, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 17);
            this.label10.TabIndex = 29;
            this.label10.Text = "Almoço";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(790, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Almoço";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1016, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 31;
            this.label12.Text = "Almoço";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(83, 382);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 17);
            this.label17.TabIndex = 37;
            this.label17.Text = "Jantar";
            // 
            // listBoxFridayDinner
            // 
            this.listBoxFridayDinner.FormattingEnabled = true;
            this.listBoxFridayDinner.HorizontalScrollbar = true;
            this.listBoxFridayDinner.Location = new System.Drawing.Point(964, 402);
            this.listBoxFridayDinner.Name = "listBoxFridayDinner";
            this.listBoxFridayDinner.Size = new System.Drawing.Size(187, 82);
            this.listBoxFridayDinner.TabIndex = 36;
            // 
            // listBoxThursdayDinner
            // 
            this.listBoxThursdayDinner.FormattingEnabled = true;
            this.listBoxThursdayDinner.HorizontalScrollbar = true;
            this.listBoxThursdayDinner.Location = new System.Drawing.Point(724, 402);
            this.listBoxThursdayDinner.Name = "listBoxThursdayDinner";
            this.listBoxThursdayDinner.Size = new System.Drawing.Size(187, 82);
            this.listBoxThursdayDinner.TabIndex = 35;
            // 
            // listBoxWednesdayDinner
            // 
            this.listBoxWednesdayDinner.FormattingEnabled = true;
            this.listBoxWednesdayDinner.HorizontalScrollbar = true;
            this.listBoxWednesdayDinner.Location = new System.Drawing.Point(492, 402);
            this.listBoxWednesdayDinner.Name = "listBoxWednesdayDinner";
            this.listBoxWednesdayDinner.Size = new System.Drawing.Size(187, 82);
            this.listBoxWednesdayDinner.TabIndex = 34;
            // 
            // listBoxTuesdayDinner
            // 
            this.listBoxTuesdayDinner.FormattingEnabled = true;
            this.listBoxTuesdayDinner.HorizontalScrollbar = true;
            this.listBoxTuesdayDinner.Location = new System.Drawing.Point(253, 402);
            this.listBoxTuesdayDinner.Name = "listBoxTuesdayDinner";
            this.listBoxTuesdayDinner.Size = new System.Drawing.Size(187, 82);
            this.listBoxTuesdayDinner.TabIndex = 33;
            // 
            // listBoxMondayDinner
            // 
            this.listBoxMondayDinner.FormattingEnabled = true;
            this.listBoxMondayDinner.HorizontalScrollbar = true;
            this.listBoxMondayDinner.Location = new System.Drawing.Point(19, 402);
            this.listBoxMondayDinner.Name = "listBoxMondayDinner";
            this.listBoxMondayDinner.Size = new System.Drawing.Size(187, 82);
            this.listBoxMondayDinner.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(308, 382);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 17);
            this.label13.TabIndex = 38;
            this.label13.Text = "Jantar";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(561, 382);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 17);
            this.label14.TabIndex = 39;
            this.label14.Text = "Jantar";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(790, 382);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 17);
            this.label15.TabIndex = 40;
            this.label15.Text = "Jantar";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1022, 382);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 17);
            this.label16.TabIndex = 41;
            this.label16.Text = "Jantar";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(37, 157);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 42;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // labelSelectedWeek
            // 
            this.labelSelectedWeek.AutoSize = true;
            this.labelSelectedWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedWeek.Location = new System.Drawing.Point(266, 154);
            this.labelSelectedWeek.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectedWeek.Name = "labelSelectedWeek";
            this.labelSelectedWeek.Size = new System.Drawing.Size(72, 20);
            this.labelSelectedWeek.TabIndex = 45;
            this.labelSelectedWeek.Text = "semana";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 527);
            this.Controls.Add(this.labelSelectedWeek);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.listBoxFridayDinner);
            this.Controls.Add(this.listBoxThursdayDinner);
            this.Controls.Add(this.listBoxWednesdayDinner);
            this.Controls.Add(this.listBoxTuesdayDinner);
            this.Controls.Add(this.listBoxMondayDinner);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonEmployee);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBoxFridayLunch);
            this.Controls.Add(this.listBoxThursdayLunch);
            this.Controls.Add(this.listBoxWednesdayLunch);
            this.Controls.Add(this.listBoxTuesdayLunch);
            this.Controls.Add(this.listBoxMondayLunch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonExtras);
            this.Controls.Add(this.buttonTickets);
            this.Controls.Add(this.buttonCustomers);
            this.Controls.Add(this.buttonReservations);
            this.Controls.Add(this.buttonMenus);
            this.Controls.Add(this.buttonPlates);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.labelUsername);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonPlates;
        private System.Windows.Forms.Button buttonMenus;
        private System.Windows.Forms.Button buttonReservations;
        private System.Windows.Forms.Button buttonCustomers;
        private System.Windows.Forms.Button buttonTickets;
        private System.Windows.Forms.Button buttonExtras;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxMondayLunch;
        private System.Windows.Forms.ListBox listBoxTuesdayLunch;
        private System.Windows.Forms.ListBox listBoxWednesdayLunch;
        private System.Windows.Forms.ListBox listBoxThursdayLunch;
        private System.Windows.Forms.ListBox listBoxFridayLunch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonEmployee;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListBox listBoxFridayDinner;
        private System.Windows.Forms.ListBox listBoxThursdayDinner;
        private System.Windows.Forms.ListBox listBoxWednesdayDinner;
        private System.Windows.Forms.ListBox listBoxTuesdayDinner;
        private System.Windows.Forms.ListBox listBoxMondayDinner;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelSelectedWeek;
    }
}

