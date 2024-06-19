using iCantine.Controllers;
using iCantine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace iCantine.Views
{
    public partial class FormTicket : Form
    {
        public string user;
        models.Context context = new models.Context();
        public FormTicket(string user)
        {
            InitializeComponent();
            this.user = user;
            changeUserLabel(user);
            updateListBoxTicket();
        }
        private void changeUserLabel(string user)
        {
            labelEmployee.Text = CRUDController.CapitalizeFirstLetter(user);
        }
        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            FormEmployee formEmployee = new FormEmployee(user);
            FormController.changeForm(formEmployee, this);
        }

        private void saveTicket()
        {
            try
            {
                decimal value = numericUpDownValue.Value;
                int numHours = 0;
                int.TryParse(numericUpDownHours.Text, out numHours);
                if (numHours > 0)
                {
                    if (value > 0)
                    {
                        models.Ticket ticket = new models.Ticket(value, numHours);
                        context.Tickets.Add(ticket);
                        context.SaveChanges();
                        MessageBox.Show("Valores da multa guardados com sucesso");
                        numericUpDownHours.Value = 0;
                        numericUpDownValue.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("O valor da multa não pode ser 0!");
                    }
                }
                else
                {
                    MessageBox.Show("O numero de horas não pode ser 0!");
                }
            }
            catch
            {
                MessageBox.Show("Erro ao guardar os valores da multa: ");
            }
        }
        private void editTicket(Ticket ticket)
        {

            if (ticket != null)
            {
                ticket.Value = numericUpDownValue.Value;
                ticket.NumHours = (int)numericUpDownHours.Value;
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Multa editada com sucesso");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao editar multa:" + ex);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Nenhum cliente selecionado");
                return;
            }
        }



        private void deleteTicket(Ticket ticket)
        {
            try
            {
                context.Tickets.Remove(ticket);
                context.SaveChanges();
                MessageBox.Show("Multa eliminada com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao eliminar multa: " + ex.Message);
            }
        }
        private void updateListBoxTicket()
        {
            listBoxTicket.DataSource = null;
            listBoxTicket.DataSource = context.Tickets.ToList();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }

        private void buttonAddTicket_Click(object sender, EventArgs e)
        {
            saveTicket();
            updateListBoxTicket();
        }

        private void buttonDeleteTicket_Click(object sender, EventArgs e)
        {
            if (listBoxTicket.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma Multa para eliminar");
                return;
            }

            var selectedTicket = listBoxTicket.SelectedItem as Ticket;

            var confirmResult = MessageBox.Show
                ("Tem a certeza que quer apagar esta multa ?",
                "Confirmação",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                deleteTicket(selectedTicket);
                updateListBoxTicket();
            }
            return;
        }
        private void editMode()
        {
            buttonAddTicket.Visible = true;
            buttonDeleteTicket.Visible = true;
            buttonEditTicket.Text = "Editar";
            numericUpDownValue.Value = 0;
            numericUpDownHours.Value = 0;
        }
        private void saveMode()
        {
            buttonDeleteTicket.Visible = false;
            buttonAddTicket.Visible = false;
            buttonEditTicket.Text = "Gravar";
        }
        private void buttonEditTicket_Click(object sender, EventArgs e)
        {
            var selectedTicket = listBoxTicket.SelectedItem as Ticket;

            if (selectedTicket == null)
            {
                MessageBox.Show("Selecione uma Multa para editar");
                return;
            }

            if (buttonEditTicket.Text == "Editar")
            {
                saveMode();
                numericUpDownHours.Value = selectedTicket.NumHours;
                numericUpDownValue.Value = selectedTicket.Value;
            }
            else if (buttonEditTicket.Text == "Gravar")
            {
                selectedTicket.NumHours = (int)numericUpDownHours.Value;
                selectedTicket.Value = numericUpDownValue.Value;
                editTicket(selectedTicket);
                updateListBoxTicket();
                editMode();
            }
        }
    }
}
