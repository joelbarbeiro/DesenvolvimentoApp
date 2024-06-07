using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
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

        public FormMenu(string user)
        {
            InitializeComponent();

            this.user = user;
            labelUsername.Text = user;

            //menuItems = menuController.loadMenu();
            plates = menuController.loadPlatesMenu();
            extra = menuController.loadExtrasMenu();

            updateComboBox();
            updateMenuListBox();
            updatePlateListBox();
            updateExtraListBox();
            changeTextBoxState();
            
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
            if (validateDataMenu())
            {
                List<models.Extra> extras = new List<models.Extra>();

                int numSaves = 0;
                while (numSaves < checkHours())
                {
                    string[] hours = getHours();
                    DateTime day = dateTimePicker1.Value.ToUniversalTime();
                    DateTime hour = convertTimeFromString(hours[numSaves]);
                    Plate plate = menuController.getPlate(listBoxPlate.Text);
                    foreach(var itemExtra in listBoxExtras.SelectedItems)
                    {
                        extras.Add(menuController.getExtra(itemExtra.ToString()));
                    }

                    int quantity = 0;
                    decimal studentPrice = 0;
                    decimal professorPrice = 0;
                    int.TryParse(textBoxQuantity.Text, out quantity);
                    decimal.TryParse(textBoxPriceStudent.Text, out studentPrice);
                    decimal.TryParse(textBoxPriceProfessor.Text, out professorPrice);

                    models.Menu menu = new models.Menu(day,hour, quantity, studentPrice, professorPrice);
                    menuController.saveMenu(menu,plate, extras);
                    numSaves++;
                }
                //menuItems = menuController.loadMenu();
                updateMenuListBox();
            }
        }

        private void listBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTextBoxState();
        }

        private void listBoxPlate_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTextBoxState();
        }

        private void listBoxExtras_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTextBoxState();
        }

        private void changeTextBoxState()
        {
            if (checkBoxLunch.Checked == true || checkBoxDinner.Checked == true && listBoxPlate.SelectedItem != null)
            {
                textBoxQuantity.Enabled = true;
                textBoxPriceStudent.Enabled = true;
                textBoxPriceProfessor.Enabled = true;
            }
            else
            {
                textBoxQuantity.Text = string.Empty;
                textBoxQuantity.Enabled = false;
                textBoxPriceStudent.Text = string.Empty;
                textBoxPriceStudent.Enabled = false;
                textBoxPriceProfessor.Text = string.Empty;
                textBoxPriceProfessor.Enabled = false;
            }
        }
        
        private bool validateDataMenu()
        {
            int tester = 0;
            if(textBoxQuantity.Text == string.Empty) 
            {
                MessageBox.Show("Não introduziu valor na quantidade");
                return false;
            }
            if(textBoxPriceStudent.Text == string.Empty)
            {
                MessageBox.Show("Preço de estudante não foi introduzido");
                return false;
            }
            if(textBoxPriceProfessor.Text == string.Empty)
            {
                MessageBox.Show("Preço do professor não foi introduzido");
                return false;
            }
            int.TryParse(textBoxQuantity.Text, out tester);
            if (tester < 0)
            {
                MessageBox.Show("Não introduziu valor na quantidade");
                return false;
            }
            int.TryParse(textBoxPriceStudent.Text, out tester);
            if (tester < 0)
            {
                MessageBox.Show("Preço de estudante não foi introduzido");
                return false;
            }
            int.TryParse(textBoxPriceProfessor.Text, out tester);
            if (tester < 0)
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
            if(dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("Não pode criar menus com a data anterior ao dia de hoje.");
            }
            if(dateTimePicker1.Value > DateTime.Now.AddDays(7))
            {
                MessageBox.Show("Não pode selecionar um dia num range superior a 7 dias.");
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
        private DateTime convertTimeFromString(string str)
        {
            return DateTime.ParseExact(isLunch(), "HH:mm", CultureInfo.InvariantCulture);
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
                decimal student = decimal.Parse(textBoxPriceStudent.Text);
                student = student * 1.2m;
                textBoxPriceProfessor.Text = student.ToString();
            }
            catch 
            {
                    MessageBox.Show("Utilize a virgula em vez do ponto para separar as casas decimais!");
                textBoxPriceStudent.Text = string.Empty;
                textBoxPriceProfessor.Text = string.Empty;
            }
        }

        private void checkBoxLunch_CheckedChanged(object sender, EventArgs e)
        {
            changeTextBoxState();
        }

        private void checkBoxDinner_CheckedChanged(object sender, EventArgs e)
        {
            changeTextBoxState();
        }
        private void changeButtonAddState()
        {
            if(textBoxQuantity.Text != string.Empty && textBoxPriceStudent.Text != string.Empty && textBoxPriceProfessor.Text != string.Empty)
            {
                buttonCreateMenu.Enabled = true;
            }
            else
            {
                buttonCreateMenu.Enabled = false;
            }
        }

    }
}
