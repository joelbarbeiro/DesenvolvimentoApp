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
            this.listBoxMonday = new System.Windows.Forms.ListBox();
            this.listBoxTuesday = new System.Windows.Forms.ListBox();
            this.listBoxWednesday = new System.Windows.Forms.ListBox();
            this.listBoxThursday = new System.Windows.Forms.ListBox();
            this.listBoxFriday = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(533, 13);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(105, 24);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(647, 9);
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
            this.buttonPlates.Location = new System.Drawing.Point(134, 68);
            this.buttonPlates.Name = "buttonPlates";
            this.buttonPlates.Size = new System.Drawing.Size(102, 69);
            this.buttonPlates.TabIndex = 4;
            this.buttonPlates.Text = "Pratos";
            this.buttonPlates.UseVisualStyleBackColor = true;
            // 
            // buttonMenus
            // 
            this.buttonMenus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenus.Location = new System.Drawing.Point(12, 68);
            this.buttonMenus.Name = "buttonMenus";
            this.buttonMenus.Size = new System.Drawing.Size(102, 69);
            this.buttonMenus.TabIndex = 5;
            this.buttonMenus.Text = "Menus";
            this.buttonMenus.UseVisualStyleBackColor = true;
            // 
            // buttonReservations
            // 
            this.buttonReservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReservations.Location = new System.Drawing.Point(386, 68);
            this.buttonReservations.Name = "buttonReservations";
            this.buttonReservations.Size = new System.Drawing.Size(102, 69);
            this.buttonReservations.TabIndex = 6;
            this.buttonReservations.Text = "Reservas";
            this.buttonReservations.UseVisualStyleBackColor = true;
            this.buttonReservations.Click += new System.EventHandler(this.buttonReservations_Click);
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomers.Location = new System.Drawing.Point(260, 68);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(102, 69);
            this.buttonCustomers.TabIndex = 7;
            this.buttonCustomers.Text = "Clientes";
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonTickets
            // 
            this.buttonTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTickets.Location = new System.Drawing.Point(651, 68);
            this.buttonTickets.Name = "buttonTickets";
            this.buttonTickets.Size = new System.Drawing.Size(102, 69);
            this.buttonTickets.TabIndex = 8;
            this.buttonTickets.Text = "Multas";
            this.buttonTickets.UseVisualStyleBackColor = true;
            // 
            // buttonExtras
            // 
            this.buttonExtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExtras.Location = new System.Drawing.Point(519, 68);
            this.buttonExtras.Name = "buttonExtras";
            this.buttonExtras.Size = new System.Drawing.Size(102, 69);
            this.buttonExtras.TabIndex = 9;
            this.buttonExtras.Text = "Extras";
            this.buttonExtras.UseVisualStyleBackColor = true;
            this.buttonExtras.Click += new System.EventHandler(this.buttonExtras_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Segunda-Feira";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(636, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sexta-Feira";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(481, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Quinta-Feira";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(324, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Quarta-Feira";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(178, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Terça-Feira";
            // 
            // listBoxMonday
            // 
            this.listBoxMonday.FormattingEnabled = true;
            this.listBoxMonday.Location = new System.Drawing.Point(25, 207);
            this.listBoxMonday.Name = "listBoxMonday";
            this.listBoxMonday.Size = new System.Drawing.Size(127, 212);
            this.listBoxMonday.TabIndex = 20;
            // 
            // listBoxTuesday
            // 
            this.listBoxTuesday.FormattingEnabled = true;
            this.listBoxTuesday.Location = new System.Drawing.Point(182, 207);
            this.listBoxTuesday.Name = "listBoxTuesday";
            this.listBoxTuesday.Size = new System.Drawing.Size(122, 212);
            this.listBoxTuesday.TabIndex = 21;
            // 
            // listBoxWednesday
            // 
            this.listBoxWednesday.FormattingEnabled = true;
            this.listBoxWednesday.Location = new System.Drawing.Point(328, 207);
            this.listBoxWednesday.Name = "listBoxWednesday";
            this.listBoxWednesday.Size = new System.Drawing.Size(127, 212);
            this.listBoxWednesday.TabIndex = 22;
            // 
            // listBoxThursday
            // 
            this.listBoxThursday.FormattingEnabled = true;
            this.listBoxThursday.Location = new System.Drawing.Point(485, 207);
            this.listBoxThursday.Name = "listBoxThursday";
            this.listBoxThursday.Size = new System.Drawing.Size(122, 212);
            this.listBoxThursday.TabIndex = 23;
            // 
            // listBoxFriday
            // 
            this.listBoxFriday.FormattingEnabled = true;
            this.listBoxFriday.Location = new System.Drawing.Point(636, 207);
            this.listBoxFriday.Name = "listBoxFriday";
            this.listBoxFriday.Size = new System.Drawing.Size(127, 212);
            this.listBoxFriday.TabIndex = 24;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxFriday);
            this.Controls.Add(this.listBoxThursday);
            this.Controls.Add(this.listBoxWednesday);
            this.Controls.Add(this.listBoxTuesday);
            this.Controls.Add(this.listBoxMonday);
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
        private System.Windows.Forms.ListBox listBoxMonday;
        private System.Windows.Forms.ListBox listBoxTuesday;
        private System.Windows.Forms.ListBox listBoxWednesday;
        private System.Windows.Forms.ListBox listBoxThursday;
        private System.Windows.Forms.ListBox listBoxFriday;
    }
}

