﻿using iCantine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iCantine.Controllers;
using iCantine.Views;

namespace iCantine
{
    public partial class MainForm : Form
    {
        private Employee user;
        public MainForm(Employee user)
        {
            InitializeComponent();
            this.user = user;
            changeUserLabel(user);
        }
        private void changeUserLabel(Employee user)
        {
            labelUsername.Text=user.username.ToString();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            //FormController.logoutForm(this);
            FormLogin loginForm = new FormLogin();
            FormController.changeForm(loginForm, this);
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu(user);
            FormController.changeForm(formMenu, this);
        }
    }
}
