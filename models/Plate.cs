using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public enum Type {Carne,Peixe,Vegetariano}
        public bool Active { get; set; }

    }
}
