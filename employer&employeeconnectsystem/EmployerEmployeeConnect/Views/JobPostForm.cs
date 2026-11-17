using EmployerEmployeeConnect.Controllers;
using EmployerEmployeeConnect.Models;

namespace EmployerEmployeeConnect.Views
{
    /// <summary>
    /// Create OR edit a job post. Pass an existing JobPost to edit it.
    /// </summary>
    public partial class JobPostForm : Form
    {
        private readonly int               _employerID;
        private readonly JobPostController _jobCtrl = new();
        private readonly JobPost?          _existing;

        public JobPostForm(int employerID, JobPost? existing = null)
        {
            _employerID = employerID;
            _existing   = existing;
            InitializeComponent();
        }

        private void JobPostForm_Load(object sender, EventArgs e)
        {
            cmbJobType.Items.AddRange(new object[] { "Full-Time", "Part-Time", "Contract", "Internship" });
            cmbStatus.Items.AddRange(new object[]  { "Open", "Closed" });

            if (_existing != null)
            {
                this.Text         = "Edit Job Post";
                lblTitle.Text     = "Edit Job Post";
                txtTitle.Text     = _existing.Title;
                txtDesc.Text      = _existing.Description;
                txtLocation.Text  = _existing.Location;
                txtSalary.Text    = _existing.Salary;
                cmbJobType.SelectedItem = _existing.JobType;
                cmbStatus.SelectedItem  = _existing.Status;
            }
            else
            {
                cmbJobType.SelectedIndex = 0;
                cmbStatus.SelectedIndex  = 0; // defaults to "Open"
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Job title is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var job = new JobPost
            {
                EmployerID  = _employerID,
                Title       = txtTitle.Text.Trim(),
                Description = txtDesc.Text.Trim(),
                Location    = txtLocation.Text.Trim(),
                Salary      = txtSalary.Text.Trim(),
                JobType     = cmbJobType.SelectedItem?.ToString() ?? "Full-Time",
                Status      = cmbStatus.SelectedItem?.ToString()  ?? "Open"
            };

            try
            {
                bool ok;
                if (_existing != null)
                {
                    job.JobPostID = _existing.JobPostID;
                    ok = _jobCtrl.UpdateJobPost(job);
                }
                else
                {
                    ok = _jobCtrl.CreateJobPost(job);
                }

                if (ok)
                {
                    MessageBox.Show("Job post saved successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save job post.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save job post:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
