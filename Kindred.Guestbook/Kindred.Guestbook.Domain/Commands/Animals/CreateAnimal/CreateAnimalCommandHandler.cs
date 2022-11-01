using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommandRequest, Result<Animal>>
    {
        private readonly IAnimalsRepository animalRepository;
        private readonly ILogger logger;

        public CreateAnimalCommandHandler(IAnimalsRepository animalRepository, ILogger logger)
        {
            this.animalRepository = animalRepository;
            this.logger = logger;
        }

        public async Task<Result<Animal>> Handle(CreateAnimalCommandRequest request, CancellationToken cancellationToken)
        {
            var animal = Animal.Create(request);
            if (animal.IsFailure)
            {
                logger.Warning("Animal can't be creaded: {e}", animal.Error);
                return animal;
            }

            animalRepository.AddAnimal(animal.Value);
            await animalRepository.SaveAsync();

            return animal;
        }
    }
}
