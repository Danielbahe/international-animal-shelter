using CSharpFunctionalExtensions;
using Kindred.Guestbook.Domain.Entities;
using Kindred.Guestbook.Domain.Repositories;
using Kindred.Infrastructure;
using MediatR;
using Serilog;

namespace Kindred.Guestbook.Domain.Commands.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, Response<User>>
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger logger;

        public CreateUserCommandHandler(ILogger logger, IUserRepository userRepository)
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }

        public async Task<Response<User>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = User.Create(request);

            if (user.IsFailure)
            {
                logger.Warning("User can't be created {e}", user.Error);
                return user.ToResponse(ResponseCode.ValidationError);
            }

            userRepository.CreateUser(user.Value);
            await userRepository.SaveAsync();

            return user.ToResponse(ResponseCode.Success);
        }
    }
}
