using CSharpFunctionalExtensions;
using Kindred.Infrastructure;
using MediatR;

namespace Kindred.Guestbook.Domain.Commands.Animals.DeleteAnimal
{
    public record DeleteAnimalCommandRequest : IRequest<Response>
    {
        public Guid Id { get; init; }

        public DeleteAnimalCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
