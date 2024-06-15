using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iCantine.Controllers;
using iCantine.models;
using iCantine.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace iCantine.Views
{
    public partial class FormMenu : Form
    {
        public List<models.Menu> menuItems;
        public List<Plate> plates;
        public List<Extra> extra;
        public string user;
        private MenuController menuController = new MenuController();

        public FormMenu(string user)
        {
            InitializeComponent();

            this.user = user;
            labelUsername.Text = user;

            menuItems = menuController.getMenusOnDate(dateTimePicker1.Value);
            plates = menuController.loadPlatesMenu();
            extra = menuController.loadExtrasMenu();

            updateComboBox();
            updateMenuListBox();
            updatePlateListBox();
            updateExtraListBox();
            changeCreateMenuState();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            string user = labelUsername.Text;
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }

        private void updateComboBox()
        {
            PlateType plateType = new PlateType();
            comboBoxPlateType.Items.Clear();
            comboBoxPlateType.Items.Add("Todos");
            comboBoxPlateType.SelectedIndex = 0;
            foreach(string type in Enum.GetNames(typeof(PlateType.plateType)))
            {
                comboBoxPlateType.Items.Add(type);
            }
        }


        private void buttonCreateMenu_Click(object sender, EventArgs e)
        {
            if (buttonCreateMenu.Text == "Gravar")
            {
                if (validateDataMenu())
                {
                    List<Plate> selectedPlates = new List<Plate>();
                    List<Extra> selectedExtras = new List<Extra>();

                    int numSaves = 0;
                    while (numSaves < checkHours())
                    {
                        string[] hours = getHours();
                        DateTime day = dateTimePicker1.Value.ToUniversalTime();
                        DateTime dateToSave = convertTimeFromString(day, hours, numSaves);

                        foreach (var itemPlate in listBoxPlate.SelectedItems)
                        {
                            selectedPlates.Add((Plate)itemPlate);
                        }
                        foreach (var itemExtra in listBoxExtras.SelectedItems)
                        {
                            selectedExtras.Add((Extra)itemExtra);
                        }

                        int quantity = 0;
                        decimal studentPrice = 0;
                        decimal professorPrice = 0;
                        int.TryParse(textBoxQuantity.Text, out quantity);
                        decimal.TryParse(textBoxPriceStudent.Text, out studentPrice);
                        decimal.TryParse(textBoxPriceProfessor.Text, out professorPrice);

                        models.Menu menu = new models.Menu(dateToSave, quantity, studentPrice, professorPrice);

                        if (menuController.saveMenu(menu, selectedPlates, selectedExtras))
                        {
                            MessageBox.Show("Menu gravado com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Falha ao gravar!");
                        }

                        numSaves++;
                    }
                    menuItems = menuController.getMenusOnDate(dateTimePicker1.Value);
                    updateMenuListBox();
                    buttonCreateMenu.Text = "Adicionar";
                }
            }
            else if(buttonCreateMenu.Text == "Adicionar")
            {
                buttonCreateMenu.Text = "Gravar";
            }
            changeCreateMenuState();

        }

        private void buttonEditMenu_Click(object sender, EventArgs e)
        {
            var selectedMenu = new models.Menu();
            selectedMenu = (models.Menu)listBoxMenu.SelectedItem;

            if (buttonEditMenu.Text == "Editar")
            {
                editButtonState();

                textBoxQuantity.Text = selectedMenu.QuantAvailable.ToString();
                textBoxPriceStudent.Text = selectedMenu.PriceStudent.ToString();
                textBoxPriceProfessor.Text = selectedMenu.PriceProf.ToString();
                checkCheckBox(getSavedHour(selectedMenu.Data));

            } else if (buttonEditMenu.Text == "Gravar")
            {
                List<Plate> selectedPlates = new List<Plate>();
                List<Extra> selectedExtras = new List<Extra>();

                string[] hours = getHours();
                DateTime day = dateTimePicker1.Value.ToUniversalTime();
                DateTime dateToSave = convertTimeFromString(day, hours);

                int quantity = 0;
                decimal studentPrice = 0;
                decimal professorPrice = 0;
                int.TryParse(textBoxQuantity.Text, out quantity);
                decimal.TryParse(textBoxPriceStudent.Text, out studentPrice);
                decimal.TryParse(textBoxPriceProfessor.Text, out professorPrice);

                selectedMenu.Data = dateToSave;
                selectedMenu.QuantAvailable = quantity;
                selectedMenu.PriceStudent = studentPrice;
                selectedMenu.PriceProf = professorPrice;
                

                foreach (var itemPlate in listBoxPlate.SelectedItems)
                {
                    selectedPlates.Add((Plate)itemPlate);
                }
                foreach (var itemExtra in listBoxExtras.SelectedItems)
                {
                    selectedExtras.Add((Extra)itemExtra);
                }

                if (menuController.updateMenu(selectedMenu, selectedPlates, selectedExtras))
                {
                    MessageBox.Show("Menu gravado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Falha ao gravar!");
                }
                menuItems = menuController.getMenusOnDate(dateTimePicker1.Value);
                updateMenuListBox();
                editButtonState();
            }
        }

        private void changeCreateMenuState()
        {
            if (buttonCreateMenu.Text == "Gravar")
            {
                listBoxPlate.ClearSelected();
                listBoxExtras.ClearSelected();
                textBoxQuantity.Text = "0";
                textBoxQuantity.Enabled = true;
                textBoxPriceStudent.Text = "0";
                textBoxPriceStudent.Enabled = true;
                textBoxPriceProfessor.Text = "0";
                textBoxPriceProfessor.Enabled = true;
                checkBoxLunch.Checked = false;
                checkBoxDinner.Checked = false;
            }
            else if (buttonCreateMenu.Text == "Adicionar")
            {
                
                textBoxQuantity.Text = string.Empty;
                textBoxQuantity.Enabled = false;
                textBoxPriceStudent.Text = string.Empty;
                textBoxPriceStudent.Enabled = false;
                textBoxPriceProfessor.Text = string.Empty;
                textBoxPriceProfessor.Enabled = false;
                checkBoxLunch.Checked = false;
                checkBoxDinner.Checked = false;
            }
        }
        
        private bool validateDataMenu()
        {
            int tester = 0;
            int.TryParse(textBoxQuantity.Text, out tester);
            if (textBoxQuantity.Text == string.Empty || tester < 0)
            {
                MessageBox.Show("Não introduziu valor na quantidade");
                return false;
            }
            int.TryParse(textBoxPriceStudent.Text, out tester);
            if(textBoxPriceStudent.Text == string.Empty || tester < 0)
            {
                MessageBox.Show("Preço de estudante não foi introduzido");
                return false;
            }
            int.TryParse(textBoxPriceProfessor.Text, out tester);
            if(textBoxPriceProfessor.Text == string.Empty || tester < 0)
            {
                MessageBox.Show("Preço do professor não foi introduzido");
                return false;
            }
            return true;
        }

        private void comboBoxPlateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            plates = menuController.loadPlatesMenu(comboBoxPlateType.SelectedItem.ToString());
            updatePlateListBox();
        }

        private void updateMenuListBox()
        {
            listBoxMenu.DataSource = null;
            listBoxMenu.DataSource = menuItems;
        }

        private void updatePlateListBox()
        {
            listBoxPlate.DataSource = null;
            listBoxPlate.DataSource = plates;
        }
        private void updateExtraListBox()
        {
            listBoxExtras.DataSource = null;
            listBoxExtras.DataSource = extra;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value < DateTime.Now.AddDays(-1) || dateTimePicker1.Value > DateTime.Now.AddDays(7))
            {
                MessageBox.Show("Não pode selecionar um dia num range superior ou inferior a 7 dias.");
            }
            else
            {    
                menuItems = menuController.getMenusOnDate(dateTimePicker1.Value);
                updateMenuListBox();
            }
        }
        private string isLunch()
        {
            if(checkBoxLunch.Checked == true)
            {
                return "12:00";
            }
            return string.Empty;
        }
        private string isDinner()
        {
            if (checkBoxDinner.Checked == true)
            {
                return "19:00";
            }
            return string.Empty;
        }
        private DateTime convertTimeFromString(DateTime day, string[] hours, int numSaves = 0)
        {
            DateTime dateToSave = DateTime.Now;
            string[] timeParts = hours[numSaves].Split(':');
            if (timeParts.Length == 2 && int.TryParse(timeParts[0], out int hour) && int.TryParse(timeParts[1], out int minutes))
            {
                 dateToSave = new DateTime(
                    day.Year,
                    day.Month,
                    day.Day,
                    hour,
                    minutes,
                    0);
            }
            return dateToSave;

        }
        private int checkHours()
        {
            int i = 1;
            if (checkBoxLunch.Checked && checkBoxDinner.Checked)
            {
                i = 2;
            }

            return i;
        }
        private string[] getHours()
        {
            string[] hours = new string[2];
            int i = 0;
            if(checkBoxLunch.Checked == true )
            {
                hours[i] = isLunch();
                i++;
            }
            if (checkBoxDinner.Checked == true)
            {
                hours[i] = isDinner();
            }
            return hours;
        }

        private void textBoxPriceStudent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPriceStudent.Text != string.Empty)
                {
                    decimal student = decimal.Parse(textBoxPriceStudent.Text);
                    student = student * 1.2m;
                    textBoxPriceProfessor.Text = student.ToString();
                }
                
            }
            catch 
            {
                MessageBox.Show("Utilize a virgula em vez do ponto para separar as casas decimais!");
                textBoxPriceStudent.Text = string.Empty;
                textBoxPriceProfessor.Text = string.Empty;
            }
        }

        private void editButtonState()
        {
            if (buttonEditMenu.Text == "Editar") 
            {
                buttonBack.Enabled = false;
                buttonCreateMenu.Enabled = false;
                buttonDeleteMenu.Enabled = false;
                textBoxQuantity.Enabled = true;
                textBoxPriceStudent.Enabled = true;
                textBoxPriceProfessor.Enabled = true;
                buttonEditMenu.Text = "Gravar";
            }
            else if (buttonEditMenu.Text == "Gravar")
            {
                buttonBack.Enabled = true;
                buttonCreateMenu.Enabled = true;
                buttonDeleteMenu.Enabled = true;
                textBoxQuantity.Enabled = false;
                textBoxQuantity.Text = string.Empty;
                textBoxPriceStudent.Enabled = false;
                textBoxPriceStudent.Text = string.Empty;
                textBoxPriceProfessor.Enabled = false;
                textBoxPriceProfessor.Text = string.Empty;
                checkBoxLunch.Checked = false;
                checkBoxDinner.Checked = false;
                buttonEditMenu.Text = "Editar";
            }
        }


        private int getSavedHour(DateTime savedDateTime)
        {
            return (int)savedDateTime.Hour;
        }
        private void checkCheckBox(int hour)
        {
            if (hour == 12) 
            {
                checkBoxLunch.Checked = true;
                checkBoxDinner.Checked = false;
            }
            else if (hour == 19)
            {
                checkBoxDinner.Checked = true;
                checkBoxLunch.Checked = false;
            }
        }

        public void buttonDeleteMenu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tem a certesa que quer eliminar o menu selecionado?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Handle the result
            if (result == DialogResult.OK)
            {
                var selectedMenu = new models.Menu();
                selectedMenu = (models.Menu)listBoxMenu.SelectedItem;

                if (menuController.deleteMenu(selectedMenu))
                {
                    MessageBox.Show("Menu eliminado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao eliminar o menu!");
                }
            }
            updateMenuListBox();
        }

        private void listBoxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMenu = new models.Menu();
            selectedMenu = (models.Menu)listBoxMenu.SelectedItem;
            if (selectedMenu != null && menuItems != null)
            {
                listBoxPlate.ClearSelected();
                listBoxExtras.ClearSelected();

                textBoxQuantity.Text = selectedMenu.QuantAvailable.ToString();
                textBoxPriceStudent.Text = selectedMenu.PriceStudent.ToString();
                textBoxPriceProfessor.Text = selectedMenu.PriceProf.ToString();

                checkCheckBox(getSavedHour(selectedMenu.Data));

                if (listBoxPlate.Items.Count > 0)
                {
                    foreach (var item in selectedMenu.Plates)
                    {
                        listBoxPlate.SetSelected(item.idPlate-1, true);
                    }
                }
                if (listBoxExtras.Items.Count > 0)
                {
                    foreach (var item in selectedMenu.Extras)
                    {
                        listBoxExtras.SetSelected(item.idExtra-1, true);
                    }
                }
            }
        }

        private void listBoxPlate_SelectedIndexChanged(object sender, ItemCheckEventArgs e)
        {
            if (listBoxPlate.SelectedItems.Count > 3)
            {
                e.NewValue = CheckState.Unchecked;

                // Optionally, provide feedback to the user
                MessageBox.Show($"You can only check up to items.");
            } 
        }
    }
}
