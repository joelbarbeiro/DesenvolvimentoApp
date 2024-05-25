﻿using iCantine.Controllers;
using iCantine.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCantine.models
{
    public partial class FormReservationsOptions : Form
    {
        private string user;
        public FormReservationsOptions(string user)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMakeReservation formReservations = new FormMakeReservation(user);
            FormController.changeForm(formReservations, this);
        }
    }
}
