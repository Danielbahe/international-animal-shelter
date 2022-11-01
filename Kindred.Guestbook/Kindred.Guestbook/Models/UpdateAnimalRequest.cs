namespace Kindred.Guestbook.Api.Models
{
    public class UpdateAnimalRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Description { get; set; }
    }
}
