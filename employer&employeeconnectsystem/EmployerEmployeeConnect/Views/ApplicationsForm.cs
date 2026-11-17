using EmployerEmployeeConnect.Controllers;
using EmployerEmployeeConnect.Models;
using Application = EmployerEmployeeConnect.Models.Application;

namespace EmployerEmployeeConnect.Views
{
    /// <summary>
    /// Employer view: lists all applications for their jobs.
    /// Pass jobPostID to filter by one job, or omit for all jobs.
    /// </summary>
    public partial class ApplicationsForm : Form
    {
        private readonly int                   _employerID;
        private readonly int?                  _jobPostID;
        private readonly ApplicationController _appCtrl = new();

        public ApplicationsForm(int employerID, int? jobPostID = null)
        {
            _employerID = employerID;
            _jobPostID  = jobPostID;
            InitializeComponent();
        }

        private void ApplicationsForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = _jobPostID.HasValue
                ? "Applications for Selected Job"
                : "All Applications";
            LoadApplications();
        }

        private void LoadApplications()
        {
            try
            {
                List<Application> apps = _jobPostID.HasValue
                    ? _appCtrl.GetByJobPost(_jobPostID.Value)
                    : _appCtrl.GetByEmployer(_employerID);

                dgvApplications.DataSource = apps;
                FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not load applications:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvApplications.Columns.Count == 0) return;
            foreach (DataGridViewColumn col in dgvApplications.Columns) col.Visible = false;

            string[] visible = { "ApplicationID", "JobTitle", "ApplicantName", "ApplicantEmail", "Status", "AppliedAt" };
            foreach (string name in visible)
                if (dgvApplications.Columns.Contains(name))
                    dgvApplications.Columns[name].Visible = true;

            if (dgvApplications.Columns.Contains("ApplicationID")) dgvApplications.Columns["ApplicationID"].HeaderText = "ID";
            if (dgvApplications.Columns.Contains("JobTitle"))       dgvApplications.Columns["JobTitle"].HeaderText      = "Job";
            if (dgvApplications.Columns.Contains("ApplicantName"))  dgvApplications.Columns["ApplicantName"].HeaderText = "Applicant";
            if (dgvApplications.Columns.Contains("ApplicantEmail")) dgvApplications.Columns["ApplicantEmail"].HeaderText= "Email";
            if (dgvApplications.Columns.Contains("AppliedAt"))      dgvApplications.Columns["AppliedAt"].HeaderText     = "Applied On";
        }

        // ── View cover letter ──────────────────────────────────────────
        private void btnViewCover_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0) return;
            var app = (Application)dgvApplications.SelectedRows[0].DataBoundItem;
            MessageBox.Show(
                string.IsNullOrEmpty(app.CoverLetter) ? "(No cover letter provided)" : app.CoverLetter,
                $"Cover Letter — {app.ApplicantName}",
                MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        // ── Update status ──────────────────────────────────────────────
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0) return;
            var app = (Application)dgvApplications.SelectedRows[0].DataBoundItem;

            string? newStatus = cmbStatus.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(newStatus))
            {
                MessageBox.Show("Choose a status first.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _appCtrl.UpdateStatus(app.ApplicationID, newStatus);
                MessageBox.Show("Status updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadApplications();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not update status:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
