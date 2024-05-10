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

        public override string ToString()
        {
            return base.ToString();
        }
    }

}
