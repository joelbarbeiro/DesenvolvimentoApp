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
        public List<models.Menu> menus;
        public List<Plate> plates;
        public List<Extra> extra;
        public FormReservationsMade(string user)
        {
            this.user = user;
            InitializeComponent();
            updateReservation();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }
        private void updateReservation()
        {
            using (var context = new models.Context())
            {
                var reservations = context.Reservations
                                          .Include(r => r.Clients) 
                                          .Include(r => r.Plates) 
                                          .Include(r => r.Menus) 
                                          .ToList();

                var reservationListItems = reservations.Select(r => $"Client: {r.Clients.Name}, Plate: {r.Plates.Description}".ToList());

                listBoxReservationMade.DataSource = reservationListItems;
            }
        }


    }
}
