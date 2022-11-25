using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using Kindred.Infrastructure;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommandRequest, Response<Animal>>
    {
        private readonly IAnimalRepository animalRepository;
        private readonly IShelterRepository shelterRepository;
        private readonly ILogger logger;

        public CreateAnimalCommandHandler(IAnimalRepository animalRepository, ILogger logger, IShelterRepository shelterRepository)
        {
            this.animalRepository = animalRepository;
            this.logger = logger;
            this.shelterRepository = shelterRepository;
        }

        public async Task<Response<Animal>> Handle(CreateAnimalCommandRequest request, CancellationToken cancellationToken)
        {
            var shelterExists = await shelterRepository.ShelterExists(request.ShelterId);

            if (shelterExists.IsFailure)
            {
                logger.Warning("Animal can't be creaded: {e}", shelterExists.Error);
                var result = Result.Failure<Animal>(shelterExists.Error);
                return result.ToResponse(ResponseCode.ValidationError);
            }

            var animal = Animal.Create(request);
            if (animal.IsFailure)
            {
                logger.Warning("Animal can't be creaded: {e}", animal.Error);
                return animal.ToResponse(ResponseCode.ValidationError);
            }

            animalRepository.AddAnimal(animal.Value);
            await animalRepository.SaveAsync();

            return animal.ToResponse(ResponseCode.Created);
        }
    }
}