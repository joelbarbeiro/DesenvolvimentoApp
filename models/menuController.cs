using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace iCantine.models
{
    internal class MenuController
    {
        public Context Context = new Context();

        public MenuController()
        {
        }

        public List<Extra> loadExtrasMenu()
        {
            List<Extra> extras = new List<Extra>();
                var query = this.Context.Extras.Where(
                    extra =>
                    extra.Active == true);
                if (query.Count() > 0)
                {
                    extras = query.ToList();
                    return extras;
                }
            return null;
        }



        public List<Plate> loadPlatesMenu(string type = "Todos")
        {
            List<Plate> plates = new List<Plate>();

                var query = Context.Plates.Where(
                    plate =>
                    plate.Active == true);
                if (type != "Todos")
                {
                    query = Context.Plates.Where(
                    plate =>
                    plate.Type == type &&
                    plate.Active == true);
                }

                if (query.Count() > 0)
                {
                    plates = query.ToList();
                    return plates;
                }
            return null;
        }
        public Plate getPlate(string description)
        {
            Plate item = new Plate();

                var query = Context.Plates.Where(
                    plate =>
                    plate.Description == description &&
                    plate.Active == true);

                item = query.FirstOrDefault();
            return item;
        }

        public Extra getExtra(string description)
        {
            Extra item = new Extra();

                var query = Context.Extras.Where(
                    plate =>
                    plate.Description == description &&
                    plate.Active == true);
                item = query.FirstOrDefault();
            return item;
        }

        public bool saveMenu(models.Menu items, List<Plate> plate, List<Extra> extra)
        {
                items.Plates = plate;
                items.Extras = extra;

                Context.Menus.Add(items);
                Context.SaveChanges();
            return true;
        }

        public List<Menu> loadMenu()
        {
            var menus = new List<Menu>();

            menus = Context.Menus.Include(m => m.Plates).Include(m => m.Extras).ToList();
            foreach (var menu in menus)
            {

                foreach (var plate in menu.Plates)
                {
                    Console.WriteLine("---------> " + plate);
                }
                foreach(var extra in menu.Extras)
                {
                    Console.WriteLine("---> " + extra);
                }
            }
            return menus;
        }
    }
}
