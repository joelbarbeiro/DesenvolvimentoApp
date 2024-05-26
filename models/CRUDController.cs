using iCantine.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using iCantine.Views;
using System.Net.Mail;
using System.Data.Entity.Core.EntityClient;


namespace iCantine.Controllers
{
    public class CRUDController
    {
        public static bool verifyEmployee(string user)
        {
            models.Context context = new models.Context();

            var query_result = context.Employees.Where(
                employee =>
                employee.username == user);
            if (query_result.Count() == 0)
            {
                Console.WriteLine("Registado com successo");
                return true;
            }
            Console.WriteLine("Registo Falhado");
            return false;
        }

        public static bool verifyUser(int nif)
        {
            models.Context context = new models.Context();

            var query_result = context.Users.Where(
                user =>
                user.nif == nif);
            if (query_result.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static bool saveStudent(Student student)
        {

            models.Context context = new models.Context();
            context.Users.Add(student);
            try
            {
                context.SaveChanges();
                MessageBox.Show("Estudante Registado");
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Registo Não Concluido");
                //buttonRegister.Text = "Registar";
                //textBoxClear();
                return false;
            }
        }
        public static bool saveProfessor(Professor professor)
        {
            models.Context context = new models.Context();
            context.Users.Add(professor);
            try
            {
                context.SaveChanges();
                MessageBox.Show("Docente Registado");
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Registo Não Concluido");
                return false;
            }
        }
        public static bool editClient(Client userToUpdate, string name, int nif, string email, int numStudent)
        {
            models.Context context = new models.Context();
            userToUpdate = context.Users.OfType<Client>().SingleOrDefault(u => u.nif == nif);
            if (userToUpdate != null)
            {
                userToUpdate.name = name;

                if (userToUpdate is Student student)
                {
                    if (numStudent.ToString().Count() != 7)
                    {
                        MessageBox.Show("Numero de estudante não tem 7 digitos");
                        return false;
                    }
                    student.studentNumber = numStudent;
                }
                else if (userToUpdate is Professor professor)
                {
                    try
                    {
                        MailAddress adress = new MailAddress(email);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Email Inválido");
                        return false;
                    }
                    professor.email = email;
                }
                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Cliente editado com sucesso");
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao editar cliente:" + ex);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Nenhum cliente selecionado");
                return false;
            }
        }

        public static bool deleteClient(Client client)
        {
            using (var context = new models.Context())
            {
                var userToDelete = context.Users.OfType<Client>().SingleOrDefault(u => u.idUser == client.idUser);
                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Cliente apagado com sucesso.");
                        return true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao apagar Cliente: " + ex);
                        return false;
                    }
                }
                return false;

            }
        }
    }
}




