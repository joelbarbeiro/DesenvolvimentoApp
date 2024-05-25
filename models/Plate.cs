using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Type { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual string display_ => $"{Description} - {Type} - {Active}";

        public Plate()
        {
        }

        public Plate(string description, string type, bool active)
        {
            this.idPlate = idPlate;
            this.Description = description;
            this.Type = type;
            this.Active = active;
        }

        public override string ToString()
        {
            return Description;
        }
    }
    
}
