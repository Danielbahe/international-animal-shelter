using AutoMapper;
using Kindred.Guestbook.Api.Models.User;
using Kindred.Guestbook.Domain.Commands.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kindred.Guestbook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var command = mapper.Map<CreateUserCommandRequest>(request);
            var response = await mediator.Send(command);

            return MapToHttpResponse(response, nameof(CreateUser), response.Result.Value.Id);
        }
    }
}
