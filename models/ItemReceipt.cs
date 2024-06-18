using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class ItemReceipt
    {
        [Key]
        public int idItemReceipt {  get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual Receipt Receipts { get; set; }
        public ItemReceipt()
        {
        }

        public ItemReceipt(string description, decimal price)
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
