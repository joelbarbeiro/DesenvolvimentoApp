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
        public string user;

        public FormCustomer(string user)
        {
            InitializeComponent();
            this.user = user;
            changeUserLabel(user);
            listBoxClientsUpdate();
            updateDropdownItems();
            updateListFiltered();
        }
        private void changeUserLabel(string user)
        {
            labelEmployee.Text = CRUDController.CapitalizeFirstLetter(user);
        }
        public void listBoxClientsUpdate()
        {
            using (var context = new models.Context())
            {
                var users = context.Users
                    .OfType<Client>()
                    .ToList();
                listBoxClients.DataSource = users;
                listBoxClients.DisplayMember = "DisplayName";
            }
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            int nif;
            int numStudent;
            string name = textBoxName.Text;
            string email = textBoxEmail.Text;
            int.TryParse(textBoxNIF.Text, out nif);
            int.TryParse(textBoxNumStudent.Text, out numStudent);

            if (buttonRegister.Text == "Gravar")
            {
                setDisableButtons();
                if (CRUDController.verifyUser(nif))
                {
                    if (radioButtonStudent.Checked)
                    {
                        if (verifyNIF() && verifyNumStudent())
                        {
                            Student student = new Student(numStudent, name, nif);
                            CRUDController.saveStudent(student);
                            listBoxClientsUpdate();
                        }
                        resetRegAndTxt();
                        setEnableButtons();
                        radioButtonReset();
                        textBoxChange();
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
                            setEnableButtons();
                            radioButtonReset();
                            textBoxChange();
                            return;
                        }
                        if (verifyNIF())
                        {
                            Professor professor = new Professor(email, name, nif);
                            CRUDController.saveProfessor(professor);
                            listBoxClientsUpdate();
                        }
                        resetRegAndTxt();
                        setEnableButtons();
                        radioButtonReset();
                        textBoxChange();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possivel registar o utilizador");
                    resetRegAndTxt();
                    setEnableButtons();
                    radioButtonReset();
                    textBoxChange();
                    return;
                }
            }
            else if (buttonRegister.Text == "Editar")
            {
                Client client = new Client();
                CRUDController.editClient(client, name, nif, email, numStudent);
                listBoxClientsUpdate();
                resetRegAndTxt();
                resetButtons();
                setEnableButtons();
                textBoxChange();
                radioButtonReset();
                return;
            }
            buttonRegister.Text = "Gravar";
            textBoxChange();
            setDisableButtons();
        }
        public bool verifyNIF()
        {
            if (textBoxNIF.Text.Count() != 9)
            {
                MessageBox.Show("NIF não tem 9 digitos");
                resetButtons();
                resetRegAndTxt();
                textBoxChange();
                radioButtonReset();
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
                resetButtons();
                resetRegAndTxt();
                textBoxChange();
                radioButtonReset();
                return false;
            }
            return true;
        }
        public void textBoxChange()
        {
            if (buttonRegister.Text == "Gravar" || buttonRegister.Text == "Editar")
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
            textBoxName.ReadOnly = false;
            textBoxNumStudent.ReadOnly = false;
            textBoxNIF.ReadOnly = true;
        }
        public void changeViewEditProfessor()
        {
            radioButtonProfessor.Checked = true;
            radioButtonStudent.Enabled = false;
            textBoxNumStudent.ReadOnly = true;
            textBoxEmail.ReadOnly = false;
            textBoxName.ReadOnly = false;
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
            if (buttonRegister.Text == "Gravar")
            {
                buttonRegister.Enabled = true;
                buttonEdit.Enabled = false;
                buttonBalance.Enabled = false;
                buttonDelete.Enabled = false;
            }
            else
            {
                buttonRegister.Enabled = false;
                buttonEdit.Enabled = false;
                buttonBalance.Enabled = false;
                buttonDelete.Enabled = false;
            }
        }
        public void radioButtonReset()
        {
            radioButtonProfessor.Checked = false;
            radioButtonStudent.Checked = false;
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
            MainForm mainForm = new MainForm(user);
            FormController.changeForm(mainForm, this);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente para eliminar");
                return;
            }

            var selectedUser = listBoxClients.SelectedItem as Client;

            var confirmResult = MessageBox.Show
                ("Tem a certeza que quer apagar " + selectedUser.name + "?",
                "Confirmação",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                CRUDController.deleteClient(selectedUser);
                listBoxClientsUpdate();
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
            if (listBoxClients.SelectedItem == null)
            {
                MessageBox.Show("Selecione um cliente para editar informação");
                return;
            }

            var selectedUser = (Client)listBoxClients.SelectedItem;
            textBoxName.Text = selectedUser.name;
            textBoxNIF.Text = selectedUser.nif.ToString();

            if (selectedUser is Student student)
            {
                changeViewEditStudent();
                textBoxNumStudent.Text = student.studentNumber.ToString();
            }
            if (selectedUser is Professor professor)
            {
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
            if (listBoxClients.SelectedItem == null)
            {
                MessageBox.Show("Nenhum Cliente selecionado");
                return;
            }
            Client user = listBoxClients.SelectedItem as Client;
            string employee = labelEmployee.Text;
            FormBalance balanceForm = new FormBalance(user, employee);
            FormController.changeForm(balanceForm, this);
        }

        public void updateDropdownItems()
        {
            comboBoxFilters.Items.Clear();
            comboBoxFilters.Items.Add("Todos");
            comboBoxFilters.Items.Add("Docente");
            comboBoxFilters.Items.Add("Estudante");
            comboBoxFilters.SelectedIndex = 0;
        }

        public void listBoxStudentsUpdate()
        {
            models.Context context = new models.Context();
            var professors = context.Users.OfType<Professor>().ToList();
            listBoxClients.DataSource = null;
            listBoxClients.DataSource = professors;
            listBoxClients.DisplayMember = "DisplayName";
        }
        public void listBoxSearchedUpdate(List<Client> searched)
        {
            listBoxClients.DataSource = null;
            listBoxClients.DataSource = searched;
            listBoxClients.DisplayMember = "DisplayName";
        }
        public void listBoxProfessorsUpdate()
        {
            models.Context context = new models.Context();
            var students = context.Users.OfType<Student>().ToList();
            listBoxClients.DataSource = null;
            listBoxClients.DataSource = students;
            listBoxClients.DisplayMember = "DisplayName";
        }
        public void updateListFiltered(string type = "Todos")
        {
            if (type == "Todos")
            {
                listBoxClientsUpdate();
            }
            if (type == "Docente")
            {
                listBoxStudentsUpdate();
            }
            if (type == "Estudante")
            {
                listBoxProfessorsUpdate();
            }
        }

        private void comboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateListFiltered(comboBoxFilters.SelectedItem.ToString());

        }

        private void buttonEmployee_Click_1(object sender, EventArgs e)
        {
            FormEmployee formEmployee = new FormEmployee(user);
            FormController.changeForm(formEmployee, this);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string userToSearch = textBoxSearch.Text.Trim();
            int nifToSearch;
            bool isNifValid = int.TryParse(textBoxSearch.Text, out nifToSearch);

            try
            {
                using (var context = new models.Context())
                {
                    var clients = context.Users
                        .OfType<Client>()
                        .Where(c => c.name.Contains(userToSearch) || (isNifValid && c.nif == nifToSearch))
                        .ToList();

                    listBoxSearchedUpdate(clients);

                    if (clients.Count == 0)
                    {
                        MessageBox.Show("Nenhum cliente com esse Nome/NIF");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao procurar cliente: {ex.Message}");
            }
        }
    }

}
