using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iCantine.Views;

namespace iCantine.Controllers
{
    public class FormController
    {
        public static void openFormRegister(Form formLogin)
        {
            FormRegister registerForm = new FormRegister();
            registerForm.Show();
            formLogin.Hide();
        }
    }
}
