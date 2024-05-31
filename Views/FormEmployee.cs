using iCantine.Controllers;
using iCantine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCantine.Views
{
    public partial class FormEmployee : Form
    {
        public string user;
        public FormEmployee(string user)
        {
            InitializeComponent();
            this.user = user;
            changeUserLabel(user);
            updateComboBox();
            AcceptButton = buttonChange;
        }

        private void changeUserLabel(string user)
        {
            labelEmployee.Text = CRUDController.CapitalizeFirstLetter(user);
        }

        public void updateComboBox()
        {
            models.Context context = new models.Context();
            var query = context.Users.OfType<Employee>().ToList();
            foreach ( var item in query )
            {
                comboBoxEmployee.Items.Add(item.username);
            }
        }


        private void comboBoxEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelEmployee.Text = comboBoxEmployee.SelectedItem.ToString();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            FormController.changeForm(formRegister, this);
        }

        private void buttonChange_Click_1(object sender, EventArgs e)
        {
            if (comboBoxEmployee.SelectedItem == null)
            {
                MessageBox.Show("Nenhum Funcionário selecionado");
                return;
            }
            else
            {
                string user = comboBoxEmployee.SelectedItem.ToString();
                MainForm mainForm = new MainForm(user);
                FormController.changeForm(mainForm, this);
            }
        }
    }
}
