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
        private bool isEditMode = false;
        public string user;
        public string description;
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
            decimal price = (decimal)priceUpDown.Value;
            int stock = (int)stockUpDown.Value;

            if(validationControl(price, description))
            {
                Extra extra = new Extra(description, price, stock);
                Context context = new Context();
                try
                {
                    negativeStockControl(stock);
                    extra.Active = stockControl(stock);
                    context.Extras.Add(extra);
                    context.SaveChanges();
                    MessageBox.Show("Extra guardado com sucesso");
                    updateListBoxExtra();
                    clearTextBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                    return;
                }
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
            stockUpDown.Value = 0;
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
        

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if(!isEditMode) { 
                if(listBoxExtras.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um extra para editar");
                    return;
                }
                buttonEdit.Text = "Guardar";
                isEditMode = true;

                var selectedExtra = (Extra)listBoxExtras.SelectedItem;

                textBoxDescription.Text = selectedExtra.Description;
                priceUpDown.Value = (decimal)selectedExtra.Price;
                stockUpDown.Value = selectedExtra.Stock;
                listBoxExtras.Enabled = false;
                if (negativeStockControl(selectedExtra.Stock))
                {
                    saveData(selectedExtra);
                    addControl();
                }
                
            } 
            else
            {
                if (listBoxExtras.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um extra para guardar");
                    return;
                }

                var selectedExtra = (Extra)listBoxExtras.SelectedItem;

                selectedExtra.Description = textBoxDescription.Text;
                selectedExtra.Price = (decimal)priceUpDown.Value;
                selectedExtra.Stock = (int)stockUpDown.Value;

                if (negativeStockControl(selectedExtra.Stock))
                {
                    saveData(selectedExtra);
                    updateListBoxExtra();
                    clearTextBox();
                    MessageBox.Show("As alterações foram guardadas com sucesso");

                    buttonEdit.Text = "Editar";
                    isEditMode = false;
                    listBoxExtras.Enabled = true;
                    addControl();
                }
               
                
            }
        }

        private bool validationControl(decimal price, string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                MessageBox.Show("A descrição não pode estar vazia.");
                return false;
            }
            if (price <= 0)
            {
                MessageBox.Show("O preço deve ser maior que zero.");
                return false;
            }
            return true;
        }

        private bool stockControl(int stock)
        {
            if (stock > 0)
            {
                return true;
            }
            return false;
        }

        private void addControl()
        {
            if (!isEditMode)
            {
                buttonAddExtra.Enabled = true;
                return;
            }
            else
            {
                buttonAddExtra.Enabled = false;
                return;
            }
        }

        private bool negativeStockControl(int stock)
        {
            if (stock < 1)
            {
                MessageBox.Show("Quantidade em stock têm de ser um numero inteiro");
                return false;
            }
            return true;  
        }
        
       private void saveData(Extra selectedExtra)
        {
            using (var context = new models.Context())
            {
                var dbExtra = context.Extras.SingleOrDefault(b => b.idExtra == selectedExtra.idExtra);
                if (dbExtra != null)
                {
                    dbExtra.Description = selectedExtra.Description;
                    dbExtra.Price = selectedExtra.Price;
                    dbExtra.Stock = selectedExtra.Stock;
                    dbExtra.Active = stockControl(selectedExtra.Stock); //experimental


                    context.SaveChanges();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxExtras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um extra para eliminar");
                return;
            }
            var selectedExtra = (Extra)listBoxExtras.SelectedItem;
            var confirmDelete = MessageBox.Show($"Tem a certeza que quer apagar o extra: {listBoxExtras.SelectedItem.ToString()}?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirmDelete == DialogResult.Yes)
            {
                using (var context = new models.Context())
                {
                    var deleteExtra = context.Extras.OfType<Extra>().SingleOrDefault(u => u.idExtra == selectedExtra.idExtra);
                    if (deleteExtra != null)
                    {
                        context.Extras.Remove(deleteExtra);
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Extra eliminado com sucesso.");
                            updateListBoxExtra();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao apagar Extra: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}
