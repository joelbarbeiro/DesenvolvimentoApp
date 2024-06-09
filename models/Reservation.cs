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
        public DateTime Date { get; set; }
        public string Plate { get; set; }
        public string Extra { get; set; }
        public string Client { get; set; }
        public string Hour { get; set; }
        public virtual string ReservationName => $"{Date},{Plate},{Client},{Extra}";
        public List<Client> Clients;
        public List<Ticket> Tickets;
        public List<Plate> Plates;
        public List<Menu> Menus;
        public List<Extra> Extras;
        public ICollection<Reservation> Reservations;

        public Reservation()
        {
        }


        public Reservation(string plate, string extra, string client, DateTime date, string hour)
        {
            Plate = plate;
            Extra = extra;
            Client = client;
            Date = date;
            Hour = hour;

        }

        public override string ToString()
        {
            return Date + "-" + Hour + ":" + Plate + "," + Extra + "," + Client;
        }
    }
}
