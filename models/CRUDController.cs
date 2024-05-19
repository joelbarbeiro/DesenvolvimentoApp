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
                user.nif == nif) ;
            if (query_result.Count() == 0)
            {
                Console.WriteLine("Registado com sucesso");
                return true;
            }
            Console.WriteLine("Registo Falhado");
            return false;
        }
        
    }
}
