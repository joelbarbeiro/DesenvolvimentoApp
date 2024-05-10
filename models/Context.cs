using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    internal class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
