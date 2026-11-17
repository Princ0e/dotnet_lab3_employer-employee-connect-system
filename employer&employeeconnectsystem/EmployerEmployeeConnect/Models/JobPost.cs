namespace EmployerEmployeeConnect.Models
{
    public class JobPost
    {
        public int JobPostID { get; set; }
        public int EmployerID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty;
        public string JobType { get; set; } = "Full-Time";
        public string Status { get; set; } = "Open";
        public DateTime PostedAt { get; set; }

        // Joined from Employers table for display
        public string CompanyName { get; set; } = string.Empty;
    }
}
