using CSharpFunctionalExtensions;
using MediatR;
using Serilog;
using Shelter.Guestbook.Domain.Entities;
using Shelter.Guestbook.Domain.Repositories;

namespace Shelter.Guestbook.Domain.Commands.Animals.DeleteAnimal
{
    internal class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommandRequest, Result>
    {
        private readonly IAnimalsRepository animalRepository;
        private readonly ILogger logger;

        public DeleteAnimalCommandHandler(IAnimalsRepository animalRepository, ILogger logger)
        {
            this.animalRepository = animalRepository;
            this.logger = logger;
        }

        public async Task<Result> Handle(DeleteAnimalCommandRequest command, CancellationToken cancellationToken)
        {
            var animalToDelete = await GetAnimalByIdAsync(command.Id);
            await DeleteAnimalAsync(animalToDelete.Value);

            return Result.Success();
        }

        private async Task<Result<Animal>> GetAnimalByIdAsync(Guid id)
        {
            var animalToDelete = await animalRepository.GetByIdAsync(id);
            if (animalToDelete.IsFailure)
            {
                logger.Warning("Animal can't be deleted: {e}", animalToDelete.Error);
            }

            return animalToDelete;
        }

        private async Task DeleteAnimalAsync(Animal animalToDelete)
        {
            animalToDelete.Delete();
            animalRepository.DeleteAnimal(animalToDelete);
            await animalRepository.SaveAsync();
        }
    }
}
