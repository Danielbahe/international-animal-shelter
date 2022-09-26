using Microsoft.EntityFrameworkCore;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.DataAccess
{
    public class GuestbookContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        public GuestbookContext(DbContextOptions<GuestbookContext> options) : base(options)
        {

        }
    }
}