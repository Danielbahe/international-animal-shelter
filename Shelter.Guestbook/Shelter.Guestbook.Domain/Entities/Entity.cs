using CSharpFunctionalExtensions;

namespace Shelter.Guestbook.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
