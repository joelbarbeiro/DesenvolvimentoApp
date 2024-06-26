using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iCantine.models
{
    public class Client:User
    {
        public decimal Balance { get; set; }
        public virtual string DisplayName => $"{name} (Balance: {Balance:C})";
        public virtual string Name => $"{name}";
        public virtual ICollection<Receipt> Receipt { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public Client()
        {
            Receipt = new List<Receipt>();
            Reservations = new HashSet<Reservation>();
        }

        public Client( string name, int nif): base(name, nif) 
        {
            
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
