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
            decimal balance = numericBalance.Value;
            if (numericBalance.Value > 0)
            {
                client.Balance += balance;
            }
            else
            {
                MessageBox.Show("Valor tem de ser superior a zero");
                return;
            }
            Context context = new Context();
            try
            {
                var userToUpdate = context.Users.OfType<Client>().SingleOrDefault(u => u.nif == client.nif);
                if (userToUpdate != null)
                {
                    if (userToUpdate is Student student)
                    {
                        if (numericBalance.Value > 0)
                        {
                            student.Balance += balance;
                        }
                        else
                        {
                            MessageBox.Show("Valor tem de ser superior a zero");
                            return;
                        }
                    }
                    else if (userToUpdate is Professor professor)
                    {
                        if (numericBalance.Value > 0)
                        {
                            professor.Balance += balance;
                        }
                        else
                        {
                            MessageBox.Show("Valor tem de ser superior a zero");
                            return;
                        }

                    }
                    context.SaveChanges();
                }
                MessageBox.Show("Saldo Carregado com sucesso!");
                FormCustomer customerForm = new FormCustomer(user);
                FormController.changeForm(customerForm, this);
            }
            catch (Exception)
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
