using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ensek.API.Models
{
    public class MeterReadingContext :DbContext
    {
        public MeterReadingContext(DbContextOptions<MeterReadingContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasMany(a => a.MeterReadings);
            modelBuilder.Entity<MeterReading>().HasOne(m => m.Account);
          
            modelBuilder.Seed();
        }

      //  public DbSet<MeterReadingDb> meterreadings { get; set; }
       // public DbSet<AccountDb> account { get; set; }
        public DbSet<MeterReading> meterReading { get; set; }
    }
}
