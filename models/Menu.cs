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
    public class Menu
    {

        [Key]
        public int idMenu { get; set; }
        public DateTime Data { get; set; }
        public int QuantAvailable { get; set; }
        public decimal PriceStudent { get; set; }
        public decimal PriceProf { get; set; }
        public virtual List<Plate> Plates { get; set; }
        public virtual List<Extra> Extras { get; set; }
        public virtual ICollection<Receipt> Receipt { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual string DisplayMenu =>
        $"Prato: {string.Join(", ", Plates.Select(p => p.DisplayName))}\n" +
        $"Extras: {string.Join(", ", Extras.Select(e => e.DisplayName))}\n" +
        $"Quantidade: {QuantAvailable}";


        public Menu()
        {
            Reservations = new HashSet<Reservation>();
        }

        public Menu(DateTime data, int quantAvailable, decimal priceStudent, decimal priceProf)
        {
            Data = data;
            QuantAvailable = quantAvailable;
            PriceStudent = priceStudent;
            PriceProf = priceProf;
        }

        public override string ToString()
        {
            string result = string.Empty;
            try
            {
                result= $"Prato: {string.Join(", ", Plates.Select(p => p.DisplayName))}\n" +
                        $"Extras: {string.Join(", ", Extras.Select(e => e.DisplayName))}\n";
            }
            catch
            {

            }
            return result;
        }
    }
}
