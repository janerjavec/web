using web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public class HotelContext : IdentityDbContext<ApplicationUser>
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }

        public DbSet<Guest> Guest { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Room> Room { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Guest>().ToTable("Guest");
            modelBuilder.Entity<Hotel>().ToTable("Hotel");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Hotel>()
                .HasMany(h => h.Rooms)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Reservations)
                .WithOne(res => res.Room)
                .HasForeignKey(res => res.Room_Id)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Guest>()
                .HasMany(g => g.Reservations)
                .WithOne(r => r.Guest)
                .HasForeignKey(r => r.Guest_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}