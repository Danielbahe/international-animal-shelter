using CSharpFunctionalExtensions;

namespace Kindred.Guestbook.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public bool IsDeleted { get; protected set; } = false;
    }
}
