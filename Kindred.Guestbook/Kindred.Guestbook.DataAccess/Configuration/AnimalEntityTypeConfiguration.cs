using Kindred.Guestbook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindred.Guestbook.DataAccess.Configuration
{
    public class AnimalEntityTypeConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> animalConfiguration)
        {
            animalConfiguration.OwnsOne(o => o.Status);
        }
    }
}
