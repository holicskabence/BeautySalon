using BookingApp.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BookingApp.Repository.Database
{
    public class BookingDbContext : IdentityDbContext<SiteUser>
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Customer", NormalizedName = "CUSTOMER" }
                );

            PasswordHasher<SiteUser> ph = new PasswordHasher<SiteUser>();
            SiteUser bence = new SiteUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "benceholicska@gmail.com",
                EmailConfirmed = true,
                UserName = "hbence19",
                FirstName = "Holicska",
                LastName = "Bence",
                NormalizedUserName = "HBENCE19"
            };
            bence.PasswordHash = ph.HashPassword(bence, "almafa123");
            modelBuilder.Entity<SiteUser>().HasData(bence);


            modelBuilder.Entity<Appointment>()
                .HasOne(t => t.Owner)
                .WithMany()
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}