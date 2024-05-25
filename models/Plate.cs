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
        public double Price { get; set; }
        public virtual string DisplayName => $"Prato: {Description}€ - Tipo: {Type} - Stock: {Stock} - Price: {Price}";
        public virtual string ReservationName => $"{Description}";
        public Plate()
        {

        }
        public Plate(string description, string type, int stock, double price)
        {
            this.Description = description;
            this.Type = type;
            this.Stock = stock;
            this.Price = price;
        }

        public override string ToString()
        {
            return Description;
        }
    }
    
}
