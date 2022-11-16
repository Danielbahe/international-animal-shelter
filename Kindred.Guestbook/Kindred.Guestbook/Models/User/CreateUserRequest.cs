namespace Kindred.Guestbook.Api.Models.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
