namespace EmployerEmployeeConnect.Models
{
    public class Employer
    {
        public int EmployerID { get; set; }
        public int UserID { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Joined from Users table for display
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
