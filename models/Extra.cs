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
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual string DisplayName => $"{Description} - Preço: {Price}€ - Stock: {Stock}";
        public virtual string ReservationName => $"{Description} - {Price}";
      
        public Extra()
        {
        }

        public Extra(string description, decimal price, int stock)
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
