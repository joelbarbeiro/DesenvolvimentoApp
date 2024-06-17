using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Plate
    {
        [Key]
        public int idPlate { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual string DisplayName => $"Prato: {Description} - Tipo: {Type} - Stock: {Stock}";
        public Plate()
        {
            Reservations = new HashSet<Reservation>();
        }
        public Plate(string description, string type, int stock)
        {
            this.Description = description;
            this.Type = type;
            this.Stock = stock;
        }

        public override string ToString()
        {
            return Description;
        }
    }
    
}
