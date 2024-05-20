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
            if (query.Count() > 0)
            {
                List<Extra> extras = new List<Extra>();

                foreach (var extra in query)
                {
                    Extra item = new Extra(extra.Description, extra.Price);
                    extras.Add(item);
                }
                return extras;
            }
            return null;
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

    }
}
