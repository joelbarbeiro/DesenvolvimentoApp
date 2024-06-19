using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Reservation
    {
        [Key]
        public int idReservation { get; set; }
        public virtual bool Active { get; set; }
        public virtual Client Clients { get; set; }
        public virtual Ticket Tickets { get; set; }
        public virtual Plate Plates { get; set; }
        public virtual Menu Menus { get; set; }
        public virtual List<Extra> Extras { get; set; }

        public Reservation()
        {
            Active = true;
        }



        public override string ToString()
        {
            string extrasDescription = Extras != null && Extras.Any()
                ? string.Join(", ", Extras.Select(e => e.Description))
                : "No extras";

            return $"{Clients.Name}, {Plates.Description}, {extrasDescription}";
        }
    }
}
