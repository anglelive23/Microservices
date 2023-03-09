namespace Microservices.API.Entities.Models
{
    public class Service
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; } = string.Empty;
        [Required] public string Brief { get; set; } = string.Empty;
        [Required] public string Description { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
    }
}
