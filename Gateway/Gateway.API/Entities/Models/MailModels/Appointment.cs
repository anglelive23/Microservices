namespace Microservices.API.Entities.Models.MailModels
{
    public class Appointment
    {
        [Key] public string Name { get; set; }
        [MaxLength(50)] public string Email { get; set; }
        [MaxLength(15)] public string Phone { get; set; }
        [MaxLength(200)] public string Message { get; set; }
    }
}
