using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelReserv.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace hotelReserv.Data
{
    public class HotelDbContext:DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //hotel

            modelBuilder.Entity<HotelEntity>().ToTable("Hotels");
            modelBuilder.Entity<HotelEntity>().HasMany(a => a.reservs).WithOne(b => b.hotelIdEntity);
            modelBuilder.Entity<HotelEntity>().Property(a => a.id).ValueGeneratedOnAdd();
            //reservs

            modelBuilder.Entity<ReservEntity>().ToTable("Reservs");
            modelBuilder.Entity<ReservEntity>().Property(b => b.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ReservEntity>().HasOne(b => b.hotelIdEntity).WithMany(a => a.reservs);

        }
        public DbSet<HotelEntity> Hotels { get; set; }
        public DbSet<ReservEntity> Reservs { get; set; }

    }
}
