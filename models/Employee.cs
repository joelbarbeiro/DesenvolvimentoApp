using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Employee:User
    {
        public string username { get; set; }

        public Employee()
        {
        }

        public Employee(string username, string name, int nif):base(name,nif)
        {
            this.username = username;
            this.name = name;
            this.nif = nif;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}
