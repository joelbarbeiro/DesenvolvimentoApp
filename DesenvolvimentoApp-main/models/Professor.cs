using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Professor:Client
    {
        public string email { get; set; }

        public Professor()
        {
        }

        public Professor(string email)
        {
            this.email = email;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
