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
            updateInactiveReservations();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }

        private void updateReservation()
        {
            var reservations = Context.Reservations

                                      .Include(r => r.Clients)
                                      .Include(r => r.Plates)
                                      .Include(r => r.Menus)
                                      .Include(r => r.Extras)
                                      .Where(r => r.Active)
                                      .ToList();

            listBoxReservationMade.DataSource = reservations;

        }

        private void updateInactiveReservations()
        {
            var reservations = Context.Reservations
                                  .Include(r => r.Clients)
                                  .Include(r => r.Plates)
                                  .Include(r => r.Menus)
                                  .Include(r => r.Extras)
                                  .Where(r => !r.Active) // Only get inactive reservations
                                  .ToList();

            listBoxReservationDone.DataSource = reservations;
        }

        private void buttonAddReservaEf_Click(object sender, EventArgs e)
        {
            if (listBoxReservationMade.SelectedItem != null)
            {
                var selectedReservation = listBoxReservationMade.SelectedItem as Reservation;
                selectedReservation.Active = false;
                Context.Reservations.Attach(selectedReservation);
                Context.Entry(selectedReservation).Property(r => r.Active).IsModified = true;
                Context.SaveChanges();
                removeSelectedReservation(selectedReservation);
                updateListBoxDone(selectedReservation);
            }
        }

        private void removeSelectedReservation(Reservation selectedReservation)
        {
            var reservationsList = listBoxReservationMade.DataSource as List<Reservation>;
            reservationsList.Remove(selectedReservation);
            updateListBoxReservationsMade(reservationsList);
        }

        private void updateListBoxDone(Reservation selectedReservation)
        {

            var reservationDoneList = listBoxReservationDone.DataSource as List<Reservation> ?? new List<Reservation>();
            reservationDoneList.Add(selectedReservation);
            updateListBoxReservationsDone(reservationDoneList);

        }

        private void updateListBoxReservationsMade(List<Reservation> reservationsList)
        {
            listBoxReservationMade.DataSource = null;
            listBoxReservationMade.DataSource = reservationsList;
        }

        private void updateListBoxReservationsDone(List<Reservation> reservationDoneList)
        {
            listBoxReservationDone.DataSource = null;
            listBoxReservationDone.DataSource = reservationDoneList;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedReservations = listBoxReservationDone.SelectedItems.Cast<Reservation>().ToList();
            foreach (var reservation in selectedReservations)
            {
                Context.Reservations.Attach(reservation);
                Context.Reservations.Remove(reservation);
            }
            Context.SaveChanges();

            var reservationDoneList = listBoxReservationDone.DataSource as List<Reservation>;
            foreach(var reservation in selectedReservations)
            {
                reservationDoneList.Remove(reservation);
            }

            updateListBoxReservationsDone(reservationDoneList);
        }
    }
}
