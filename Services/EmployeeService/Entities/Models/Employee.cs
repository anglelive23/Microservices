namespace EmployeeService.Entities.Models
{
    public class Employee
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(25)] public string Name { get; set; }
        [Required, MaxLength(25)] public string Role { get; set; }
        public string? ImageUrl { get; set; }
    }
}
