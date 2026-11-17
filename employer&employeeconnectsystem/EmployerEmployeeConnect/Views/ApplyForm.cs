using EmployerEmployeeConnect.Controllers;
using EmployerEmployeeConnect.Models;

namespace EmployerEmployeeConnect.Views
{
    public partial class ApplyForm : Form
    {
        private readonly int                   _jobPostID;
        private readonly int                   _employeeID;
        private readonly ApplicationController _appCtrl = new();
        private readonly JobPostController     _jobCtrl = new();

        public ApplyForm(int jobPostID, int employeeID)
        {
            _jobPostID  = jobPostID;
            _employeeID = employeeID;
            InitializeComponent();
        }

        private void ApplyForm_Load(object sender, EventArgs e)
        {
            try
            {
                var job = _jobCtrl.GetByID(_jobPostID);
                if (job != null)
                    lblJobInfo.Text = $"Applying for: {job.Title}  |  {job.CompanyName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load job details:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = _appCtrl.Apply(_jobPostID, _employeeID, txtCoverLetter.Text.Trim());

                if (ok)
                {
                    MessageBox.Show("Application submitted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You have already applied for this job.", "Notice",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not submit application:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
