using EmployerEmployeeConnect.Controllers;
using EmployerEmployeeConnect.Models;

namespace EmployerEmployeeConnect.Views
{
    public partial class EmployerDashboardForm : Form
    {
        private readonly User                  _user;
        private readonly EmployerController    _employerCtrl    = new();
        private readonly JobPostController     _jobCtrl         = new();
        private readonly ApplicationController _applicationCtrl = new();
        private Employer? _employer;

        public EmployerDashboardForm(User user)
        {
            _user = user;
            InitializeComponent();
        }

        // ── Load ───────────────────────────────────────────────────────
        private void EmployerDashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {_user.FullName}";
            try
            {
                _employer = _employerCtrl.GetByUserID(_user.UserID);
                LoadJobPosts();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        // ── Load this employer's job posts into the grid ───────────────
        private void LoadJobPosts()
        {
            try
            {
                if (_employer == null) return;
                var jobs = _jobCtrl.GetByEmployer(_employer.EmployerID);
                dgvJobs.DataSource = jobs.Count > 0 ? jobs : new List<JobPost>();
                FormatJobGrid();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void FormatJobGrid()
        {
            if (dgvJobs.Columns.Count == 0) return;
            foreach (DataGridViewColumn col in dgvJobs.Columns)
                col.Visible = false;

            string[] visible = { "JobPostID", "Title", "Location", "Salary", "JobType", "Status", "PostedAt" };
            foreach (string name in visible)
                if (dgvJobs.Columns.Contains(name))
                    dgvJobs.Columns[name].Visible = true;

            if (dgvJobs.Columns.Contains("JobPostID")) dgvJobs.Columns["JobPostID"].HeaderText = "ID";
            if (dgvJobs.Columns.Contains("PostedAt"))  dgvJobs.Columns["PostedAt"].HeaderText  = "Posted";
        }

        // ── Post New Job ───────────────────────────────────────────────
        private void btnPostJob_Click(object sender, EventArgs e)
        {
            if (_employer == null) { MessageBox.Show("Profile not found."); return; }
            var form = new JobPostForm(_employer.EmployerID);
            form.FormClosed += (s, args) => LoadJobPosts();
            form.ShowDialog();
        }

        // ── Edit selected job ──────────────────────────────────────────
        private void btnEditJob_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0) return;
            int jobID = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobPostID"].Value);
            try
            {
                var job = _jobCtrl.GetByID(jobID);
                if (job == null) return;
                var form = new JobPostForm(_employer!.EmployerID, job);
                form.FormClosed += (s, args) => LoadJobPosts();
                form.ShowDialog();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        // ── Delete selected job ────────────────────────────────────────
        private void btnDeleteJob_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0) return;
            int jobID = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobPostID"].Value);

            var confirm = MessageBox.Show("Delete this job post and all its applications?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _jobCtrl.DeleteJobPost(jobID);
                LoadJobPosts();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        // ── View applications for selected job ─────────────────────────
        private void btnViewApplicants_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0) return;
            int jobID = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobPostID"].Value);
            new ApplicationsForm(_employer!.EmployerID, jobPostID: jobID).ShowDialog();
        }

        // ── View all applications across all jobs ──────────────────────
        private void btnAllApplications_Click(object sender, EventArgs e)
        {
            if (_employer == null) return;
            new ApplicationsForm(_employer.EmployerID).ShowDialog();
        }

        // ── Edit company profile ───────────────────────────────────────
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (_employer == null) return;
            var form = new EmployerProfileForm(_employer);
            form.FormClosed += (s, args) =>
            {
                try { _employer = _employerCtrl.GetByUserID(_user.UserID); }
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
