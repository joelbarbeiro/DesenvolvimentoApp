using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iCantine.models;
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
        public static void openFormLogin() 
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
        }
        public static void openForm1(Form formLogin, Employee user)
        {
            MainForm mainForm = new MainForm(user);
            mainForm.Show();
            formLogin.Hide();
        }
        public static void logoutForm(Form mainForm)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            mainForm.Close();
        }
        public static void changeForm(Form newForm, Form oldForm, string[] argS=null)
        {
            newForm.Show();
            oldForm.Hide();
        }

    }
}
