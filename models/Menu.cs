using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public DateTime Hour { get; set; }
        public int QuantAvailable { get; set; }
        public decimal PriceStudent { get; set; }
        public decimal PriceProf { get; set; }
        public List<Plate> Plates { get; set; }
        public List<Extra> Extras { get; set; }

        public Menu()
        {
        }

        public Menu(DateTime data, DateTime hour, int quantAvailable, decimal priceStudent, decimal priceProf, List<Plate> plates, List<Extra> extras)
        {
            Data = data;
            Hour = hour;
            QuantAvailable = quantAvailable;
            PriceStudent = priceStudent;
            PriceProf = priceProf;
            this.Plates = plates;
            this.Extras = extras;
        }

        public override string ToString()
        {
            return Data+ " "+ QuantAvailable;
        }
    }
}
