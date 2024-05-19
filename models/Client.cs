using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Client:User
    {
        public double Balance { get; set; }

        public Client()
        {
        }

        public Client( string name, int nif): base(name, nif) 
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
