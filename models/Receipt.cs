using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Receipt
    {
        [Key]
        public int idReceipt { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }
        public List<Menu> Menus { get; set; }
        public List<ItemReceipt> Items { get; set; }

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
