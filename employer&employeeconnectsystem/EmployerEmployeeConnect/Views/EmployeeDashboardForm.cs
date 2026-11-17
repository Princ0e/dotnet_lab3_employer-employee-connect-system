using EmployerEmployeeConnect.Controllers;
using EmployerEmployeeConnect.Models;

namespace EmployerEmployeeConnect.Views
{
    public partial class EmployeeDashboardForm : Form
    {
        private readonly User                  _user;
        private readonly EmployeeController    _employeeCtrl    = new();
        private readonly JobPostController     _jobCtrl         = new();
        private readonly ApplicationController _applicationCtrl = new();
        private Employee? _employee;

        public EmployeeDashboardForm(User user)
        {
            _user = user;
            InitializeComponent();
        }

        // ── Load ───────────────────────────────────────────────────────
        private void EmployeeDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {_user.FullName}";
            try
            {
                _employee = _employeeCtrl.GetByUserID(_user.UserID);
                LoadOpenJobs();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        // ── Load all open job posts ────────────────────────────────────
        private void LoadOpenJobs()
        {
            try
            {
                var jobs = _jobCtrl.GetAllOpen();
                dgvJobs.DataSource = jobs.Count > 0 ? jobs : new List<JobPost>();
                FormatJobGrid();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void FormatJobGrid()
        {
            if (dgvJobs.Columns.Count == 0) return;
            foreach (DataGridViewColumn col in dgvJobs.Columns) col.Visible = false;

            string[] visible = { "JobPostID", "Title", "CompanyName", "Location", "Salary", "JobType", "PostedAt" };
            foreach (string name in visible)
                if (dgvJobs.Columns.Contains(name))
                    dgvJobs.Columns[name].Visible = true;

            if (dgvJobs.Columns.Contains("CompanyName")) dgvJobs.Columns["CompanyName"].HeaderText = "Company";
            if (dgvJobs.Columns.Contains("PostedAt"))    dgvJobs.Columns["PostedAt"].HeaderText    = "Posted";
            if (dgvJobs.Columns.Contains("JobPostID"))   dgvJobs.Columns["JobPostID"].HeaderText   = "ID";
        }

        // ── Search button ──────────────────────────────────────────────
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string kw  = txtSearch.Text.Trim();
                var    jobs = string.IsNullOrEmpty(kw) ? _jobCtrl.GetAllOpen() : _jobCtrl.Search(kw);
                dgvJobs.DataSource = jobs;
                FormatJobGrid();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        // ── Apply button ───────────────────────────────────────────────
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (_employee == null) { MessageBox.Show("Employee profile not found."); return; }
            if (dgvJobs.SelectedRows.Count == 0) { MessageBox.Show("Select a job first."); return; }

            int jobID = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobPostID"].Value);

            try
            {
                if (_applicationCtrl.HasApplied(jobID, _employee.EmployeeID))
                {
                    MessageBox.Show("You have already applied for this job.", "Notice",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var form = new ApplyForm(jobID, _employee.EmployeeID);
                form.ShowDialog();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        // ── View job details ───────────────────────────────────────────
        private void btnViewJob_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0) return;
            int jobID = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobPostID"].Value);
            try
            {
                var job = _jobCtrl.GetByID(jobID);
                if (job == null) return;
                new JobDetailForm(job).ShowDialog();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        // ── My Applications ────────────────────────────────────────────
        private void btnMyApplications_Click(object sender, EventArgs e)
        {
            if (_employee == null) return;
            new MyApplicationsForm(_employee.EmployeeID).ShowDialog();
        }

        // ── Edit profile ───────────────────────────────────────────────
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (_employee == null) return;
            var form = new EmployeeProfileForm(_employee);
            form.FormClosed += (s, args) =>
            {
                try { _employee = _employeeCtrl.GetByUserID(_user.UserID); }
                catch (Exception ex) { ShowError(ex); }
            };
            form.ShowDialog();
        }

        // ── Logout ─────────────────────────────────────────────────────
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Detach the exit hook so closing this dashboard doesn't kill the new login window
            this.FormClosed -= OnDashboardClosed;
            new LoginForm().Show();
            this.Close();
        }

        // Hook stored so it can be detached on logout
        internal void OnDashboardClosed(object? sender, FormClosedEventArgs e) => System.Windows.Forms.Application.Exit();

        // ── Helper ─────────────────────────────────────────────────────
        private static void ShowError(Exception ex) =>
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
