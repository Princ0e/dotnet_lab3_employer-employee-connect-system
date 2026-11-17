using EmployerEmployeeConnect.Controllers;
using EmployerEmployeeConnect.Models;
using Application = EmployerEmployeeConnect.Models.Application;

namespace EmployerEmployeeConnect.Views
{
    /// <summary>
    /// Employee view: shows all their submitted applications with status.
    /// </summary>
    public partial class MyApplicationsForm : Form
    {
        private readonly int                   _employeeID;
        private readonly ApplicationController _appCtrl = new();

        public MyApplicationsForm(int employeeID)
        {
            _employeeID = employeeID;
            InitializeComponent();
        }

        private void MyApplicationsForm_Load(object sender, EventArgs e) => LoadApplications();

        private void LoadApplications()
        {
            try
            {
                var apps = _appCtrl.GetByEmployee(_employeeID);
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

            string[] visible = { "ApplicationID", "JobTitle", "CompanyName", "Status", "AppliedAt" };
            foreach (string name in visible)
                if (dgvApplications.Columns.Contains(name))
                    dgvApplications.Columns[name].Visible = true;

            if (dgvApplications.Columns.Contains("ApplicationID")) dgvApplications.Columns["ApplicationID"].HeaderText = "ID";
            if (dgvApplications.Columns.Contains("JobTitle"))       dgvApplications.Columns["JobTitle"].HeaderText      = "Job";
            if (dgvApplications.Columns.Contains("CompanyName"))    dgvApplications.Columns["CompanyName"].HeaderText   = "Company";
            if (dgvApplications.Columns.Contains("AppliedAt"))      dgvApplications.Columns["AppliedAt"].HeaderText     = "Applied On";

            // Color-code status
            foreach (DataGridViewRow row in dgvApplications.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString() ?? "";
                row.DefaultCellStyle.ForeColor = status switch
                {
                    "Accepted" => Color.DarkGreen,
                    "Rejected" => Color.Firebrick,
                    "Reviewed" => Color.DarkOrange,
                    _          => Color.Black
                };
            }
        }

        // ── Withdraw application ───────────────────────────────────────
        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0) return;
            var app = (Application)dgvApplications.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show("Withdraw this application?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _appCtrl.Withdraw(app.ApplicationID);
                LoadApplications();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not withdraw application:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
