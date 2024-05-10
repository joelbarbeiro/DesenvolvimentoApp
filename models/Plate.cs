using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    internal class Plate
    {
        public string Description { get; set; }
        public enum Type {Carne,Peixe,Vegetariano}
        public bool Active { get; set; }

    }
}
