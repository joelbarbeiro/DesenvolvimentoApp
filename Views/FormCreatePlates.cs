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

namespace iCantine.Views
{
    public partial class FormCreatePlates : Form
    {
        private bool isEditMode = false;
        public string user;
        public FormCreatePlates(string user)
        {
            InitializeComponent();
            this.user = user;
            updateListBoxPlates();
            changeUserLabel(user);
            updateComboBox();
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            string description = textBoxDescription.Text;
            double price = (double)priceUpDown.Value;
            int stock = (int)stockUpDown.Value;
            string type = comboBoxType.Text;

            if (validationControl(price, description, type))
            {
                Plate plate = new Plate(description, type, stock, price);
                Context context = new Context();
                try
                {
                    plate.Active = stockControl(stock);
                    context.Plates.Add(plate);
                    context.SaveChanges();
                    MessageBox.Show("Prato guardado com sucesso");
                    updateListBoxPlates();
                    clearTextBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }

        }
        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (listBoxPlates.SelectedItem == null)
            {
                MessageBox.Show("Selecione um prato para eliminar");
                return;
            }
            var selectedPlate = (Plate)listBoxPlates.SelectedItem;
            var confirmDelete = MessageBox.Show($"Tem a certeza que quer apagar o prato: {listBoxPlates.SelectedItem.ToString()}?", "Confirmar", MessageBoxButtons.YesNo);

            if (confirmDelete == DialogResult.Yes)
            {
                using (var context = new models.Context())
                {
                    var deletePlate = context.Plates.OfType<Plate>().SingleOrDefault(u => u.idPlate == selectedPlate.idPlate);
                    if (deletePlate != null)
                    {
                        context.Plates.Remove(deletePlate);
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Prato eliminado com sucesso.");
                            updateListBoxPlates();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao apagar prato: {ex.Message}");
                        }
                    }
                }
            }

        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!isEditMode)
            {
                if (listBoxPlates.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um plate para editar");
                    return;
                }
                buttonEdit.Text = "Guardar";
                isEditMode = true;

                var selectedPlate = (Plate)listBoxPlates.SelectedItem;

                textBoxDescription.Text = selectedPlate.Description;
                priceUpDown.Value = (decimal)selectedPlate.Price;
                stockUpDown.Value = selectedPlate.Stock;
                comboBoxType.Text = selectedPlate.Type;
                listBoxPlates.Enabled = false;
                if (negativeStockControl(selectedPlate.Stock))
                {
                    saveData(selectedPlate);
                    addControl();
                }

            }
            else
            {
                if (listBoxPlates.SelectedItem == null)
                {
                    MessageBox.Show("Selecione um plate para guardar");
                    return;
                }

                var selectedPlate = (Plate)listBoxPlates.SelectedItem;

                selectedPlate.Description = textBoxDescription.Text;
                selectedPlate.Price = (double)priceUpDown.Value;
                selectedPlate.Stock = (int)stockUpDown.Value;
                selectedPlate.Type = comboBoxType.Text;

                if (negativeStockControl(selectedPlate.Stock))
                {
                    saveData(selectedPlate);
                    updateListBoxPlates();
                    clearTextBox();
                    MessageBox.Show("As alterações foram guardadas com sucesso");

                    buttonEdit.Text = "Editar";
                    isEditMode = false;
                    listBoxPlates.Enabled = true;
                    addControl();
                    
                }


            }
        }
        public void updateListBoxPlates()
        {
            using (var context = new models.Context())
            {
                var plates = context.Plates
                    .OfType<Plate>()
                    .ToList();
                listBoxPlates.DataSource = plates;
                listBoxPlates.DisplayMember = "DisplayName";
            }
        }

        public void changeUserLabel(string user)
        {
            labelUsername.Text = user;
        }

        
        private bool validationControl(double price, string description, string type)
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
            if(string.IsNullOrEmpty(type))
            {
                MessageBox.Show("Selecione um tipo");
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
        private void clearTextBox()
        {
            textBoxDescription.Text = "";
            priceUpDown.Value = 0;
            stockUpDown.Value = 0;
            comboBoxType.SelectedIndex = 0;
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            string user = labelUsername.Text;
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }
        
        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }
        private void updateComboBox()
        {
            PlateType plateType = new PlateType();
            comboBoxType.Items.Clear();
            foreach (string type in Enum.GetNames(typeof(PlateType.plateType)))
            {
                comboBoxType.Items.Add(type);
            }
        }
        

        private void buttonBack_Click_1(object sender, EventArgs e)
        {
            string user = labelUsername.Text;
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
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
        private void saveData(Plate selectedPlate)
        {
            using (var context = new models.Context())
            {
                var dbPlate = context.Plates.SingleOrDefault(b => b.idPlate == selectedPlate.idPlate);
                if (dbPlate != null)
                {
                    dbPlate.Description = selectedPlate.Description;
                    dbPlate.Price = selectedPlate.Price;
                    dbPlate.Stock = selectedPlate.Stock;
                    dbPlate.Type = selectedPlate.Type;

                    context.SaveChanges();
                }
            }
        }
        private void addControl()
        {
            if (!isEditMode)
            {
                buttonAdd.Enabled = true;
                return;
            }
            else
            {
                buttonAdd.Enabled = false;
                return;
            }
        }

        
    }
}
