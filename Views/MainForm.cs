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
using System.Runtime.Remoting.Contexts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Entity;

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
            UpdateWeekRange();
            updateLunchList();
            updateDinnerList();
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

        private void UpdateWeekRange()
        {

            DateTime startDate = dateTimePicker1.Value;

            List<DateTime> selectedDates = new List<DateTime>();

            int addedDays = 0;
            while (selectedDates.Count < 5)
            {
                DateTime currentDate = startDate.AddDays(addedDays);
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    selectedDates.Add(currentDate);
                }
                addedDays++;
            }
            labelSelectedWeek.Text = $"Semana de: {selectedDates.First().ToShortDateString()} at {selectedDates.Last().ToShortDateString()}";
        }
        public List<models.Menu> getLunchMenu(DateTime selectedDate)
        {
            using (var context = new models.Context())
            {
                var query = context.Menus.Where(
                    menu =>
                    menu.Data.Year == selectedDate.Year &&
                    menu.Data.Month == selectedDate.Month &&
                    menu.Data.Day == selectedDate.Day &&
                    menu.Data.Hour == 12
                    ).Include(m => m.Plates).Include(m => m.Extras);
                    ;
                return query.ToList();
            }
        }
        public List<models.Menu> getDinnerMenu(DateTime selectedDate)
        {
            using (var context = new models.Context())
            {
                var query = context.Menus.Where(
                    menu =>
                    menu.Data.Year == selectedDate.Year &&
                    menu.Data.Month == selectedDate.Month &&
                    menu.Data.Day == selectedDate.Day &&
                    menu.Data.Hour == 19
                    ).Include(m => m.Plates).Include(m => m.Extras);
                ;
                return query.ToList();
            }
        }

        private void updateLunchList()
        {
            try
            {
                DateTime today = DateTime.Today;
                int daysToMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
                DateTime monday = today.AddDays(daysToMonday);

                listBoxMondayLunch.DataSource = null;
                listBoxMondayLunch.DataSource = getLunchMenu(monday);

                listBoxTuesdayLunch.DataSource = null;
                listBoxTuesdayLunch.DataSource = getLunchMenu(monday.AddDays(1));

                listBoxWednesdayLunch.DataSource = null;
                listBoxWednesdayLunch.DataSource = getLunchMenu(monday.AddDays(2));

                listBoxThursdayLunch.DataSource = null;
                listBoxThursdayLunch.DataSource = getLunchMenu(monday.AddDays(3));

                listBoxFridayLunch.DataSource = null;
                listBoxFridayLunch.DataSource = getLunchMenu(monday.AddDays(4));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nenhum menu nesta semana");
                listBoxMondayLunch.DataSource = null;
                listBoxTuesdayLunch.DataSource = null;
                listBoxWednesdayLunch.DataSource = null;
                listBoxThursdayLunch.DataSource = null;
                listBoxFridayLunch.DataSource = null;
            }
        }
        private void updateDinnerList()
        {
            try
            {
                DateTime today = DateTime.Today;
                int daysToMonday = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;
                DateTime monday = today.AddDays(daysToMonday);

                listBoxMondayDinner.DataSource = null;
                listBoxMondayDinner.DataSource = getDinnerMenu(monday);

                listBoxTuesdayDinner.DataSource = null;
                listBoxTuesdayDinner.DataSource = getDinnerMenu(monday.AddDays(1));

                listBoxWednesdayDinner.DataSource = null;
                listBoxWednesdayDinner.DataSource = getDinnerMenu(monday.AddDays(2));

                listBoxThursdayDinner.DataSource = null;
                listBoxThursdayDinner.DataSource = getDinnerMenu(monday.AddDays(3));

                listBoxFridayDinner.DataSource = null;
                listBoxFridayDinner.DataSource = getDinnerMenu(monday.AddDays(4));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nenhum menu nesta semana");
                listBoxMondayDinner.DataSource = null;
                listBoxTuesdayDinner.DataSource = null;
                listBoxWednesdayDinner.DataSource = null;
                listBoxThursdayDinner.DataSource = null;
                listBoxFridayDinner.DataSource = null;
            }
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            UpdateWeekRange();
        }
    }
}
