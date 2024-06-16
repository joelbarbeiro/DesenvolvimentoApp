using iCantine.Controllers;
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
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace iCantine.Views
{
    public partial class FormReservationsMade : Form
    {
        public string user;
        private models.Context Context = new models.Context();
        public List<models.Menu> menuItems;
        public List<Plate> plates;
        public List<Extra> extra;
        public FormReservationsMade(string user)
        {
            this.user = user;
            InitializeComponent();
        }


        private void FormReservasEfetuadas_Load(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }



        private void LoadReservations()
        {
            using (var context = new models.Context())
            {
                var reservations = context.Reservations
                                          .Include(r => r.Clients)
                                          .Include(r => r.Menus)
                                          .Include(r => r.Plates)
                                          .Include(r => r.Extras)
                                          .ToList();

                listBoxReserveMade.Items.Clear();
                foreach (var reservation in reservations)
                {
                    listBoxReserveMade.Items.Add(reservation.ToString());
                }
            }
        }


        private void buttonAddReservaEf_Click(object sender, EventArgs e)
        {
            /*if (listBoxReserveMade.SelectedItem == null) return;

            var selectedReservation = (Reservation)listBoxReserveMade.SelectedItem;
            selectedReservation.Active = false;

            Context.SaveChanges();

            LoadReservations();*/
        }
    }
}
