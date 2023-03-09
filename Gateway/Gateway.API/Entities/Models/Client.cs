namespace Microservices.API.Entities.Models
{
    public class Client
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(50)] public string Name { get; set; }
        [Required, MaxLength(200)] public string ImageUrl { get; set; }
    }
}
