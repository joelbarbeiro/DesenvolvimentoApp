﻿using iCantine.Controllers;
using iCantine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCantine.Views
{
    public partial class FormMakeReservation : Form
    {
        public string user;
        private List<Plate> plates;
        private List<Extra> extra;
        private List<Client> clients;

        public FormMakeReservation(string user)
        {
            InitializeComponent();
            this.user = user;
            this.plates = CRUDController.loadPlatesMenu();
            this.extra = CRUDController.loadExtrasMenu();
            changeUserLabel(user);
            updateListBoxExtras();
            updateListBoxPlates();
            updateComboBox();
            updateListBoxReservations();
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
            string plate = listBoxPlates.SelectedItem.ToString();
            string extra = listBoxExtras.SelectedItem.ToString();
            string client = comboBoxClient.SelectedItem.ToString();
            string date = dateTimePicker.Value.Date.ToString("d");

            if (validationControl(plate, extra, client))
            {
                Reservation reservation = new Reservation(plate, extra, client, date);
                Context context = new Context();
                try
                {
                    context.Reservations.Add(reservation);
                    context.SaveChanges();
                    MessageBox.Show("Reserva guardada com sucesso");
                    updateListBoxReservations();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
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
        private bool validationControl(string plate, string extra, string client)
        {
            if (string.IsNullOrEmpty(extra))
            {
                MessageBox.Show("Selecione um extra.");
                return false;
            }
            if (string.IsNullOrEmpty(plate))
            {
                MessageBox.Show("Selecione um Plate.");
                return false;
            }
            if (string.IsNullOrEmpty(client))
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
            DateTime selectedDate = dateTimePicker.Value;
            DateTime MaxAllowedDate = DateTime.Now.AddDays(7);
            if (selectedDate < MaxAllowedDate)
            {
                MessageBox.Show("Data inválida");
                dateTimePicker.Value = DateTime.Now;
                return;
            }
        }
    }
}
