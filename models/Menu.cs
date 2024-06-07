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
        public int QuantAvailable { get; set; }
        public decimal PriceStudent { get; set; }
        public decimal PriceProf { get; set; }
        public int idMenuPlates { get; set; }
        public MenuPlate MenuPlates { get; set; }
        public int idMenuExtra { get; set; }
        public MenuExtra MenuExtras { get; set; }




        public Menu()
        {
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
            return Data+ " "+ QuantAvailable ;
        }
    }
}
