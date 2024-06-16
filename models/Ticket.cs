using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Ticket
    {
        [Key]
        public int idTicket { get; set; }
        public decimal Value { get; set; }
        public int NumHours { get; set; }

        public Ticket()
        {
        }

        public Ticket(decimal value, int numHours)
        {
            Value = value;
            NumHours = numHours;
        }

        public override string ToString()
        {
            return "O valor "+Value+"€"+" vai ser adicionado se atrasar "+NumHours+" horas a reservar";
        }
    }
}
