using EmployerEmployeeConnect.Models;

namespace EmployerEmployeeConnect.Views
{
    public partial class JobDetailForm : Form
    {
        private readonly JobPost _job;

        public JobDetailForm(JobPost job)
        {
            _job = job;
            InitializeComponent();
        }

        private void JobDetailForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text       = _job.Title;
            lblCompany.Text     = $"Company:   {_job.CompanyName}";
            lblLocation.Text    = $"Location:  {_job.Location}";
            lblSalary.Text      = $"Salary:    {_job.Salary}";
            lblJobType.Text     = $"Type:      {_job.JobType}";
            lblStatus.Text      = $"Status:    {_job.Status}";
            lblPosted.Text      = $"Posted:    {_job.PostedAt:MMM dd, yyyy}";
            txtDescription.Text = _job.Description;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
