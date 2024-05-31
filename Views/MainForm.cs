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
            labelUsername.Text = CapitalizeFirstLetter(user);
        }
        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
          
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
            FormReservationsOptions formReservationsoptions = new FormReservationsOptions(user);
            FormController.changeForm(formReservationsoptions, this);
        }

        private void buttonExtras_Click(object sender, EventArgs e)
        {
            FormCreateExtras formExtras = new FormCreateExtras(user);
            FormController.changeForm(formExtras, this);
        }

        private void buttonMenus_Click(object sender, EventArgs e)
        {
            string user = labelUsername.Text;
            FormMenu FormMenu = new FormMenu(user);
            FormController.changeForm(FormMenu, this);
        }

        private void buttonPlates_Click(object sender, EventArgs e)
        {
            FormCreatePlates formPlates = new FormCreatePlates(user);
            FormController.changeForm(formPlates, this);
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            FormEmployee formEmployee = new FormEmployee(user);
            FormController.changeForm(formEmployee, this);
        }

        private void buttonTickets_Click(object sender, EventArgs e)
        {
            FormTicket formTicket = new FormTicket(user);
            FormController.changeForm(formTicket, this);
        }
    }
}
