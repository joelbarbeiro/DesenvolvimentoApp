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
        public Ticket relevantTicket = new Ticket();
        private string hour;
        ReceiptController receiptController = new ReceiptController();

        public FormMakeReservation(string user)
        {
            InitializeComponent();
            this.user = user;
            this.radioButtonLunch.CheckedChanged += new System.EventHandler(this.radioButtonLunch_CheckedChanged);
            this.radioButtonDinner.CheckedChanged += new System.EventHandler(this.radioButtonDinner_CheckedChanged);
            listBoxMenus.SelectedIndexChanged += listBoxMenus_SelectedIndexChanged;
            listBoxExtras.SelectedIndexChanged += listBoxExtras_SelectedIndexChanged;
            listBoxExtras.SelectionMode = SelectionMode.MultiSimple;
            getHour();
            changeUserLabel(user);
            updateComboBox();
        }

        private void updateComboBox()
        {
            var names = Context.Users.OfType<Client>().ToList();
            comboBoxClient.DataSource = null;
            comboBoxClient.DataSource = names;
            comboBoxClient.DisplayMember = "Name";
        }

        public void updatelistBoxMenus()
        {
            List<models.Menu> menus = new List<models.Menu>();
            plates.Clear();
            extras.Clear();
            DateTime selectedDate = dateTimePicker.Value;
            string[] timeParts = UpdateHour().Split(':');
            if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int hour) && int.TryParse(timeParts[1], out int minutes))
            {
                var query = Context.Menus.Where(
                menu =>
                menu.Data.Year == selectedDate.Year &&
                menu.Data.Month == selectedDate.Month &&
                menu.Data.Day == selectedDate.Day &&
                menu.Data.Hour == hour &&
                menu.Data.Minute == minutes &&
                menu.Plates.Any(p => p.Active))

                .Select(menu => new
                {
                    Menu = menu,
                    Plates = menu.Plates.Where(p => p.Active),
                    Extras = menu.Extras.Where(e => e.Active)
                }).AsEnumerable()
                    .Select(result =>
                    {
                        result.Menu.Plates = result.Plates.ToList(); // Materialize filtered Plates
                        result.Menu.Extras = result.Extras.ToList(); // Materialize filtered Extras
                        return result.Menu; // Return the Menu entity with filtered Plates and Extras
                    });
                menus = query.ToList();
            }
            if (menus.Count == 0)
            {
                listBoxPlates.DataSource = null;
                listBoxExtras.DataSource = null;
                MessageBox.Show("Sem menus na data escolhida");
            }
            else
            {
                foreach (models.Menu menu in menus)
                {
                    foreach (Plate plate in menu.Plates)
                    {
                        if (plate.Active)
                        {
                            plates.Add(plate);
                        }

                    }
                    foreach (Extra extra in menu.Extras)
                    {
                        if (extra.Active)
                        {
                            extras.Add(extra);
                        }
                    }
                }
                listBoxMenus.DataSource = null;
                listBoxMenus.DataSource = menus;
                listBoxMenus.ValueMember = "DisplayMenu";
                updateInMenusListBox();
            }
        }
        public void stockControlPlate(Plate plates)
        {
            var plateUpdate = Context.Plates.SingleOrDefault(m => m.idPlate == plates.idPlate);
            if (plateUpdate != null)
            {
                plateUpdate.Stock -= 1;
                if (plates.Stock == 0)
                {
                    plateUpdate.Active = false;
                }
                Context.SaveChanges();
            }
        }
        public void stockControlExtra(List<Extra> extras)
        {
            foreach (Extra extraItem in extras)
            {
                var extraUpdate = Context.Extras.SingleOrDefault(m => m.idExtra == extraItem.idExtra);
                if (extraUpdate != null)
                {
                    extraUpdate.Stock -= 1;
                    if (extraItem.Stock == 0)
                    {
                        extraUpdate.Active = false;
                    }
                    Context.SaveChanges();
                }
            }
        }

        private void buttonReserve_Click(object sender, EventArgs e)
        {
            decimal totalCost = calcTotal();
            Client client = (Client)comboBoxClient.SelectedItem;

            if (isBalanceSufficient(totalCost, client))
            {
                saveReservationData();
                UpdateClientBalance();
                updatelistBoxMenus();
                MessageBox.Show($"Reserva feita com sucesso. Custo total: {totalCost:C}. O seu montante é: {client.Balance:C}");
            }
            else
            {
                MessageBox.Show("Não tem dinheiro suficiente");
            }
            
        }

        private string UpdateHour()
        {
            string hour = string.Empty;
            if (radioButtonLunch.Checked)
            {
                hour = "12:00";
            }
            else if (radioButtonDinner.Checked)
            {
                hour = "19:00";
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

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
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
            updatelistBoxMenus();
        }

        private void radioButtonDinner_CheckedChanged(object sender, EventArgs e)
        {
            updatelistBoxMenus();
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
                if (validateExtrasSelection())
                {
                    saveReservations(menu, plate, selectedExtras, client);
                    stockControlExtra(selectedExtras);
                    stockControlPlate(plate);
                    listBoxReservations.Items.Clear();
                    MessageBox.Show("Reserva guardada com sucesso");
                }
            }
            else
            {
                MessageBox.Show("Falha ao gravar! Por favor selecione um cliente");
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

            labelPrice.Text = totalCost.ToString("C");
            return totalCost;
        }

        private void UpdateClientBalance()
        {
            decimal totalCost = calcTotal();
            Client client = (Client)comboBoxClient.SelectedItem;
            if (client is Client)
            {
                var dbClient = Context.Users.OfType<Client>().FirstOrDefault(c => c.name == client.name);
                if (dbClient.Balance >= totalCost)
                {
                    dbClient.Balance -= totalCost;
                    Context.SaveChanges();
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


        private void listBoxMenus_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateInMenusListBox();
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

        public bool saveReservations(models.Menu menu, Plate plate, List<Extra> extras, Client client)
        {
            try
            {
                Context.Users.Attach(client);

                Reservation reservation = new Reservation();
                reservation.Plates = Context.Plates.Attach(plate);
                reservation.Extras = new List<Extra>();

                foreach (var extra in extras)
                {
                    reservation.Extras.Add(Context.Extras.Attach(extra));
                }

                reservation.Clients = client;

                reservation.Menus = menu;

                reservation.Tickets = relevantTicket;

                Context.Reservations.Add(reservation);
                Context.SaveChanges();

                /*Receipt receipt = new Receipt(calcTotal(), menu.Data);
                receiptController.saveReceipt(receipt, client, menu, plate, extras);

                List<Receipt> receiptList = receiptController.loadReceipt(client);
                receiptController.genReceipt(receipt)*/
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private void listBoxExtras_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            calcTotal();
        }

        private void buttonAddReserve_Click(object sender, EventArgs e)
        {
            if (validateExtrasSelection())
            {
                Plate plate = (Plate)listBoxPlates.SelectedItem;
                List<Extra> selectedExtras = new List<Extra>();

                foreach (var item in listBoxExtras.SelectedItems)
                {
                    selectedExtras.Add((Extra)item);
                }
                addToListBoxReservations(plate, selectedExtras);
            }
        }
        private bool validateExtrasSelection()
        {
            if (listBoxExtras.SelectedItems.Count > 3)
            {
                MessageBox.Show("Só pode selecionar no máximo 3 extras", "Limite de seleção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listBoxExtras.ClearSelected();
                return false;

            }
            return true;
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
        private void updateInMenusListBox()
        {
            if (listBoxMenus.SelectedItem is models.Menu selectedMenu)
            {
                int menuId = selectedMenu.idMenu;
                if (plates.Count > 0)
                {
                    listBoxPlates.DataSource = null;
                    listBoxPlates.DataSource = selectedMenu.Plates;
                    listBoxExtras.DataSource = null;
                    listBoxExtras.DataSource = selectedMenu.Extras;
                }
                else
                {
                    listBoxPlates.DataSource = null;
                    MessageBox.Show("Sem pratos disponiveis para o menu");
                }
                calcTotal();
            }
        }

        private void getHour()
        {
            int currentHour = DateTime.Now.Hour;
            if (currentHour >= 12 || currentHour < 19)
            {
                radioButtonLunch.Checked = true;
            }
            if (currentHour >= 19 || currentHour < 0 && currentHour >= 0 || currentHour < 12)
            {
                radioButtonDinner.Checked = true;
            }
        }

        private bool isBalanceSufficient(decimal totalCost, Client client)
        {
            if (client is Client)
            {
                var dbClient = Context.Users.OfType<Client>().FirstOrDefault(c => c.name == client.name);
                if (dbClient.Balance >= totalCost)
                {
                    return true; 
                }
            }
            return false; 
        }

    }
}