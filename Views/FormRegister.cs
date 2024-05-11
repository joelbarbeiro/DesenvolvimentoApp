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
using iCantine.Controllers;

namespace iCantine.Views
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Preencha Username");
            }
            Employee employee = new Employee(username);
            Context context = new Context();
            context.Employees.Add(employee);
            try
            {
                context.SaveChanges();
                this.Close();
                FormController.openFormLogin();
            }catch (Exception )
            {
                MessageBox.Show("Registo Não Concluido");
                return;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            FormController.openFormLogin();
        }
    }
}
