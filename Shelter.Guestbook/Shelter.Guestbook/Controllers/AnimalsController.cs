using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shelter.Guestbook.Api.Dto;
using Shelter.Guestbook.Domain.Animals.CreateAnimal;

namespace Shelter.Guestbook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AnimalsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimalRequest request)
        {
            var command = new CreateAnimalCommand(request.Name, request.Species, request.Description);
            var result = await mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Error);
            }
        }
    }
}
