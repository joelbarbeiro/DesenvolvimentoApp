using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace iCantine.models
{
    public class Professor:Client
    {
        public string email { get; set; }

        public override string DisplayName => $"{name}, Email: {email}, Saldo: {Balance}€ (Docente)";


        public Professor()
        {
        }

        public Professor(string email, string name, int nif) : base(name, nif)
        {
            this.email = email;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
