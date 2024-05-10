using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    internal class Receipt
    {
        public double Total { get; set; }
        public DateTime Date { get; set; }

        public Receipt()
        {
        }

        public Receipt(double total, DateTime date)
        {
            Total = total;
            Date = date;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
