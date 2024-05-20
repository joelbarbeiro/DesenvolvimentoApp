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
using iCantine.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace iCantine.Views
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            AcceptButton = buttonRegister;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            if (CRUDController.verifyEmployee(username))
            {
                Employee employee = new Employee(username);
                Context context = new Context();
                context.Employees.Add(employee);
                try
                {
                    context.SaveChanges();
                    this.Close();
                    FormLogin formLogin = new FormLogin();
                    FormController.changeForm(formLogin, this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Registo Não Concluido: " + ex);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Registo Falhado!");
                return;
            }
        }



        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            FormController.changeForm(formLogin,this);
        }
    }
}
