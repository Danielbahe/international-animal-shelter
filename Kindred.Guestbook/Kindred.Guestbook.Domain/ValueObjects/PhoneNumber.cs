using CSharpFunctionalExtensions;
using Kindred.Infrastructure;
using System.Text.RegularExpressions;

namespace Kindred.Guestbook.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Number { get; private set; }
        private PhoneNumber()
        {
        }

        public static Result<PhoneNumber> Create(string number)
        {
            var phoneNumber = new PhoneNumber();

            return Constraints
                .AddResult(phoneNumber.SetNumber(number))
                .CombineIn(phoneNumber);
        }

        private Result<PhoneNumber> SetNumber(string number)
        {
            number = number.Trim();
            if (string.IsNullOrEmpty(number))
            {
                return Result.Failure<PhoneNumber>("Phone Number can't be empty");
            }

            string pattern = @"^\+[1-9]\d{9,14}$";
            var isValid = Regex.IsMatch(number, pattern);
            if (!isValid)
            {
                return Result.Failure<PhoneNumber>("Invalid Phone Number format");
            }

            Number = number;
            return Result.Success(this);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}
