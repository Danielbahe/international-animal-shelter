using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shelter.Guestbook.Api.Dto;
using Shelter.Guestbook.Api.Models;
using Shelter.Guestbook.Domain.Animals.CreateAnimal;
using Shelter.Guestbook.Domain.Queries.Animals;

namespace Shelter.Guestbook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public AnimalsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
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

        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            var query = new GetAllAnimalsQuery();
            var result = await mediator.Send(query);

            var response = mapper.Map<IEnumerable<AnimalBasicInfoResponse>>(result);

            return Ok(response);
        }
    }
}
