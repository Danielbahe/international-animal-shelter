using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.DataAccess.Configuration
{
    public class AnimalShelterEntityTypeConfiguration : IEntityTypeConfiguration<AnimalShelter>
    {
        public void Configure(EntityTypeBuilder<AnimalShelter> orderConfiguration)
        {
            orderConfiguration.OwnsOne(o => o.Address);
            orderConfiguration.OwnsOne(o => o.Email);
            orderConfiguration.OwnsOne(o => o.PhoneNumber);
        }
    }
}
