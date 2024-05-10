using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    internal class Ticket
    {
        public double Value { get; set; }
        public int NumHours { get; set; }

        public Ticket()
        {
        }

        public Ticket(double value, int numHours)
        {
            Value = value;
            NumHours = numHours;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
