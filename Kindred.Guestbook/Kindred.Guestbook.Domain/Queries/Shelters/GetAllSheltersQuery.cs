using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using MediatR;

namespace Kindred.Guestbook.Domain.Queries.Shelters
{
    public class GetAllSheltersQueryRequest : IRequest<IEnumerable<Shelter>>
    {
    }
}
