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
using System.Runtime.Remoting.Contexts;
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
            CRUDController.listBoxClientsUpdate();

        }
        private void changeUserLabel(string user)
        {
            labelEmployee.Text = user.ToUpper();
        }


        private void buttonRegister_Click(object sender, EventArgs e)
        {
            int nif;
            int numStudent;
            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            int.TryParse(textBoxNIF.Text, out nif);
            int.TryParse(textBoxNumStudent.Text, out numStudent);
            
            textBoxChange();
            if (buttonRegister.Text == "Gravar")
            {

                if (CRUDController.verifyUser(nif))
                {
                    if (radioButtonStudent.Checked)
                    {
                        if(verifyNIF() && verifyNumStudent())
                        {
                            Student student = new Student(numStudent, name, nif);
                            CRUDController.saveStudent(student);
                            CRUDController.listBoxClientsUpdate();
                        }
                        resetRegAndTxt();
                        return;
                    }
                    else
                    {
                        try
                        {
                            MailAddress adress = new MailAddress(email);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Email Inválido");
                            resetRegAndTxt();
                            return;
                        }
                        if (verifyNIF())
                        {
                            Professor professor = new Professor(email, name, nif);
                            CRUDController.saveProfessor(professor);
                            CRUDController.listBoxClientsUpdate();
                        }
                        resetRegAndTxt();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Já existe um utilizador com este NIF");
                    resetRegAndTxt();
                    return;
                }
            }
            else if (buttonRegister.Text == "Editar")
            {
                Client client = new Client();
                CRUDController.editClient(client,name,nif ,email, numStudent);
                CRUDController.listBoxClientsUpdate();
                resetRegAndTxt();
                resetButtons();
                setEnableButtons();
                textBoxChange();
                return;
            }
            buttonRegister.Text = "Gravar";
        }
        public bool verifyNIF()
        {
            if (textBoxNIF.Text.Count() != 9)
            {
                MessageBox.Show("NIF não tem 9 digitos");
                resetRegAndTxt();
                return false;
            }
            return true;
        }
        public void resetRegAndTxt()
        {
            textBoxClear();
            buttonRegister.Text = "Registar";
        }
        public bool verifyNumStudent()
        {
            if (textBoxNumStudent.Text.Count() != 7)
            {
                MessageBox.Show("Número de Estudante não tem 7 digitos");
                textBoxClear();
                buttonRegister.Text = "Registar";
                return false;
            }
            return true;
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

        public void changeViewEditStudent()
        {
            radioButtonStudent.Checked = true;
            radioButtonProfessor.Enabled = false;
            textBoxEmail.ReadOnly = true;
            textBoxNIF.ReadOnly = true;
        }
        public void changeViewEditProfessor()
        {
            radioButtonProfessor.Checked = true;
            radioButtonStudent.Enabled = false;
            textBoxNumStudent.ReadOnly = true;
            textBoxNIF.ReadOnly = true;
        }
        public void resetButtons()
        {
            radioButtonStudent.Enabled = true;
            radioButtonProfessor.Enabled = true;
        }
        public void setEnableButtons()
        {
            buttonRegister.Enabled = true;
            buttonEdit.Enabled = true;
            buttonBalance.Enabled = true;
            buttonDelete.Enabled = true;
        }
        public void setDisableButtons()
        {
            buttonRegister.Enabled = false;
            buttonEdit.Enabled = false;
            buttonBalance.Enabled = false;
            buttonDelete.Enabled = false;
        }


        public void textBoxClear()
        {
            textBoxName.Text = "";
            textBoxEmail.Text = "";
            textBoxNIF.Text = "";
            textBoxNumStudent.Text = "";
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
                textBoxNumStudent.ReadOnly = false;
                textBoxNumStudent.Text = "";
            }
        }



        private void buttonBack_Click(object sender, EventArgs e)
        {
            string user = labelEmployee.Text;
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCustomers.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente para eliminar");
                return;
            }

            var selectedUser = listBoxCustomers.SelectedItem as Client;

            var confirmResult = MessageBox.Show
                ("Tem a certeza que quer apagar "+selectedUser.name+"?",
                "Confirmação",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                CRUDController.deleteClient(selectedUser);
                if (CRUDController.deleteClient(selectedUser))
                {
                    textBoxChange();
                    return;
                }
            }
            return;
            
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBoxCustomers.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente para editar informação");
                return;
            }

            var selectedUser = (Client)listBoxCustomers.SelectedItem;
            textBoxName.Text = selectedUser.name;
            textBoxNIF.Text = selectedUser.nif.ToString();

            if (selectedUser is Student student)
            {
                textBoxChange();
                changeViewEditStudent();
                textBoxNumStudent.Text = student.studentNumber.ToString();
            }
            else if (selectedUser is Professor professor)
            {
                textBoxChange();
                changeViewEditProfessor();
                textBoxEmail.Text = professor.email;
            }
            buttonRegister.Text = "Editar";
            buttonBalance.Enabled = false;
            buttonDelete.Enabled = false;
            buttonEdit.Enabled = false;

        }

        private void buttonBalance_Click(object sender, EventArgs e)
        {
            if (listBoxCustomers.SelectedItem == null)
            {
                MessageBox.Show("Nenhum Cliente selecionado");
                return;
            }
            Client user = listBoxCustomers.SelectedItem as Client;
            string employee = labelEmployee.Text;
            FormBalance balanceForm = new FormBalance(user, employee);
            FormController.changeForm(balanceForm, this);
        }
    }
}
