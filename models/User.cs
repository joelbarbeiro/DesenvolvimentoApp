using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class User
    {
        [Key]
        public int idUser{get; set;}
        public string name { get; set; }
        public int nif { get; set; }

        public User()
        {
            
        }

        public User( string name, int nif)
        {
            this.name = name;
            this.nif = nif;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
