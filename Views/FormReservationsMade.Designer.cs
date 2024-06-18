namespace iCantine.Views
{
    partial class FormReservationsMade
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
            this.listBoxReservationMade = new System.Windows.Forms.ListBox();
            this.listBoxReservationDone = new System.Windows.Forms.ListBox();
            this.buttonAddReservaEf = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reservas Efetuadas";
            // 
            // listBoxReservationMade
            // 
            this.listBoxReservationMade.FormattingEnabled = true;
            this.listBoxReservationMade.Location = new System.Drawing.Point(16, 46);
            this.listBoxReservationMade.Name = "listBoxReservationMade";
            this.listBoxReservationMade.Size = new System.Drawing.Size(328, 342);
            this.listBoxReservationMade.TabIndex = 1;
            // 
            // listBoxReservationDone
            // 
            this.listBoxReservationDone.FormattingEnabled = true;
            this.listBoxReservationDone.Location = new System.Drawing.Point(438, 46);
            this.listBoxReservationDone.Name = "listBoxReservationDone";
            this.listBoxReservationDone.Size = new System.Drawing.Size(328, 342);
            this.listBoxReservationDone.TabIndex = 2;
            // 
            // buttonAddReservaEf
            // 
            this.buttonAddReservaEf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddReservaEf.Location = new System.Drawing.Point(359, 177);
            this.buttonAddReservaEf.Name = "buttonAddReservaEf";
            this.buttonAddReservaEf.Size = new System.Drawing.Size(62, 54);
            this.buttonAddReservaEf.TabIndex = 3;
            this.buttonAddReservaEf.Text = ">";
            this.buttonAddReservaEf.UseVisualStyleBackColor = true;
            this.buttonAddReservaEf.Click += new System.EventHandler(this.buttonAddReservaEf_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(16, 394);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(90, 44);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.Text = "Voltar";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(434, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reservas Utilizadas";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(676, 394);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(90, 44);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Apagar";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // FormReservationsMade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonAddReservaEf);
            this.Controls.Add(this.listBoxReservationDone);
            this.Controls.Add(this.listBoxReservationMade);
            this.Controls.Add(this.label1);
            this.Name = "FormReservationsMade";
            this.Text = "FormReservasEfetuadas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxReservationMade;
        private System.Windows.Forms.ListBox listBoxReservationDone;
        private System.Windows.Forms.Button buttonAddReservaEf;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDelete;
    }
}