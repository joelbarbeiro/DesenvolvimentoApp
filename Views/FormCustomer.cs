using iCantine.Controllers;
using iCantine.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCantine.Views
{
    public partial class FormCustomer : Form
    {
        public FormCustomer(string user)
        {
            InitializeComponent();
            changeUserLabel(user);
        }
        private void changeUserLabel(string user)
        {
            labelEmployee.Text = user;
        }


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            int nif = 0;
            int numStudent = 0;
            string name = textBoxName.Text;
            int.TryParse(textBoxNIF.Text, out nif);
            string email = textBoxEmail.Text;
            int.TryParse(textBoxNumStudent.Text, out numStudent);
            textBoxChange();
            
            if (buttonRegister.Text == "Gravar")
            {
                if (CRUDController.verifyUser(nif))
                {
                    if (radioButtonStudent.Checked)
                    {

                        Student student = new Student(numStudent, name, nif);
                        Context context = new Context();
                        context.Users.Add(student);
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Estudante Registado");

                            buttonRegister.Text = "Registar";
                            textBoxClear();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Registo Não Concluido");
                            buttonRegister.Text = "Registar";
                            textBoxClear();
                            return;
                        }
                    }
                    else
                    {
                        Professor professor = new Professor(email, name, nif);
                        Context context = new Context();
                        context.Users.Add(professor);
                        try
                        {

                            context.SaveChanges();
                            MessageBox.Show("Docente Registado");
                            buttonRegister.Text = "Registar";
                            textBoxClear();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Registo Não Concluido");
                            buttonRegister.Text = "Registar";
                            textBoxClear();
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Já existe um utilizador com este NIF");
                    buttonRegister.Text = "Registar";
                    textBoxClear();
                    return;
                }
                

            }
            buttonRegister.Text = "Gravar";

        }
        public void textBoxChange()
        {
            if (buttonRegister.Text != "Gravar")
            {
                
                textBoxName.ReadOnly = false;
                textBoxEmail.ReadOnly = false;
                textBoxNIF.ReadOnly = false;
                textBoxNumStudent.ReadOnly = false;
            }
            else
            {
                textBoxName.ReadOnly = true;
                textBoxEmail.ReadOnly = true;
                textBoxNIF.ReadOnly = true;
                textBoxNumStudent.ReadOnly = true;
            }
        }
        public void listBoxClientsUpdate()
        {
            listBoxCustomers.DataSource = null;
            //listBoxCustomers.DataSource = Users; 
        }
        public void textBoxClear()
        {
            textBoxName.Text = "";
            textBoxEmail.Text= "";
            textBoxNIF.Text= "";
            textBoxNumStudent.Text= "";  
        }

        private void radioButtonStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStudent.Checked)
            {
                textBoxEmail.ReadOnly = true;
            }
            else
            {
                textBoxEmail.ReadOnly = false;
                textBoxEmail.Text = "";
            }
        }

        private void radioButtonProfessor_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonProfessor.Checked)
            {
                textBoxNumStudent.ReadOnly = true;
            }
            else
            {
                textBoxNumStudent.ReadOnly= false;
                textBoxNumStudent.Text = "";
            }
        }



        private void buttonBack_Click(object sender, EventArgs e)
        {
            string user = labelEmployee.Text;
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }
    }
}
