using Kindred.Guestbook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Kindred.Guestbook.DataAccess.Configuration;

namespace Kindred.Guestbook.DataAccess
{
    public class GuestbookContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Shelter> Shelters { get; set; }

        public GuestbookContext(DbContextOptions<GuestbookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShelterEntityTypeConfiguration());
        }
    }
}