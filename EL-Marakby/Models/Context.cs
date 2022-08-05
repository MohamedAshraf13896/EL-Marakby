using Microsoft.EntityFrameworkCore;

namespace EL_Marakby.Models
{
    public class Context: DbContext
    {
        public Context() : base()
        {

        }
        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Elmarakby_Task;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceDetails>().HasKey(o => new { o.Item_ID, o.Invoice_ID });
            modelBuilder.Entity<Invoice>().HasIndex(u => u.Serial)
    .IsUnique();
            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }

    }
}
