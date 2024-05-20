using iCantine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iCantine.Controllers;
using iCantine.Views;

namespace iCantine
{
    public partial class MainForm : Form
    {
        public string user;
        public MainForm(string user)
        {
            InitializeComponent();
            this.user = user;
            changeUserLabel(user);
        }
        private void changeUserLabel(string user)
        {
            labelUsername.Text=user;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            //FormController.logoutForm(this);
            FormLogin loginForm = new FormLogin();
            FormController.changeForm(loginForm, this);
        }


        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            string user = labelUsername.Text;
            FormCustomer customerForm = new FormCustomer(user);
            FormController.changeForm(customerForm, this);
        }

        private void buttonReservations_Click(object sender, EventArgs e)
        {
            FormEfetuarReservas formReservations = new FormEfetuarReservas(user);
            FormController.changeForm(formReservations, this);
        }

        private void buttonExtras_Click(object sender, EventArgs e)
        {
            FormCreateExtras formExtras = new FormCreateExtras(user);
            FormController.changeForm(formExtras, this);
        }
    }
}
