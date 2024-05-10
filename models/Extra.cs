using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Extra
    {
        [Key]
        public int idExtra { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }

        public Extra()
        {
        }

        public Extra(string description, double price, bool active)
        {
            Description = description;
            Price = price;
            Active = active;
        }

        public override string ToString()
        {
            return Description+" "+Price;
        }
    }

}
