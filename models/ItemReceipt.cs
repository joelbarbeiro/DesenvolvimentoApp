using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    internal class ItemReceipt
    {
        public string Description { get; set; }
        public double Price { get; set; }

        public ItemReceipt()
        {
        }

        public ItemReceipt(string description, double price)
        {
            Description = description;
            Price = price;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
