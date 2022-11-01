using Kindred.Guestbook.Domain.Entities;
using MediatR;

namespace Kindred.Guestbook.Domain.Queries.Animals
{
    public record GetAllAnimalsQuery : IRequest<IEnumerable<Animal>>
    {
    }
}
