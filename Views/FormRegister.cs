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
            string name = textBoxName.Text;
            int nif = 0;
            int.TryParse(textBoxNIF.Text, out nif);

            if (CRUDController.verifyEmployee(username,nif))
            {
                if (verifyNIF())
                {
                    Employee employee = new Employee(username, name, nif);
                    Context context = new Context();
                    context.Users.Add(employee);
                    try
                    {
                        context.SaveChanges();
                        this.Close();
                        FormLogin formLogin = new FormLogin();
                        FormController.changeForm(formLogin, this);
                        MessageBox.Show("Funcionário Registado com Sucesso");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Registo Não Concluido: " + ex);
                        return;
                    }
                }
                else {
                    MessageBox.Show("Registo não concluido"); 
                    return;
                }
            }
            else
            {
                MessageBox.Show("Registo Falhado!");
                return;
            }
        }

        public bool verifyNIF()
        {
            if (textBoxNIF.Text.Count() != 9)
            {
                MessageBox.Show("NIF não tem 9 digitos");
                return false;
            }
            return true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            FormController.changeForm(formLogin, this);
        }
    }
}
