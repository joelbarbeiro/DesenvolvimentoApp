using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Client:User
    {
        public double balance { get; set; }

        public Client()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
