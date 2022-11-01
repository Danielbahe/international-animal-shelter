using CSharpFunctionalExtensions;
using MediatR;
using Serilog;
using Shelter.Guestbook.Domain.Entities;
using Shelter.Guestbook.Domain.Repositories;

namespace Shelter.Guestbook.Domain.Commands.Shelters.CreateShelter
{
    public class CreateAnimalShelterCommandHandler : IRequestHandler<CreateAnimalShelterCommandRequest, Result<AnimalShelter>>
    {
        private readonly IAnimalSheltersRepository animalShelterRepository;
        private readonly ILogger logger;

        public CreateAnimalShelterCommandHandler(IAnimalSheltersRepository animalShelterRepository, ILogger logger)
        {
            this.animalShelterRepository = animalShelterRepository;
            this.logger = logger;
        }

        public async Task<Result<AnimalShelter>> Handle(CreateAnimalShelterCommandRequest request, CancellationToken cancellationToken)
        {
            var shelter = AnimalShelter.Create(request);
            if (shelter.IsFailure)
            {
                logger.Warning("Animal shelter can't be creaded: {e}", shelter.Error);
                return shelter;
            }

            animalShelterRepository.AddShelter(shelter.Value);
            await animalShelterRepository.SaveAsync();

            return shelter;
        }
    }
}
