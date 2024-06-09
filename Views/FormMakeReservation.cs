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
            this.Load += FormMakeAReservation_Load;
            this.user = user;
            this.plates = CRUDController.loadPlatesMenu();
            this.extra = CRUDController.loadExtrasMenu();
            this.radioButtonLunch.CheckedChanged += new System.EventHandler(this.radioButtonLunch_CheckedChanged);
            this.radioButtonDinner.CheckedChanged += new System.EventHandler(this.radioButtonDinner_CheckedChanged);
            listBoxMenus.SelectedIndexChanged += listBoxMenus_SelectedIndexChanged;
            changeUserLabel(user);
            updateListBoxExtras();
            updateComboBox();
            updatelistBoxMenus();
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
                listBoxMenus.DataSource = null;
                listBoxMenus.DataSource = query.ToList();
                listBoxMenus.ValueMember = "idMenu";
                
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
            saveReservations();
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
            if (selectedDate < DateTime.Now.AddDays(-1))
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
            Plate plate = (Plate)listBoxPlates.SelectedItem;
            Extra extra = (Extra)listBoxExtras.SelectedItem;
            User client = (User)comboBoxClient.SelectedItem;
            DateTime date = dateTimePicker.Value.Date;
            UpdateHour();

            var finalItem = $"{date.ToShortDateString()}, {plate.Description}, {extra.Description},{client.name}, {hour}";
            listBoxReservations.Items.Add(finalItem);
        }


        private void buttonAddReserve_Click(object sender, EventArgs e)
        {
            addReserve();
        }

        private void saveReservations()
        {
            using (var context = new models.Context())
            {
                foreach (var selectedItem in listBoxReservations.SelectedItems)
                {
                    var parts = selectedItem.ToString().Split(',');

                    DateTime date = DateTime.Parse(parts[0].Trim());
                    string plateName = parts[1].Trim();
                    string clientName = parts[2].Trim();
                    string extraName = parts[3].Trim();
                    string hour = parts[4].Trim();

                    Plate plate = context.Plates.FirstOrDefault(p => p.Description == plateName);
                    User client = context.Users.FirstOrDefault(c => c.name == clientName);
                    Extra extra = context.Extras.FirstOrDefault(e => e.Description == extraName);

                    if (plate != null & client != null && extra != null)
                    {
                        var reservation = new Reservation
                        {
                            Date = date,
                            Hour = hour,
                            Client = client.name,
                            Plate = plate.Description,
                            Extra = extra.Description
                        };

                        context.Reservations.Add(reservation);
                    }
                }

                context.SaveChanges();
                MessageBox.Show("Reserva guardada com sucesso");
                listBoxReservations.Items.Clear();
            }

        }
        public List<Plate> loadPlatesMenu(int menuId)
        {
            using (var context = new models.Context())
            {
                var menu = context.Menus
                                  .Include(m => m.Plates)
                                  .FirstOrDefault(m => m.idMenu == menuId);

                return menu?.Plates.Where(p => p.Active).ToList() ?? new List<Plate>();
            }
        }


        private void listBoxMenus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMenus.SelectedItem is models.Menu selectedMenu)
            {
                int menuId = selectedMenu.idMenu;
                var plates = loadPlatesMenu(menuId);
                listBoxPlates.DataSource = plates;
                listBoxPlates.DisplayMember = "ReservationName";
            }
        }

        private void FormMakeAReservation_Load(object sender, EventArgs e)
        {
            if (listBoxMenus.Items.Count > 0)
            {
                listBoxMenus.SelectedIndex = 0;
                                                
                listBoxMenus_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

    }
    
}