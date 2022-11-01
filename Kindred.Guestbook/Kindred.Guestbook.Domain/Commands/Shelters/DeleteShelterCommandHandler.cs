using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Shelters
{
    internal class DeleteShelterCommandHandler : IRequestHandler<DeleteShelterCommandRequest, Result>
    {
        private readonly ISheltersRepository shelterRepository;
        private readonly ILogger logger;

        public DeleteShelterCommandHandler(ISheltersRepository shelterRepository, ILogger logger)
        {
            this.shelterRepository = shelterRepository;
            this.logger = logger;
        }

        public async Task<Result> Handle(DeleteShelterCommandRequest command, CancellationToken cancellationToken)
        {
            var shelterToDelete = await GetShelterByIdAsync(command.Id);
            await DeleteShelterAsync(shelterToDelete.Value);

            return Result.Success();
        }

        private async Task<Result<Shelter>> GetShelterByIdAsync(Guid id)
        {
            var shelterToDelete = await shelterRepository.GetByIdAsync(id);
            if (shelterToDelete.IsFailure)
            {
                logger.Warning("Shelter can't be deleted: {e}", shelterToDelete.Error);
            }

            return shelterToDelete;
        }

        private async Task DeleteShelterAsync(Shelter ShelterToDelete)
        {
            ShelterToDelete.Delete();
            shelterRepository.DeleteShelter(ShelterToDelete);
            await shelterRepository.SaveAsync();
        }
    }
}
