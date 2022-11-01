using AutoMapper;
using Kindred.Guestbook.Api.Models;
using Kindred.Guestbook.Domain.Commands.Animals.CreateAnimal;
using Kindred.Guestbook.Domain.Commands.Animals.DeleteAnimal;
using Kindred.Guestbook.Domain.Commands.Animals.UpdateAnimal;
using Kindred.Guestbook.Domain.Entities;

namespace Kindred.Guestbook.Api.Profiles
{
    public class AnimalsProfile : Profile
    {
        public AnimalsProfile()
        {
            CreateMap<Animal, AnimalBasicInfoResponse>();

            CreateMap<CreateAnimalRequest, CreateAnimalCommandRequest>();
            CreateMap<UpdateAnimalRequest, UpdateAnimalCommandRequest>();
            CreateMap<DeleteAnimalRequest, DeleteAnimalCommandRequest>();
        }
    }
}
