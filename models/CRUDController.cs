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
        public static bool verifyUser(string user,int nif=0,string email=null,int numEstudante=0)
        {
            Context context = new Context();

            var query_result = context.Employees.Where(
                employee =>
                employee.username == user);
            if (query_result.Count() == 0)
            {
                Console.WriteLine("Register Successful");
                return true;
            }
            Console.WriteLine("Register Failed");
            return false;
        }
    }
}
