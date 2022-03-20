using Microsoft.EntityFrameworkCore;

namespace Ensek.API.Models
{
    public class MeterDbContext : DbContext
    {
        public DbSet<MeterReading> MeterReading { get; set; }

        public DbSet<MeterReadingRetrieve> MeterReadingRetrieve { get; set; }
    
        public MeterDbContext(DbContextOptions<MeterDbContext> options) : base(options)
        {
        }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeterReading>().ToTable("MeterReading");
        }
       */

    }
}
