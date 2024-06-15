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

namespace iCantine.Views
{
    public partial class FormMakeReservation : Form
    {
        public string user;
        public List<models.Menu> menuItems;
        private List<Plate> plates;
        private List<Extra> extra;
        private List<Client> clients;
        private string hour;


        public FormMakeReservation(string user)
        {
            InitializeComponent();
            this.user = user;
            this.plates = CRUDController.loadPlatesMenu();
            this.extra = CRUDController.loadExtrasMenu();
            this.radioButtonLunch.CheckedChanged += new System.EventHandler(this.radioButtonLunch_CheckedChanged);
            this.radioButtonDinner.CheckedChanged += new System.EventHandler(this.radioButtonDinner_CheckedChanged);
            changeUserLabel(user);
            updateListBoxExtras();
            updateListBoxPlates();
            updateComboBox();
            updatelistBoxMenus();
            updateListBoxReservations();
            listBoxReservations.DataSource = null;
        }
        public void updatelistBoxMenus()
        {
            using (var context = new models.Context())
            {
                DateTime selectedDate = dateTimePicker.Value;
                /*var menus = context.Menus
                    .OfType<models.Menu>()
                    .ToList();
                listBoxMenus.DataSource = menus;
                listBoxMenus.DisplayMember = "DisplayName";*/
                var query = context.Menus.Where(
                    menu =>
                    menu.Data.Year == selectedDate.Year &&
                    menu.Data.Month == selectedDate.Month &&
                    menu.Data.Day == selectedDate.Day).Include(m => m.Plates).Include(m => m.Extras);
                listBoxMenus.DataSource = null;
                listBoxMenus.DataSource = query.ToList();
            }
        }
        public void updateListBoxPlates()
        {
            using (var context = new models.Context())
            {
                var plates = context.Plates
                    .OfType<Plate>()
                    .ToList();
                listBoxPlates.DataSource = plates;
                listBoxPlates.DisplayMember = "ReservationName";
            }
        }
        public void updateListBoxExtras()
        {
            using (var context = new models.Context())
            {
                var extras = context.Extras
                    .OfType<Extra>()
                    .ToList();
                listBoxExtras.DataSource = extras;
                listBoxExtras.DisplayMember = "ReservationName";
            }
        }
        private void updateComboBox()
        {
            using (var context = new models.Context())
            {
                var names = context.Users
                    .OfType<Client>()
                    .ToList();
                comboBoxClient.DataSource = names;
                comboBoxClient.DisplayMember = "Name";
            }
        }


        private void buttonReserve_Click(object sender, EventArgs e)
        {
            if (listBoxReservations.SelectedItem == null)
            {
                MessageBox.Show("Nenhuma reserva selecionada");
                return;
            }

            string reservationString = listBoxReservations.SelectedItem.ToString();
            
            string[] reservationItems = reservationString.Split(' ');

            if(reservationItems.Length < 5)
            {
                MessageBox.Show("Formato da reserva inválido");
                return;
            }
            for(int i=0; i<5; i++)
            {
                MessageBox.Show(reservationItems[i]);
            }
            string reservationPlate = reservationItems[0];
            string reservationExtra = reservationItems[1];
            string reservationClient = reservationItems[2];
            string reservationMenu = reservationItems[3];
            string reservationDate = reservationItems[4];
            string reservationHour = reservationItems[5];

            //DateTime parsedDate = DateTime.Parse(reservationDate);


            var reservation = new Reservation(reservationPlate, reservationExtra, reservationClient, DateTime.Parse(reservationDate), reservationHour);
            using (var context = new models.Context())
            {
                try
                {
                    context.Reservations.Add(reservation);
                    context.SaveChanges();
                    MessageBox.Show("Reserva guardada com sucesso");
                    updateListBoxReservations();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }


            /*
            string plate = listBoxPlates.SelectedItem.ToString();
            string extra = listBoxExtras.SelectedItem.ToString();
            string client = comboBoxClient.SelectedItem.ToString();
            string date = dateTimePicker.Value.Date.ToString("d");
            DateTime selectedDate = dateTimePicker.Value.Date;

            if (validationControl(plate, extra, client))
            {
                UpdateHour();
                Reservation reservation = new Reservation(plate, extra, client, selectedDate, hour);
                using (var context = new models.Context())
                {
                    try
                    {
                        context.Reservations.Add(reservation);
                        context.SaveChanges();
                        MessageBox.Show("Reserva guardada com sucesso");
                        updateListBoxReservations();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex.Message);
                    }
                }
            }*/

        }
        private void UpdateHour()
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
        private bool validationControl(Plate plate, List<Extra> Extra, User client, models.Menu menu)
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
        public void updateListBoxReservations()
        {
            using (var context = new models.Context())
            {
                var reservations = context.Reservations
                    .OfType<Reservation>()
                    .ToList();
                listBoxReservations.DataSource = reservations;
                listBoxReservations.DisplayMember = "DisplayName";
            }
        }
    

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            updatelistBoxMenus();
            DateTime selectedDate = dateTimePicker.Value;
            DateTime MaxAllowedDate = DateTime.Now.AddDays(7);
            if (selectedDate > MaxAllowedDate)
            {
                MessageBox.Show("Data inválida");
                dateTimePicker.Value = DateTime.Now;
                return;
            }
            if(selectedDate < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("Data inválida");
                dateTimePicker.Value = DateTime.Now;
                return;
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
            /*Plate plate = (Plate)listBoxPlates.SelectedItem;
            Extra extra = (Extra)listBoxExtras.SelectedItem;
            User client = (User)comboBoxClient.SelectedItem;
            DateTime date = (DateTime)dateTimePicker.Value.Date;
            
            var finalItems = plate + " " + extra + " " + client + " " + date + " " + hour;
            listBoxReservations.Items.Add(finalItems);*/

            var selectedPlate = listBoxPlates.SelectedItem as Plate;
            List<Extra> selectedExtra = listBoxExtras.SelectedItem as List<Extra>;
            var selectedClient = comboBoxClient.SelectedItem as Client;
            var selectedMenu = listBoxMenus.SelectedItem as models.Menu;
            DateTime date = (DateTime)dateTimePicker.Value.Date;

            UpdateHour();

            if (validationControl(selectedPlate, selectedExtra, selectedClient, selectedMenu))
            {
                string dateString = date.ToString("d");
                var finalItems = selectedPlate + " " + selectedExtra + " " + selectedClient + " " + selectedMenu + " " + dateTimePicker.Value.Date + " " + hour;
                listBoxReservations.Items.Add(finalItems);
            }
        }

        private void buttonAddReserve_Click_1(object sender, EventArgs e)
        {
            addReserve();
        }
    }
}
