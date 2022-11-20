using CSharpFunctionalExtensions;
using Kindred.Infrastructure;
using System.Text.RegularExpressions;

namespace Kindred.Guestbook.Domain.ValueObjects
{
    public class EmailAddress : ValueObject
    {
        public string Email { get; private set; }

        private EmailAddress()
        {
        }

        public static Result<EmailAddress> Create(string email)
        {
            var emailAddress = new EmailAddress();
            return Constraints
                .AddResult(emailAddress.SetEmail(email))
                .CombineIn(emailAddress);
        }

        private Result<EmailAddress> SetEmail(string email)
        {
            email = email.Trim();
            if (string.IsNullOrEmpty(email))
            {
                return Result.Failure<EmailAddress>("Email can't be empty");
            }

            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            var isValid = Regex.IsMatch(email, pattern);
            if (!isValid)
            {
                return Result.Failure<EmailAddress>("Invalid email format");
            }

            Email = email;
            return Result.Success(this);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
        }
    }
}
