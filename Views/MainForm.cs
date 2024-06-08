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

namespace iCantine
{
    public partial class MainForm : Form
    {
        public string user;
        public List<models.Menu> menusMain;
        public MainForm(string user)
        {
            InitializeComponent();
            this.user = user;
            List<models.Menu> menusMain = new List<models.Menu>();
            changeUserLabel(user);
            UpdateWeekRange();
            updateLunchList();
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
            labelSelectedWeek.Text = $"Semana de: {selectedDates.First().ToShortDateString()} até {selectedDates.Last().ToShortDateString()}";
        }
        public List<models.Menu> getMenu()
        {
            
            using (var context = new models.Context())
            {
                var allMenus = new List<models.Menu>();

                foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
                {
                    var menusForDay = context.Menus
                        .OfType<models.Menu>()
                        .Where(m => m.Data.DayOfWeek == day)
                        .ToList();

                    allMenus.AddRange(menusForDay);
                }

                return allMenus;
            }
        }
        private void updateLunchList()
        {
            try
            {
                var allMenus = getMenu();

                var mondayMenus = allMenus.Where(m => m.Data.DayOfWeek == DayOfWeek.Monday).ToList();
                var tuesdayMenus = allMenus.Where(m => m.Data.DayOfWeek == DayOfWeek.Tuesday).ToList();
                var wednesdayMenus = allMenus.Where(m => m.Data.DayOfWeek == DayOfWeek.Wednesday).ToList();
                var thursdayMenus = allMenus.Where(m => m.Data.DayOfWeek == DayOfWeek.Thursday).ToList();
                var fridayMenus = allMenus.Where(m => m.Data.DayOfWeek == DayOfWeek.Friday).ToList();

                // Set the data source for each list box
                listBoxMondayLunch.DataSource = mondayMenus;
                listBoxTuesdayLunch.DataSource = tuesdayMenus;
                listBoxWednesdayLunch.DataSource = wednesdayMenus;
                listBoxThursdayLunch.DataSource = thursdayMenus;
                listBoxFridayLunch.DataSource = fridayMenus;

                // Set the DisplayMember if not already set
                listBoxMondayLunch.DisplayMember = "Name"; // Replace "Name" with the actual property to display
                listBoxTuesdayLunch.DisplayMember = "Name";
                listBoxWednesdayLunch.DisplayMember = "Name";
                listBoxThursdayLunch.DisplayMember = "Name";
                listBoxFridayLunch.DisplayMember = "Name";

                // Refresh the list boxes to ensure the UI is updated
                listBoxMondayLunch.Refresh();
                listBoxTuesdayLunch.Refresh();
                listBoxWednesdayLunch.Refresh();
                listBoxThursdayLunch.Refresh();
                listBoxFridayLunch.Refresh();
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
