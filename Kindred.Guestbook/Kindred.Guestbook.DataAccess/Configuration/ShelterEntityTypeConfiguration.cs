using Kindred.Guestbook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindred.Guestbook.DataAccess.Configuration
{
    public class ShelterEntityTypeConfiguration : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> shelterConfiguration)
        {
            shelterConfiguration.OwnsOne(o => o.Address);
            shelterConfiguration.OwnsOne(o => o.Email);
            shelterConfiguration.OwnsOne(o => o.PhoneNumber);

            shelterConfiguration
                .HasMany(s => s.Animals)
                .WithOne();
        }
    }
}
