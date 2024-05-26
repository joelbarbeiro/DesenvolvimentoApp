using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace iCantine.models
{
    public class Context:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Plate> Plates { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<MenuExtra> MenuExtras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Menu>()
                .HasRequired(m => m.Plate)
                .WithMany(p => p.Menus)
                .HasForeignKey(m => m.idPlates);

            modelBuilder.Entity<MenuExtra>()
                .HasRequired(me => me.Extras)
                .WithMany(e => e.MenuExtras)
                .HasForeignKey(me => me.idExtras);

        }
    }
}
