namespace EmployerEmployeeConnect.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public int JobPostID { get; set; }
        public int EmployeeID { get; set; }
        public string CoverLetter { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime AppliedAt { get; set; }

        // Joined fields for display
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string ApplicantName { get; set; } = string.Empty;
        public string ApplicantEmail { get; set; } = string.Empty;
    }
}
