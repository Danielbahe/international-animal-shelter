using AutoMapper;
using Shelter.Guestbook.Api.Models;
using Shelter.Guestbook.Domain.Entities;

namespace Shelter.Guestbook.Api.Profiles
{
    public class AnimalsProfile : Profile
    {
        public AnimalsProfile()
        {
            CreateMap<Animal, AnimalBasicInfoResponse>();
        }
    }
}
