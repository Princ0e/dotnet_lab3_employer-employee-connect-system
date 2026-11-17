namespace EmployerEmployeeConnect.Views
{
    partial class EmployerDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome          = new Label();
            this.lblMyJobs           = new Label();
            this.dgvJobs             = new DataGridView();
            this.btnPostJob          = new Button();
            this.btnEditJob          = new Button();
            this.btnDeleteJob        = new Button();
            this.btnViewApplicants   = new Button();
            this.btnAllApplications  = new Button();
            this.btnEditProfile      = new Button();
            this.btnLogout           = new Button();
            this.pnlTop              = new Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text            = "Employer Dashboard — Employer & Employee Connect";
            this.Size            = new Size(900, 600);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.MinimumSize     = new Size(800, 500);
            this.BackColor       = Color.WhiteSmoke;
            this.Load           += new EventHandler(this.EmployerDashboardForm_Load);

            // pnlTop
            this.pnlTop.Dock      = DockStyle.Top;
            this.pnlTop.Height    = 60;
            this.pnlTop.BackColor = Color.SteelBlue;

            // lblWelcome
            this.lblWelcome.Text      = "Welcome";
            this.lblWelcome.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location  = new Point(16, 14);
            this.lblWelcome.Size      = new Size(500, 30);
            this.pnlTop.Controls.Add(this.lblWelcome);

            // btnLogout
            this.btnLogout.Text      = "Logout";
            this.btnLogout.Font      = new Font("Segoe UI", 9F);
            this.btnLogout.Location  = new Point(780, 14);
            this.btnLogout.Size      = new Size(80, 30);
            this.btnLogout.BackColor = Color.Firebrick;
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.Click    += new EventHandler(this.btnLogout_Click);
            this.pnlTop.Controls.Add(this.btnLogout);

            // lblMyJobs
            this.lblMyJobs.Text     = "My Job Postings";
            this.lblMyJobs.Font     = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblMyJobs.Location = new Point(16, 76);
            this.lblMyJobs.Size     = new Size(200, 24);

            // dgvJobs
            this.dgvJobs.Location             = new Point(16, 106);
            this.dgvJobs.Size                 = new Size(650, 420);
            this.dgvJobs.Anchor               = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            this.dgvJobs.AutoSizeColumnsMode  = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJobs.SelectionMode        = DataGridViewSelectionMode.FullRowSelect;
            this.dgvJobs.MultiSelect          = false;
            this.dgvJobs.ReadOnly             = true;
            this.dgvJobs.AllowUserToAddRows   = false;
            this.dgvJobs.RowHeadersVisible    = false;
            this.dgvJobs.BackgroundColor      = Color.White;

            // Right-side buttons
            int bx = 690, by = 106, bw = 170, bh = 36, bg = 46;

            this.btnPostJob.Text      = "+ Post New Job";
            this.btnPostJob.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnPostJob.Location  = new Point(bx, by); by += bg;
            this.btnPostJob.Size      = new Size(bw, bh);
            this.btnPostJob.BackColor = Color.SeaGreen;
            this.btnPostJob.ForeColor = Color.White;
            this.btnPostJob.FlatStyle = FlatStyle.Flat;
            this.btnPostJob.Click    += new EventHandler(this.btnPostJob_Click);

            this.btnEditJob.Text      = "Edit Selected Job";
            this.btnEditJob.Font      = new Font("Segoe UI", 9F);
            this.btnEditJob.Location  = new Point(bx, by); by += bg;
            this.btnEditJob.Size      = new Size(bw, bh);
            this.btnEditJob.FlatStyle = FlatStyle.Flat;
            this.btnEditJob.Click    += new EventHandler(this.btnEditJob_Click);

            this.btnDeleteJob.Text      = "Delete Selected Job";
            this.btnDeleteJob.Font      = new Font("Segoe UI", 9F);
            this.btnDeleteJob.Location  = new Point(bx, by); by += bg;
            this.btnDeleteJob.Size      = new Size(bw, bh);
            this.btnDeleteJob.BackColor = Color.IndianRed;
            this.btnDeleteJob.ForeColor = Color.White;
            this.btnDeleteJob.FlatStyle = FlatStyle.Flat;
            this.btnDeleteJob.Click    += new EventHandler(this.btnDeleteJob_Click);

            this.btnViewApplicants.Text      = "View Applicants";
            this.btnViewApplicants.Font      = new Font("Segoe UI", 9F);
            this.btnViewApplicants.Location  = new Point(bx, by); by += bg;
            this.btnViewApplicants.Size      = new Size(bw, bh);
            this.btnViewApplicants.BackColor = Color.SteelBlue;
            this.btnViewApplicants.ForeColor = Color.White;
            this.btnViewApplicants.FlatStyle = FlatStyle.Flat;
            this.btnViewApplicants.Click    += new EventHandler(this.btnViewApplicants_Click);

            this.btnAllApplications.Text      = "All Applications";
            this.btnAllApplications.Font      = new Font("Segoe UI", 9F);
            this.btnAllApplications.Location  = new Point(bx, by); by += bg;
            this.btnAllApplications.Size      = new Size(bw, bh);
            this.btnAllApplications.FlatStyle = FlatStyle.Flat;
            this.btnAllApplications.Click    += new EventHandler(this.btnAllApplications_Click);

            this.btnEditProfile.Text      = "Edit Company Profile";
            this.btnEditProfile.Font      = new Font("Segoe UI", 9F);
            this.btnEditProfile.Location  = new Point(bx, by);
            this.btnEditProfile.Size      = new Size(bw, bh);
            this.btnEditProfile.FlatStyle = FlatStyle.Flat;
            this.btnEditProfile.Click    += new EventHandler(this.btnEditProfile_Click);

            this.Controls.AddRange(new Control[] {
                pnlTop, lblMyJobs, dgvJobs,
                btnPostJob, btnEditJob, btnDeleteJob,
                btnViewApplicants, btnAllApplications, btnEditProfile
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel              pnlTop;
        private Label              lblWelcome;
        private Label              lblMyJobs;
        private DataGridView       dgvJobs;
        private Button             btnPostJob, btnEditJob, btnDeleteJob;
        private Button             btnViewApplicants, btnAllApplications, btnEditProfile;
        private Button             btnLogout;
    }
}
