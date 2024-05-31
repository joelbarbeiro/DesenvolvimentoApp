using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class MenuPlate
    {
        [Key]
        public int idMenuPlates { get; set; }
        public int idPlates { get; set; }
        public int idExtras { get; set; }
        public Plate Plates { get; set; }

        public MenuPlate()
        {
        }
    }
}
