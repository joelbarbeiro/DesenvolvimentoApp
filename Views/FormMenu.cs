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
        public string user;
        public FormMenu(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }

        private void updateComboBox()
        {
            comboBoxPlateType.Items.Clear();
            foreach(string type in Enum.GetNames(typeof(PlateType)))
            {
                comboBoxPlateType.Items.Add(type);
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
