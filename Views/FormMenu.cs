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
using iCantine.models;
using iCantine.Views;

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

            this.menuItems = CRUDController.loadMenus();
            this.plates = CRUDController.loadPlatesMenu();
            this.extra = CRUDController.loadExtrasMenu();

            updateComboBox();
            updateMenuListBox();
            updatePlateListBox();
            updateExtrasListBox();
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
                DateTime day = dateTimePicker1.Value.ToUniversalTime();
                string getHour = listBoxTime.SelectedItem.ToString();
                DateTime hour;
                DateTime.TryParse(getHour, out hour);
                string typePlate = comboBoxPlateType.SelectedText;
                string plates = listBoxPlate.SelectedItem.ToString();
                string extras = listBoxExtra.SelectedItem.ToString();

                int quantity = 0;
                int studentPrice = 0;
                int professorPrice = 0;
                int.TryParse(textBoxQuantity.Text, out quantity);
                int.TryParse(textBoxPriceStudent.Text, out studentPrice);
                int.TryParse(textBoxPriceProfessor.Text, out professorPrice);

                models.Menu item = new models.Menu(day, hour, quantity, studentPrice, professorPrice);
                menuItems.Add(item);

                CRUDController.saveMenu(item);
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

        private void listBoxExtra_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeTextBoxState();
        }

        private void changeTextBoxState()
        {
            if (listBoxTime.SelectedItem != null && listBoxPlate.SelectedItem != null && listBoxExtra.SelectedItem != null)
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
                MessageBox.Show("Não introduzio valor na quantidade");
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
                MessageBox.Show("Não introduzio valor na quantidade");
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
            plates = CRUDController.loadPlatesMenu(comboBoxPlateType.SelectedItem.ToString());
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

        private void updateExtrasListBox()
        {
            listBoxExtra.DataSource = null;
            listBoxExtra.DataSource = extra;
        }
    }
}
