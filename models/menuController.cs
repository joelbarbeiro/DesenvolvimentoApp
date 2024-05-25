using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCantine.models
{
    internal class menuController
    {
        public static List<models.Menu> loadMenus(DateTime selectedDay)
        {
            using (Context context = new Context())
            {
                var query = context.Menus.Where(menu =>
                                                menu.Data == selectedDay);
                if (query.Count() > 0)
                {
                    List<models.Menu> items = new List<models.Menu>();

                    foreach (var menu in query)
                    {
                        models.Menu item = new models.Menu(menu.Data, menu.QuantAvailable, menu.PriceStudent, menu.PriceProf);
                        items.Add(item);
                    }
                    return items;
                }
            }
            return null;
        }
        public static List<Extra> loadExtrasMenu()
        {
            using (Context context = new Context())
            {
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
            }
            return null;
        }

        public static List<Plate> loadPlatesMenu(string type = "Todos")
        {
            using (Context context = new Context())
                {

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
                        Plate item = new Plate(plate.Description, plate.Type, plate.Active);
                        plates.Add(item);
                    }
                    return plates;
                }
            }
            return null;
        }
        public static Plate getPlate(string description)
        {
            Plate item = new Plate();

            using (Context context = new Context())
            {
                var query = context.Plates.Where(
                    plate =>
                    plate.Description == description &&
                    plate.Active == true);

                item = query.FirstOrDefault();
            }            
            return item;
        }

        public static Extra getExtra(string description)
        {
            Extra item = new Extra();

            using (Context context = new Context())
            {
                var query = context.Extras.Where(
                    plate =>
                    plate.Description == description &&
                    plate.Active == true);
                item = query.FirstOrDefault();
            }
            return item;
        }

        public static bool saveMenu(models.Menu items, Plate plate, List<Extra> extra)
        {
            using (Context context = new Context())
            {
                items.idPlates = plate.idPlate;
                context.Menus.Add(items);
                context.SaveChanges();
                foreach (var itemsExtra in extra)
                {
                    var saveToMenuExtra = new MenuExtra { idMenu = items.idMenu, idExtras = itemsExtra.idExtra };
                    context.MenuExtras.Add(saveToMenuExtra);
                    context.SaveChanges();

                    
                }
            }
            return true;
        }
        public static List<Menu> loadMenu()
        {
            var items = new List<Menu>();
            using(Context context = new Context())
            {
                var query = context.Menus;

                return query.ToList();
            }
        }
        /*public static get()
        {
            var studentsInMath = context.Courses
                .Include(c => c.StudentCourses.Select(sc => sc.Student))
                .Single(c => c.Title == "Mathematics")
                .StudentCourses
                .Select(sc => sc.Student)
                .ToList();
        }*/
    }
}
