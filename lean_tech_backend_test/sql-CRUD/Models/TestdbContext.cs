using Microsoft.EntityFrameworkCore;

namespace sql_CRUD.MyModels
{
    public partial class TestdbContext : DbContext
    {
        public TestdbContext()
        {
        }

        public TestdbContext(DbContextOptions<TestdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bols> Bols { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PackaginType> PackaginTypes { get; set; }
        public virtual DbSet<Receiver> Receivers { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Test;Trusted_Connection=True;");
            /*
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Testdb;Trusted_Connection=True;");
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bols>()
            .HasMany(e => e.Orders)
            .WithOne()
            .OnDelete(DeleteBehavior.SetNull); // or whatever you like
        }
    }
}
