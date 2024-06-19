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
        private models.Context context = new models.Context();
        public MainForm(string user)
        {
            InitializeComponent();
            this.user = user;
            changeUserLabel(user);
            updateWeekRange();
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

        private List<DateTime> updateWeekRange()
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
            labelSelectedWeek.Text = $"Semana de: {selectedDates.First().ToShortDateString()} até {selectedDates.Last().ToShortDateString()}";
            return selectedDates;
        }
        public List<models.Menu> getLunchMenu(DateTime selectedDate)
        {
            var query = context.Menus.Where(
            menu =>
            menu.Data.Year == selectedDate.Year &&
            menu.Data.Month == selectedDate.Month &&
            menu.Data.Day == selectedDate.Day &&
            menu.Data.Hour == 12 &&
            menu.Plates.Any(p => p.Active))
            .Select(menu => new
            {
                Menu = menu,
                Plates = menu.Plates.Where(p => p.Active),
                Extras = menu.Extras.Where(e => e.Active)
            }).AsEnumerable()
                .Select(result =>
                {
                    result.Menu.Plates = result.Plates.ToList();
                    result.Menu.Extras = result.Extras.ToList();
                    return result.Menu;
                });
            return query.ToList();
        }

        public List<models.Menu> getDinnerMenu(DateTime selectedDate)
        {
            var query = context.Menus.Where(
            menu =>
            menu.Data.Year == selectedDate.Year &&
            menu.Data.Month == selectedDate.Month &&
            menu.Data.Day == selectedDate.Day &&
            menu.Data.Hour == 19 &&
            menu.Plates.Any(p => p.Active))
            .Select(menu => new
            {
                Menu = menu,
                Plates = menu.Plates.Where(p => p.Active),
                Extras = menu.Extras.Where(e => e.Active)
            }).AsEnumerable()
                .Select(result =>
                {
                    result.Menu.Plates = result.Plates.ToList();
                    result.Menu.Extras = result.Extras.ToList();
                    return result.Menu;
                });

            return query.ToList();
        }

        private void updateLunchList()
        {
            try
            {
                List<DateTime> selectedDates = updateWeekRange();

                DateTime today = DateTime.Today;

                foreach (DateTime date in selectedDates)
                {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Monday:
                                listBoxMondayLunch.DataSource = null;
                                listBoxMondayLunch.DataSource = getLunchMenu(date);
                                break;
                            case DayOfWeek.Tuesday:
                                listBoxTuesdayLunch.DataSource = null;
                                listBoxTuesdayLunch.DataSource = getLunchMenu(date);
                                break;
                            case DayOfWeek.Wednesday:
                                listBoxWednesdayLunch.DataSource = null;
                                listBoxWednesdayLunch.DataSource = getLunchMenu(date);
                                break;
                            case DayOfWeek.Thursday:
                                listBoxThursdayLunch.DataSource = null;
                                listBoxThursdayLunch.DataSource = getLunchMenu(date);
                                break;
                            case DayOfWeek.Friday:
                                listBoxFridayLunch.DataSource = null;
                                listBoxFridayLunch.DataSource = getLunchMenu(date);
                                break;
                        }
                    }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Nenhum menu almoço nesta semana");
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
                List<DateTime> selectedDates = updateWeekRange();

                DateTime today = DateTime.Today;

                foreach (DateTime date in selectedDates)
                {
                        switch (date.DayOfWeek)
                        {
                            case DayOfWeek.Monday:
                                listBoxMondayDinner.DataSource = null;
                                listBoxMondayDinner.DataSource = getDinnerMenu(date);
                                break;
                            case DayOfWeek.Tuesday:
                                listBoxTuesdayDinner.DataSource = null;
                                listBoxTuesdayDinner.DataSource = getDinnerMenu(date);
                                break;
                            case DayOfWeek.Wednesday:
                                listBoxWednesdayDinner.DataSource = null;
                                listBoxWednesdayDinner.DataSource = getDinnerMenu(date);
                                break;
                            case DayOfWeek.Thursday:
                                listBoxThursdayDinner.DataSource = null;
                                listBoxThursdayDinner.DataSource = getDinnerMenu(date);
                                break;
                            case DayOfWeek.Friday:
                                listBoxFridayDinner.DataSource = null;
                                listBoxFridayDinner.DataSource = getDinnerMenu(date);
                                break;
                        }
                    }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Nenhum menu jantar nesta semana");
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
            updateWeekRange();
        }

    }
}
