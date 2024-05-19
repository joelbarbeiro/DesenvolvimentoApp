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
            this.labelUsername.Location = new System.Drawing.Point(711, 16);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(105, 24);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(863, 11);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(141, 34);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonPlates
            // 
            this.buttonPlates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlates.Location = new System.Drawing.Point(179, 84);
            this.buttonPlates.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPlates.Name = "buttonPlates";
            this.buttonPlates.Size = new System.Drawing.Size(136, 85);
            this.buttonPlates.TabIndex = 4;
            this.buttonPlates.Text = "Pratos";
            this.buttonPlates.UseVisualStyleBackColor = true;
            // 
            // buttonMenus
            // 
            this.buttonMenus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMenus.Location = new System.Drawing.Point(16, 84);
            this.buttonMenus.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMenus.Name = "buttonMenus";
            this.buttonMenus.Size = new System.Drawing.Size(136, 85);
            this.buttonMenus.TabIndex = 5;
            this.buttonMenus.Text = "Menus";
            this.buttonMenus.UseVisualStyleBackColor = true;
            // 
            // buttonReservations
            // 
            this.buttonReservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReservations.Location = new System.Drawing.Point(515, 84);
            this.buttonReservations.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReservations.Name = "buttonReservations";
            this.buttonReservations.Size = new System.Drawing.Size(136, 85);
            this.buttonReservations.TabIndex = 6;
            this.buttonReservations.Text = "Reservas";
            this.buttonReservations.UseVisualStyleBackColor = true;
            // 
            // buttonCustomers
            // 
            this.buttonCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomers.Location = new System.Drawing.Point(347, 84);
            this.buttonCustomers.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCustomers.Name = "buttonCustomers";
            this.buttonCustomers.Size = new System.Drawing.Size(136, 85);
            this.buttonCustomers.TabIndex = 7;
            this.buttonCustomers.Text = "Clientes";
            this.buttonCustomers.UseVisualStyleBackColor = true;
            this.buttonCustomers.Click += new System.EventHandler(this.buttonCustomers_Click);
            // 
            // buttonTickets
            // 
            this.buttonTickets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTickets.Location = new System.Drawing.Point(868, 84);
            this.buttonTickets.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTickets.Name = "buttonTickets";
            this.buttonTickets.Size = new System.Drawing.Size(136, 85);
            this.buttonTickets.TabIndex = 8;
            this.buttonTickets.Text = "Multas";
            this.buttonTickets.UseVisualStyleBackColor = true;
            // 
            // buttonExtras
            // 
            this.buttonExtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExtras.Location = new System.Drawing.Point(692, 84);
            this.buttonExtras.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExtras.Name = "buttonExtras";
            this.buttonExtras.Size = new System.Drawing.Size(136, 85);
            this.buttonExtras.TabIndex = 9;
            this.buttonExtras.Text = "Extras";
            this.buttonExtras.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 210);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Segunda-Feira";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(848, 210);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sexta-Feira";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(641, 210);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Quinta-Feira";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(432, 210);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Quarta-Feira";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(237, 210);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Terça-Feira";
            // 
            // listBoxMonday
            // 
            this.listBoxMonday.FormattingEnabled = true;
            this.listBoxMonday.ItemHeight = 16;
            this.listBoxMonday.Location = new System.Drawing.Point(33, 255);
            this.listBoxMonday.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxMonday.Name = "listBoxMonday";
            this.listBoxMonday.Size = new System.Drawing.Size(168, 260);
            this.listBoxMonday.TabIndex = 20;
            // 
            // listBoxTuesday
            // 
            this.listBoxTuesday.FormattingEnabled = true;
            this.listBoxTuesday.ItemHeight = 16;
            this.listBoxTuesday.Location = new System.Drawing.Point(243, 255);
            this.listBoxTuesday.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxTuesday.Name = "listBoxTuesday";
            this.listBoxTuesday.Size = new System.Drawing.Size(161, 260);
            this.listBoxTuesday.TabIndex = 21;
            // 
            // listBoxWednesday
            // 
            this.listBoxWednesday.FormattingEnabled = true;
            this.listBoxWednesday.ItemHeight = 16;
            this.listBoxWednesday.Location = new System.Drawing.Point(437, 255);
            this.listBoxWednesday.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxWednesday.Name = "listBoxWednesday";
            this.listBoxWednesday.Size = new System.Drawing.Size(168, 260);
            this.listBoxWednesday.TabIndex = 22;
            // 
            // listBoxThursday
            // 
            this.listBoxThursday.FormattingEnabled = true;
            this.listBoxThursday.ItemHeight = 16;
            this.listBoxThursday.Location = new System.Drawing.Point(647, 255);
            this.listBoxThursday.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxThursday.Name = "listBoxThursday";
            this.listBoxThursday.Size = new System.Drawing.Size(161, 260);
            this.listBoxThursday.TabIndex = 23;
            // 
            // listBoxFriday
            // 
            this.listBoxFriday.FormattingEnabled = true;
            this.listBoxFriday.ItemHeight = 16;
            this.listBoxFriday.Location = new System.Drawing.Point(848, 255);
            this.listBoxFriday.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxFriday.Name = "listBoxFriday";
            this.listBoxFriday.Size = new System.Drawing.Size(168, 260);
            this.listBoxFriday.TabIndex = 24;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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

