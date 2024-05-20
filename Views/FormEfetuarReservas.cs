using iCantine.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCantine.Views
{
    public partial class FormEfetuarReservas : Form
    {
        public string user;
        public FormEfetuarReservas(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        public void labelPreço(object sender, EventArgs e)
        {
            if(labelPrice.Text == null)
            {
                labelPrice.Visible = false;
            }
            else
            {
                labelPrice.Visible = true;
            }
        }

        private void buttonReserve_Click(object sender, EventArgs e)
        {
            string username = textBoxCostumer.Text;
            if(string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Insira o nome do cliente");
                return;
            }
            //TODO
        }

        private void FormEfetuarReservas_Load(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }
    }
}
