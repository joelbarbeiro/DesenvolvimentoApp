using iCantine.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using iCantine.Views;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Net.Mail;


namespace iCantine.Controllers
{
    public class CRUDController
    {
        public static bool verifyEmployee(string user)
        {
            Context context = new Context();

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
            Context context = new Context();

            var query_result = context.Users.Where(
                user =>
                user.nif == nif);
            if (query_result.Count() == 0)
            {
                Console.WriteLine("Registado com sucesso");
                return true;
            }
            Console.WriteLine("Registo Falhado");
            return false;
        }

        public static List<models.Menu> loadMenus()
        {
            Context context = new Context();

            var query = context.Menus;
            if (query.Count() > 0)
            {
                List<models.Menu> items = new List<models.Menu>();

                foreach (var menu in query)
                {
                    models.Menu item = new models.Menu(menu.Data, menu.Hour, menu.QuantAvailable, menu.PriceStudent, menu.PriceProf);
                    items.Add(item);
                }
                return items;
            }
            return null;
        }
        public static List<Plate> loadPlatesMenu(string type = "*")
        {
            Context context = new Context();

            var query = context.Plates.Where(
                plate =>
                plate.Type == type &&
                plate.Active == true);

            if (query.Count() > 0)
            {
                List<Plate> plates = new List<Plate>();

                foreach (var plate in query)
                {
                    Plate item = new Plate(plate.idPlate, plate.Description, plate.Type, plate.Active);
                    plates.Add(item);
                }
                return plates;
            }
            return null;
        }
        public static List<Extra> loadExtrasMenu()
        {
            Context context = new Context();

            var query = context.Extras.Where(
                extra =>
                extra.Active == true);

            return query.ToList();
        }

        public static bool saveMenu(models.Menu items)
        {
            Context context = new Context();
            context.Menus.Add(items);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar: " + ex);
                return false;
            }
            MessageBox.Show("Menu gravado com sucesso");
            return true;
        }

        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static bool saveStudent(Student student)
        {

            Context context = new Context();
            context.Users.Add(student);
            try
            {
                context.SaveChanges();
                MessageBox.Show("Estudante Registado");
                //listBoxClientsUpdate();
                //buttonRegister.Text = "Registar";
                //textBoxClear();
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
            Context context = new Context();
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
            Context context = new Context();
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
        public static void listBoxClientsUpdate()
        {
            using (var context = new Context())
            {
                var users = context.Users
                    .OfType<Client>()
                    .ToList();
                FormCustomer.listBoxCustomers.DataSource = users;
                FormCustomer.listBoxCustomers.DisplayMember = "DisplayName";
            }
        }
        public static bool deleteClient(Client client)
        {
            using (var context = new Context())
            {
                var userToDelete = context.Users.OfType<Client>().SingleOrDefault(u => u.idUser == client.idUser);
                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
                    try
                    {
                        context.SaveChanges();
                        MessageBox.Show("Cliente apagado com sucesso.");
                        CRUDController.listBoxClientsUpdate();
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


