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
        public DateTime Hour { get; set; }
        public int QuantAvailable { get; set; }
        public decimal PriceStudent { get; set; }
        public decimal PriceProf { get; set; }
        public int idMenuPlates { get; set; }
        public MenuPlate MenuPlates { get; set; }
        public int idMenuExtra { get; set; }
        public MenuExtra MenuExtras { get; set; }




        public virtual string ReservationName => $"{Description}";
        public Menu()
        {
        }

        public Menu(DateTime data,DateTime hour, int quantAvailable, decimal priceStudent, decimal priceProf)
        {
            Hour = hour;
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
