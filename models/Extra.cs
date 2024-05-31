using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iCantine.models
{
    public class Extra
    {
        [Key]
        public int idExtra { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public int Stock { get; set; }
     
        public virtual string DisplayName => $"{Description} - Preço: {Price}€ - Stock: {Stock}";
        public virtual string ReservationName => $"{Description}";
      
        public Extra()
        {
        }

        public Extra(string description, double price, int stock)
        {
            Description = description;
            Price = price;
            Stock = stock;
        }

        public override string ToString()
        {
            return Description;
        }
    }

}
