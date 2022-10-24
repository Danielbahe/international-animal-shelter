using MediatR;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.Domain.Queries.Animals
{
    public record GetAllAnimalsQuery : IRequest<IEnumerable<Animal>>
    {
    }
}
