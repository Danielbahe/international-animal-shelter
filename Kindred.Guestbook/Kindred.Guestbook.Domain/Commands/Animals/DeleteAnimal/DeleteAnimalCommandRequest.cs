﻿using CSharpFunctionalExtensions;
using MediatR;

namespace Kindred.Guestbook.Domain.Commands.Animals.DeleteAnimal
{
    public record DeleteAnimalCommandRequest : IRequest<Result>
    {
        public Guid Id { get; init; }

        public DeleteAnimalCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}