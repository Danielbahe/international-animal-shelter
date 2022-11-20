using CSharpFunctionalExtensions;
using Kindred.Infrastructure;

namespace Kindred.Guestbook.Domain.ValueObjects
{
    public enum AnimalStatusValue
    {
        None = 0,
        Lost = 1,
        Found = 2,
        Adoptable = 3,
        Adopted = 4,
    }

    public class AnimalStatus : ValueObject
    {
        public AnimalStatusValue Status { get; private set; }

        private AnimalStatus()
        {
            Status = AnimalStatusValue.None;
        }

        public static Result<AnimalStatus> CreateAdoptable()
        {
            var phoneNumber = new AnimalStatus();
            return Constraints
                .AddResult(phoneNumber.SetStatus(AnimalStatusValue.Adoptable))
                .CombineIn(phoneNumber);
        }

        public static Result<AnimalStatus> CreateLost()
        {
            var animalStatus = new AnimalStatus();
            return Constraints
                .AddResult(animalStatus.SetStatus(AnimalStatusValue.Lost))
                .CombineIn(animalStatus);
        }

        public Result<AnimalStatus> UpdateStatus(AnimalStatusValue newStatus)
        {
            return Constraints
                .AddResult(SetStatus(newStatus))
                .CombineIn(this);
        }

        private Result<AnimalStatus> SetStatus(AnimalStatusValue newStatus)
        {
            if (Status == AnimalStatusValue.None && (newStatus == AnimalStatusValue.Adopted || newStatus == AnimalStatusValue.None || newStatus == AnimalStatusValue.Found))
            {
                return Result.Failure<AnimalStatus>("Status " + newStatus.ToString() + " can't be initial status");
            }
            Status = newStatus;

            return Result.Success(this);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Status;
        }
    }
}
