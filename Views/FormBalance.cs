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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace iCantine.Views
{
    public partial class FormBalance : Form
    {
        public Client client = new Client();
        public FormBalance(Client client, string user)
        {
            InitializeComponent();
            this.client = client;
            labelClient.Text = client.name;
            labelEmployee.Text = user;
            labelBalance.Text = client.Balance.ToString();
        }

        private void buttonCharge_Click(object sender, EventArgs e)
        {
            updateClientBalance(client);
            labelBalance.Text = client.Balance.ToString();
        }

        private void updateClientBalance(Client client)
        {
            string user = labelEmployee.Text;
            double balance = 0;
            double.TryParse(numericBalance.Text, out balance);
            client.Balance += balance;
            Context context = new Context();
            try
            {
                var userToUpdate = context.Users.OfType<Client>().SingleOrDefault(u => u.name == client.name);
                if (userToUpdate != null)
                {
                    if (userToUpdate is Student student)
                    {
                        student.Balance += balance;
                       
                    }
                    else if (userToUpdate is Professor professor)
                    {
                        professor.Balance += balance;
                        
                    }
                    context.SaveChanges();
                }
                MessageBox.Show("Saldo Carregado com sucesso!");
                FormCustomer customerForm = new FormCustomer(user);
                FormController.changeForm(customerForm, this);
            }
            catch(Exception )
            {
                MessageBox.Show("Não foi possivel carregar o saldo");
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            string user = labelEmployee.Text;
            FormCustomer customerForm = new FormCustomer(user);
            FormController.changeForm(customerForm, this);
        }
    }
}
