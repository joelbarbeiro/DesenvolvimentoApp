﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iCantine.Controllers;
using iCantine.models;

namespace iCantine.Views
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            FormController.changeForm(formRegister,this); 
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            if(string.IsNullOrEmpty(username) )
            {
                MessageBox.Show("Não inseriu Username");
                return;
            }
            Context context = new Context();
            var query_result = context.Employees.Where(
                employee =>
                employee.username == username);
            if(query_result.Count() == 0)
            {
                MessageBox.Show("Login Falhado");
                return;
            }
            Employee user = query_result.First();
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }
    }
}