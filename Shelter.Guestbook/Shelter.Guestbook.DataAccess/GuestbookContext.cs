using Microsoft.EntityFrameworkCore;
using Shelter.Guestbook.DataAccess.Configuration;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.DataAccess
{
    public class GuestbookContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalShelter> Shelters { get; set; }

        public GuestbookContext(DbContextOptions<GuestbookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalShelterEntityTypeConfiguration());
        }
    }
}