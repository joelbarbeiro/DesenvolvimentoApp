using iCantine.Controllers;
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
    public partial class FormCreateExtras : Form
    {
        public string user;
        public FormCreateExtras(string user)
        {
            InitializeComponent();
            this.user = user;
            updateListBoxExtra();
            changeUserLabel(user);
        }

        private void buttonAddExtra_Click(object sender, EventArgs e)
        {
            string description = textBoxDescription.Text;
            double price = (double)priceUpDown.Value;

            if(string.IsNullOrEmpty(description))
            {
                MessageBox.Show("A descrição não pode estar vazia.");
                return;
            }

            if(price <= 0)
            {
                MessageBox.Show("O preço deve ser maior que zero.");
                return;
            }

            Extra extra = new Extra(description, price);
            Context context = new Context();
            try
            {
                context.Extras.Add(extra);
                context.SaveChanges();
                MessageBox.Show("Extra guardado com sucesso");
                updateListBoxExtra();
                clearTextBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            } 
        }
        public void updateListBoxExtra()
        {
            using (var context = new models.Context())
            {
                var extras = context.Extras
                    .OfType<Extra>()
                    .ToList();
                listBoxExtras.DataSource = extras;
                listBoxExtras.DisplayMember = "DisplayName";
            }
        }
        private void clearTextBox()
        {
            textBoxDescription.Text = "";
            priceUpDown.Value = 0;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            string user = labelUsername.Text;
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
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxExtras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um extra para eliminar");
                return;
            }
            var selectedExtra = (Extra)listBoxExtras.SelectedItem;
            var confirmDelete = MessageBox.Show($"Tem a certeza que quer apagar o extra: {selectedExtra}€?", "Confirmar", MessageBoxButtons.YesNo);

            if(confirmDelete == DialogResult.Yes)
            {
                using(var context = new models.Context())
                {
                    var deleteExtra = context.Extras.OfType<Extra>().SingleOrDefault(u => u.idExtra == selectedExtra.idExtra);
                    if(deleteExtra != null)
                    {
                        context.Extras.Remove(deleteExtra);
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Extra eliminado com sucesso.");
                            updateListBoxExtra();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"Erro ao apagar Extra: {ex.Message}");
                        }
                    }
                }
            }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(listBoxExtras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um extra para editar");
                return;
            }
            var selectedExtra = (Extra)listBoxExtras.SelectedItem;
            textBoxDescription.Text = selectedExtra.Description;
            priceUpDown.Value = (decimal)selectedExtra.Price;
        }
    }
}
