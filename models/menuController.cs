using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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

        public bool saveMenu(models.Menu items, List<Plate> plate, List<Extra> extra)
        {
            try
            {
                items.Plates = plate;
                items.Extras = extra;

                Context.Menus.Add(items);
                Context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool updateMenu(models.Menu menuToUpdate, List<Plate> plate, List<Extra> extra)
        {
            var updateMenu = Context.Menus.SingleOrDefault(m => m.idMenu == menuToUpdate.idMenu);
            if (updateMenu != null)
            {
                updateMenu.Plates = plate;
                updateMenu.Extras = extra;

                Context.SaveChanges();
                return true;

            }
            return false;
        }
        public bool deleteMenu(models.Menu itemToRemove)
        {
            var menuToRemove = Context.Menus.SingleOrDefault(m => m.idMenu == itemToRemove.idMenu);
            if (menuToRemove != null)
            {
                try
                {
                    menuToRemove.Plates = null;
                    foreach (var extra in menuToRemove.Extras)
                    {
                        menuToRemove.Extras = null;
                    }
                    Context.Menus.Remove(menuToRemove);
                    Context.SaveChanges();
                }
                catch (Exception )
                {
               
                }
                finally
                {

                }
            }
            else
            {
                return false;
            }
            return true;
        }
        public List<models.Menu> getMenusOnDate(DateTime date)
        {
            var query = Context.Menus.Where(
                    menu =>
                    menu.Data.Year == date.Year &&
                    menu.Data.Month == date.Month &&
                    menu.Data.Day == date.Day).Include(m => m.Plates).Include(m => m.Extras);

            if (query.Count() > 0)
            {
                return query.ToList();
            }
            return null;
        }
    }
}