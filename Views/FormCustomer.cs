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
            listBoxClientsUpdate();

        }
        private void changeUserLabel(string user)
        {
            labelEmployee.Text = CapitalizeFirstLetter(user);
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
                        models.Context context = new models.Context();
                        context.Users.Add(student);
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Estudante Registado");
                            listBoxClientsUpdate();
                            buttonRegister.Text = "Registar";
                            textBoxClear();
                            return;
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
                        models.Context context = new models.Context();
                        context.Users.Add(professor);
                        try
                        {

                            context.SaveChanges();
                            MessageBox.Show("Docente Registado");
                            listBoxClientsUpdate();
                            buttonRegister.Text = "Registar";
                            textBoxClear();
                            return;
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
            else
            {
                if (buttonRegister.Text == "Editar") 
                {
                    models.Context context = new models.Context();
                    var userToUpdate = context.Users.OfType<Client>().SingleOrDefault(u => u.nif == nif);
                    if (userToUpdate != null)
                    {
                        userToUpdate.name = name;

                        if (userToUpdate is Student student)
                        {
                            student.studentNumber = numStudent;
                        }
                        else if (userToUpdate is Professor professor)
                        {
                            professor.email = email;
                        }
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Cliente editado com sucesso");
                            listBoxClientsUpdate();
                            buttonRegister.Text = "Registar";
                            textBoxClear();
                            return;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao editar cliente: {ex.Message}");
                        }
                    }
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
            using (var context = new models.Context())
            {
                var users = context.Users
                    .OfType<Client>()
                    .ToList();
                listBoxCustomers.DataSource = users;
                listBoxCustomers.DisplayMember = "DisplayName";
            }
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCustomers.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente para eliminar");
                return;
            }

            var selectedUser = (Client)listBoxCustomers.SelectedItem;

            var confirmResult = MessageBox.Show
                ($"Tem a certeza que quer apagar {selectedUser.name}?",
                "Confirmação",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                using (var context = new models.Context())
                {
                    var userToDelete = context.Users.OfType<Client>().SingleOrDefault(u => u.idUser == selectedUser.idUser);
                    if (userToDelete != null)
                    {
                        context.Users.Remove(userToDelete);
                        try
                        {
                            context.SaveChanges();
                            MessageBox.Show("Cliente apagado com sucesso.");
                            listBoxClientsUpdate();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao apagar Cliente: {ex.Message}");
                        }
                    }
                }
            }
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
                radioButtonStudent.Checked = true;
                textBoxNumStudent.Text = student.studentNumber.ToString();
                textBoxEmail.Text = "";
            }
            else if (selectedUser is Professor professor)
            {
                radioButtonProfessor.Checked = true;
                textBoxEmail.Text = professor.email;
                textBoxNumStudent.Text = "";
            }
            textBoxChange();
            buttonRegister.Text = "Editar";
            
        }

        private void buttonBalance_Click(object sender, EventArgs e)
        {
            Client user = listBoxCustomers.SelectedItem as Client;
            string employee = labelEmployee.Text;
            FormBalance balanceForm = new FormBalance(user,employee);
            FormController.changeForm(balanceForm, this);
        }
        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }

}
