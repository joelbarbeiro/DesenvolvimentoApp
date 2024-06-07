using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                        models.Menu item = new models.Menu(menu.Data,menu.Hour, menu.QuantAvailable, menu.PriceStudent, menu.PriceProf);
                        items.Add(item);
                    }
                    return items;
                }
            }
            return null;
        }
        public static List<Extra> loadExtrasMenu()
        {
            List<Extra> extras = new List<Extra>();
            using (Context context = new Context())
            {
                var query = context.Extras.Where(
                    extra =>
                    extra.Active == true);
                if (query.Count() > 0)
                {
                    extras = query.ToList();
                    return extras;
                }
            }
            return null;
        }

        public static List<Plate> loadPlatesMenu(string type = "Todos")
        {
            List<Plate> plates = new List<Plate>();
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
                    plates = query.ToList();
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

        public static bool saveMenu(models.Menu items, List<Plate> plate, List<Extra> extra)
        {
            using (Context context = new Context())
            {
                context.Menus.Add(items);
                context.SaveChanges();
                foreach (var itemPlate in plate)
                {
                    var saveToMenuPlate = new MenuPlate { idMenu = items.idMenu, idPlates = itemPlate.idPlate };
                    context.MenuPlates.Add(saveToMenuPlate);
                    context.MenuPlates.Add(saveToMenuPlate);
                }
                foreach (var itemsExtra in extra)
                {
                    var saveToMenuExtra = new MenuExtra { idMenu = items.idMenu, idExtras = itemsExtra.idExtra };
                    context.MenuExtras.Add(saveToMenuExtra);
                    context.SaveChanges();                  
                }
            }
            return true;
        }

        public static List<Menu> loadMenu (DateTime date)
        {
            var menus = new List<Menu>();

            using (Context context = new Context())
            {
                menus = context.Menus.Where(
                    menu =>
                    menu.Data == date
                    ).ToList();
            }

            return menus;
        }
        public static List<Plate> loadMenuPlate (int idMenu)
        {
            var plates = new List<Plate>();
            using (Context context = new Context())
            {

            }
            return plates;
        }
        public static List<Extra> loadMenuExtra (int idMenu)
        {
            var extra = new List<Extra>();
            using (Context context =new Context())
            {
                /*extra = (from mp  in context.Menus
                         join p in DbContext)
                         */
            }
            return extra;
        }
        /*
         

        var entryPoint = (from ep in dbContext.tbl_EntryPoint
                 join e in dbContext.tbl_Entry on ep.EID equals e.EID
                 join t in dbContext.tbl_Title on e.TID equals t.TID
                 where e.OwnerID == user.UID
                 select new {
                     UID = e.OwnerID,
                     TID = e.TID,
                     Title = t.Title,
                     EID = e.EID
                 }).Take(10);
       

        }*/
    }
}
