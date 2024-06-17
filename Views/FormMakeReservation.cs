using iCantine.Controllers;
using iCantine.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iCantine.Views
{
    public partial class FormMakeReservation : Form
    {
        private Context Context = new Context();
        public string user;
        public List<models.Menu> menuItems;
        public List<Plate> plates = new List<Plate>();
        public List<Extra> extras = new List<Extra>();
        public Ticket relevantTicket;
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
            //updatelistBoxExtras();
            //updatelistBoxPlates();
            updateComboBox();
            updatelistBoxMenus();
        }

        private void updateComboBox()
        {
            using (var context = new models.Context())
            {
                var names = context.Users.OfType<Client>().ToList();
                comboBoxClient.DataSource = null;
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
                foreach (models.Menu menu in menus ) 
                {
                    foreach(Plate plate in menu.Plates)
                    {
                        plates.Add(plate);
                    }
                    foreach(Extra extra in menu.Extras)
                    {
                        extras.Add(extra);
                    }
                }
                listBoxMenus.DataSource = null;
                listBoxMenus.DataSource = menus;
                listBoxMenus.ValueMember = "DisplayMenu";
                listBoxPlates.DataSource = null;
                listBoxPlates.DataSource = plates;
                listBoxExtras.DataSource = null;
                listBoxExtras.DataSource = extras;

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
            saveReservationData();
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
            //updatelistBoxExtras();
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

        private void sendToReservationList()
        {

        }

        private void addToListBoxReservations(Plate plate, List<Extra> selectedExtras)
        {
            string extrasNames = string.Join(", ", selectedExtras.Select(e => e.Description));
            string reservationDetails = $"Prato: {plate.Description}, Extras: {extrasNames}";
            listBoxReservations.Items.Add(reservationDetails);
        }
        private void saveReservationData()
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
            if (client is Client)
            {
                saveReservations(menu, plate, selectedExtras, client, relevantTicket);
                MessageBox.Show("Reserva guardada com sucesso");
            }
            else
            {
                MessageBox.Show("Falha ao gravar! Por favor selecione um cliente");
            }
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
            DateTime reservationTime = convertTimeFromString(dateTimePicker.Value, UpdateHour());
            double hoursUntilReservation = (reservationTime - DateTime.Now).TotalHours;

            relevantTicket = Context.Tickets.FirstOrDefault(t => hoursUntilReservation <= t.NumHours);
            if (relevantTicket != null)
            {
                totalCost += relevantTicket.Value;
            }
            else
            {
                relevantTicket.Value = 0;
                relevantTicket.NumHours = 0;
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
            if (client is Client)
            {
                using (var context = new models.Context())
                {
                    var dbClient = context.Users.OfType<Client>().FirstOrDefault(c => c.name == client.name);
                    if (dbClient.Balance >= totalCost)
                    {
                        dbClient.Balance -= totalCost;
                        context.SaveChanges();
                        MessageBox.Show($"Reserva feita com sucesso. Custo total: {totalCost:C}. O seu montante é: {dbClient.Balance:C}");
                    }
                    else
                    {
                        MessageBox.Show("Não tem dinheiro suficiente");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor selecione um cliente");
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
                listBoxExtras.DataSource = null;
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
                listBoxPlates.DataSource = null;
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
                    listBoxPlates.DataSource = null;
                    listBoxPlates.DataSource = plates;
                    listBoxPlates.DisplayMember = "ReservationName";
                }
                else
                {
                    listBoxPlates.DataSource = null;
                    MessageBox.Show("Sem pratos disponiveis para o menu");
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

        public void saveReservations(models.Menu menu, Plate plate, List<Extra> extras, Client client, Ticket relevantTicket)
        {
            using (models.Context context = new models.Context())
            {
                context.Users.Attach(client); // Correctly attach the client entity to the context

                Reservation reservation = new Reservation();
                reservation.Plates = context.Plates.Attach(plate); // Attach plate to context
                reservation.Extras = new List<Extra>(); // Initialize the list to avoid direct assignment

                foreach (var extra in extras)
                {
                    reservation.Extras.Add(context.Extras.Attach(extra)); // Attach each extra to context
                }

                reservation.Clients = client; // Directly assign the attached client to the reservation

                reservation.Menus = menu;

                reservation.Tickets = relevantTicket; // Example logic

                context.Reservations.Add(reservation);
                context.SaveChanges();
            }
        }

        private void listBoxExtras_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            calcTotal();
        }

        private void buttonAddReserve_Click(object sender, EventArgs e)
        {
            if (!ValidateExtrasSelection(listBoxExtras))
            {
                return;
            }
            Plate plate = (Plate)listBoxPlates.SelectedItem;
            List<Extra> selectedExtras = new List<Extra>();
            foreach (var item in listBoxExtras.SelectedItems)
            {
                selectedExtras.Add((Extra)item);
            }
            addToListBoxReservations(plate, selectedExtras);
        }
        private bool ValidateExtrasSelection(ListBox listBoxExtras)
        {
            if (listBoxExtras.SelectedItems.Count > 3)
            {
                MessageBox.Show("Só pode selecionar no máximo 3 extras", "Limite de seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateMenuTime(models.Menu menu, string reservationTime)
        {
            string menuTime = menu.Data.ToString("HH:mm");
            if (menuTime == reservationTime)
            {
                return true;
            }

            MessageBox.Show($"Hora da reserva {reservationTime} não é a mesma do menu : {menuTime}.", "Time Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loadAvailablePlates();
            loadAvailableExtras();
        }

        private void loadAvailablePlates()
        {
            using (var context = new models.Context())
            {
                var availablePlates = context.Plates.Where(p => p.Stock > 0).ToList();
                listBoxPlates.DataSource = availablePlates;
                listBoxPlates.DisplayMember = "ReservationName";
            }
        }

        private void loadAvailableExtras()
        {
            using (var context = new models.Context())
            {
                var availableExtras = context.Extras.Where(e => e.Stock > 0).ToList();
                listBoxExtras.DataSource = availableExtras;
                listBoxExtras.DisplayMember = "DisplayName";
            }
        }

        private bool UpdateStock(Plate plate, List<Extra> selectedExtras)
        {
            using (var context = new models.Context())
            {
                var selectedPlate = context.Plates.SingleOrDefault(p => p.idPlate == plate.idPlate);
                if (selectedPlate != null && selectedPlate.Stock > 0)
                {
                    selectedPlate.Stock -= 1;
                    if (selectedPlate.Stock == 0)
                    {
                        selectedPlate.Active = false;
                    }
                    else
                    {
                        selectedPlate.Active = true;
                    }
                }
                else
                {
                    MessageBox.Show($"Stock do prato não disponível: {selectedPlate?.Description}", "Erro de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                foreach (var extra in selectedExtras)
                {
                    var selectedExtra = context.Extras.SingleOrDefault(e => e.idExtra == extra.idExtra);
                    if (selectedExtra != null && selectedExtra.Stock > 0)
                    {
                        selectedExtra.Stock -= 1;
                        if (selectedExtra.Stock == 0)
                        {
                            selectedExtra.Active = false;
                        }
                        else
                        {
                            selectedExtra.Active = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Stock do extra não disponível: {selectedExtra?.Description}", "Erro de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                context.SaveChanges();
                return true;
            }
        }

        private void checkCheckBox(int hour)
        {
            if (hour == 12)
            {
                radioButtonLunch.Checked = true;
                radioButtonDinner.Checked = false;
            }
            else if (hour == 19)
            {
                radioButtonDinner.Checked = true;
                radioButtonLunch.Checked = false;
            }
        }
    }
}