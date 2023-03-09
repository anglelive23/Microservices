namespace Microservices.API.Entities.Dtos.DTO.Response
{
    public class ServicesResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brief { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
    }
}
