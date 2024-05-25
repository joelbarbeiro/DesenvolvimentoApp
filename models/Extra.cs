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

        public virtual ICollection<MenuExtra> MenuExtras { get; set; }
        public virtual string DisplayName => $"{Description} - Preço: {Price}€";
        public Extra()
        {
        }

        public Extra(string description, double price)
        {
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return Description;
        }
    }

}
