using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCantine.models
{
    internal class menuController
    {
        public static List<models.Menu> loadMenus(DateTime selectedDay)
        {
            Context context = new Context();

            var query = context.Menus.Where(menu=>
                                            menu.Data == selectedDay);
            if (query.Count() > 0)
            {
                List<models.Menu> items = new List<models.Menu>();

                foreach (var menu in query)
                {
                    models.Menu item = new models.Menu(menu.Data, menu.Hour, menu.QuantAvailable, menu.PriceStudent, menu.PriceProf, menu.Plates, menu.Extras);
                    items.Add(item);
                }
                return items;
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

        public static List<Plate> loadPlatesMenu(string type = "Todos")
        {
            Context context = new Context();

            var query = context.Plates.Where(
                plate =>
                plate.Active == true);
            if (type != "Todos")
            {
                query = context.Plates.Where(
                plate =>
                plate.Type == type &&
                plate.Active == true);
            }
            

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
    }
}
