using iCantine.Controllers;
using iCantine.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCantine.models
{
    public partial class FormReservationsOptions : Form
    {
        private string user;
        public FormReservationsOptions(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMakeReservation formReservations = new FormMakeReservation(user);
            FormController.changeForm(formReservations, this);
        }

        private void FormReservationsOptions_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormReservationsMade formReservations = new FormReservationsMade(user);
            FormController.changeForm(formReservations, this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm,this);
        }
    }
}
