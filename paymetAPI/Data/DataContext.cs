using Microsoft.EntityFrameworkCore;
using paymetAPI.Data.Map;
using paymetAPI.Models;

namespace paymetAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Payment> payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
