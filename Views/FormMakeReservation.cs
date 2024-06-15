using iCantine.Controllers;
using iCantine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iCantine.Views
{
    public partial class FormMakeReservation : Form
    {
        private Context Context = new Context();
        public string user;
        public List<models.Menu> menuItems;
        public List<Plate> plates;
        public List<Extra> extra;
        private string hour;

        public FormMakeReservation(string user)
        {
            InitializeComponent();
            this.user = user;
            this.radioButtonLunch.CheckedChanged += new System.EventHandler(this.radioButtonLunch_CheckedChanged);
            this.radioButtonDinner.CheckedChanged += new System.EventHandler(this.radioButtonDinner_CheckedChanged);
            listBoxMenus.SelectedIndexChanged += listBoxMenus_SelectedIndexChanged;
            listBoxExtras.SelectedIndexChanged += listBoxExtras_SelectedIndexChanged;
            listBoxExtras.SelectionMode = SelectionMode.MultiSimple;
            changeUserLabel(user);
            updatelistBoxExtras();
            updatelistBoxPlates();
            updateComboBox();
            updatelistBoxMenus();
        }

        private void updateComboBox()
        {
            using (var context = new models.Context())
            {
                var names = context.Users.OfType<Client>().ToList();
                comboBoxClient.DataSource = names;
                comboBoxClient.DisplayMember = "Name";
            }
        }

        public void updatelistBoxMenus()
        {
            using (var context = new models.Context())
            {
                DateTime selectedDate = dateTimePicker.Value;
                var query = context.Menus.Where(
                    menu =>
                    menu.Data.Year == selectedDate.Year &&
                    menu.Data.Month == selectedDate.Month &&
                    menu.Data.Day == selectedDate.Day).Include(m => m.Plates).Include(m => m.Extras);

                var menus = query.ToList();
                listBoxMenus.DataSource = null;
                listBoxMenus.DataSource = menus;
                listBoxMenus.ValueMember = "DisplayMenu";

                if (menus.Count == 0)
                {
                    listBoxPlates.DataSource = null;
                    listBoxExtras.DataSource = null;
                    MessageBox.Show("Sem menus na data escolhida");
                }
            }
        }

        private void buttonReserve_Click(object sender, EventArgs e)
        {
            UpdateClientBalance();
        }

        private string UpdateHour()
        {
            if (radioButtonLunch.Checked)
            {
                hour = "12:00";
            }
            else if (radioButtonDinner.Checked)
            {
                hour = "19:00";
            }
            else
            {
                hour = string.Empty;
            }
            return hour;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
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

        private bool validationControl(Plate plate, Extra extra, User client)
        {
            if (extra == null)
            {
                MessageBox.Show("Selecione um extra.");
                return false;
            }
            if (plate == null && listBoxMenus.SelectedItem == null)
            {
                MessageBox.Show("Selecione um Plate ou um Menu.");
                return false;
            }
            if (client == null)
            {
                MessageBox.Show("Selecione um cliente");
                return false;
            }
            if (dateTimePicker.Value < DateTime.Now)
            {
                MessageBox.Show("Data inválida");
                return false;
            }
            return true;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            updatelistBoxExtras();
            updatelistBoxMenus();
            
            DateTime selectedDate = dateTimePicker.Value;
            DateTime MaxAllowedDate = DateTime.Now.AddDays(7);
            if (selectedDate > MaxAllowedDate || selectedDate < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("Data inválida");
                dateTimePicker.Value = DateTime.Now;
            }
        }

        private void radioButtonLunch_CheckedChanged(object sender, EventArgs e)
        {
            UpdateHour();
        }

        private void radioButtonDinner_CheckedChanged(object sender, EventArgs e)
        {
            UpdateHour();
        }

        private void addReserve()
        {
            Plate plate = (Plate)listBoxPlates.SelectedItem;
            List<Extra> selectedExtras = new List<Extra>();
            string time = UpdateHour();
            DateTime day = dateTimePicker.Value.ToUniversalTime();
            DateTime dateToSave = convertTimeFromString(day, time);
            models.Menu menu = (models.Menu)listBoxMenus.SelectedItem;
            Client client = (Client)comboBoxClient.SelectedItem;

            foreach (var itemExtra in listBoxExtras.SelectedItems)
            {
                selectedExtras.Add((Extra)itemExtra);
            }
            Reservation reservation = new Reservation();

            if (saveReservations(reservation, menu, plate, selectedExtras, client))
            {
                MessageBox.Show("Menu gravado com sucesso!");
            }
            else
            {
                MessageBox.Show("Falha ao gravar!");
            }

        }
        private void updateListBoxReservations(Reservation reservation)
        {
            listBoxReservations.DataSource = null;
            listBoxReservations.DataSource = reservation;
        }

        private void buttonAddReserve_Click(object sender, EventArgs e)
        {
            UpdateClientBalance();
            addReserve();
        }

        public List<Plate> loadPlatesMenu(int menuId)
        {
            using (var context = new models.Context())
            {
                var plates = context.Menus
                                  .Include(m => m.Plates)
                                  .FirstOrDefault(m => m.idMenu == menuId);
                return plates?.Plates.Where(p => p.Active).ToList() ?? new List<Plate>();

            }
        }
        

        private decimal calcTotal()
        {
            decimal totalCost = 0;

            if (listBoxMenus.SelectedItem is models.Menu selectedMenu)
            {
                Client client = (Client)comboBoxClient.SelectedItem;
                if (client != null)
                {
                   if (client is Student)
                    {
                        totalCost += selectedMenu.PriceStudent;
                    }
                    else if (client is Professor)
                    {
                        totalCost += selectedMenu.PriceProf;
                    }
                    foreach (var selectedItem in listBoxExtras.SelectedItems)
                    {
                        if (selectedItem is Extra selectedExtra)
                        {
                            totalCost += (decimal)selectedExtra.Price;
                        }
                    }
                }
            }
            labelPrice.Text = totalCost.ToString("C");
            return totalCost;
        }

        public List<Extra> loadExtrasMenu(int menuId)
        {
            using (var context = new models.Context())
            {
                var extras = context.Menus
                                  .Include(m => m.Extras)
                                  .FirstOrDefault(m => m.idMenu == menuId);

                return extras?.Extras.Where(p => p.Active).ToList() ?? new List<Extra>();
            }
        }
        private void UpdateClientBalance()
        {
            decimal totalCost = calcTotal();
            Client client = (Client)comboBoxClient.SelectedItem;
            if (client != null)
            {
                using (var context = new models.Context())
                {
                    var dbClient = context.Users.OfType<Client>().FirstOrDefault(c => c.name == client.name);
                    if (dbClient != null && dbClient.Balance >= totalCost)
                    {
                        dbClient.Balance -= totalCost;
                        context.SaveChanges();
                        MessageBox.Show($"Reserva feita com sucesso. Custo total: {totalCost:C}. O seu montante é: {dbClient.Balance:C}");
                    }
                    else
                    {
                        MessageBox.Show("Insufficient balance to make the reservation.");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a client.");
                return;
            }
        }

        private void listBoxExtras_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcTotal();
        }

        public void updatelistBoxExtras()
        {
            using (var context = new models.Context())
            {
                var extras = context.Extras
                    .OfType<Extra>()
                    .ToList();
                listBoxExtras.DataSource = extras;
                listBoxExtras.DisplayMember = "DisplayName";
            }
        }
        public void updatelistBoxPlates()
        { 
            using (var context = new models.Context())
            {
                var plates = context.Plates
                    .OfType<Plate>()
                    .ToList();
                listBoxPlates.DataSource = plates;
                listBoxPlates.DisplayMember = "DisplayName";
            }
        }

        private void listBoxMenus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMenus.SelectedItem is models.Menu selectedMenu)
            {
                int menuId = selectedMenu.idMenu;
                var plates = loadPlatesMenu(menuId);
                if (plates.Count > 0)
                {
                    listBoxPlates.DataSource = plates;
                    listBoxPlates.DisplayMember = "ReservationName";
                }
                else
                {
                    listBoxPlates.DataSource = null;
                    MessageBox.Show("No plates available for the selected menu.");
                }
                calcTotal();
            }
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcTotal();
        }
        private DateTime convertTimeFromString(DateTime day, string time)
        {
            DateTime dateToSave = DateTime.Now;
            string[] timeParts = time.Split(':');
            if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int hour) && int.TryParse(timeParts[1], out int minutes))
            {
                dateToSave = new DateTime(
                   day.Year,
                   day.Month,
                   day.Day,
                   hour,
                   minutes,
                   0);
            }
            return dateToSave;

        }

        public bool saveReservations(Reservation reservation, models.Menu menu, Plate plate, List<Extra> extras, Client client)
        {
            reservation.Plates = plate;
            reservation.Extras = extras;
            reservation.Extras = extras;
            reservation.Menus = menu;

            Context.Reservations.Add(reservation);
            Context.SaveChanges();
            return true;
        }

        private void listBoxExtras_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            calcTotal();
        }
    }
}
