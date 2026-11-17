namespace EmployerEmployeeConnect.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // "Employer" or "Employee"
        public DateTime CreatedAt { get; set; }
    }
}
