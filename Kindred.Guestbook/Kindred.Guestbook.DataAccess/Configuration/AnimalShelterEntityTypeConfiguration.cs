using Kindred.Guestbook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindred.Guestbook.DataAccess.Configuration
{
    public class ShelterEntityTypeConfiguration : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> orderConfiguration)
        {
            orderConfiguration.OwnsOne(o => o.Address);
            orderConfiguration.OwnsOne(o => o.Email);
            orderConfiguration.OwnsOne(o => o.PhoneNumber);
        }
    }
}
