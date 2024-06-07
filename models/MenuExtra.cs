using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class MenuExtra
    {
        [Key]
        public int idMenuExtras { get; set; }
        public int idMenu { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public int idExtras { get; set; }
        public Extra Extras { get; set; }

        public MenuExtra()
        {
        }
    }
}
