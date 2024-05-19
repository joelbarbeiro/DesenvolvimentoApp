using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Reservation
    {
        [Key]
        public int idReservation { get; set; }
        public List<Client> Clients;
        public List<Ticket> Tickets;
        public List<Plate> Plates;
        public List<Menu> Menus;
        public List<Extra> Extras;

        public Reservation()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
