using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using Kindred.Infrastructure;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Animals.DeleteAnimal
{
    internal class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommandRequest, Response<Result>>
    {
        private readonly IAnimalsRepository animalRepository;
        private readonly ILogger logger;

        public DeleteAnimalCommandHandler(IAnimalsRepository animalRepository, ILogger logger)
        {
            this.animalRepository = animalRepository;
            this.logger = logger;
        }

        public async Task<Response<Result>> Handle(DeleteAnimalCommandRequest command, CancellationToken cancellationToken)
        {
            var animalToDelete = await animalRepository.GetByIdAsync(command.Id);
            if (animalToDelete.IsFailure)
            {
                logger.Warning("Animal can't be deleted: {e}", animalToDelete.Error);
                return Result.Failure("Animal can't be deleted: {e}").ToResponse(ResponseCode.NotFound);
            }

            await DeleteAnimalAsync(animalToDelete.Value);

            return Result.Success().ToResponse(ResponseCode.Success);
        }

        private async Task DeleteAnimalAsync(Animal animalToDelete)
        {
            animalToDelete.Delete();
            animalRepository.DeleteAnimal(animalToDelete);
            await animalRepository.SaveAsync();
        }
    }
}
