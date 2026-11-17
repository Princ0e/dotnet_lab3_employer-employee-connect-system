namespace EmployerEmployeeConnect.Views
{
    partial class EmployeeDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop           = new Panel();
            this.lblWelcome       = new Label();
            this.btnLogout        = new Button();
            this.pnlSearch        = new Panel();
            this.txtSearch        = new TextBox();
            this.btnSearch        = new Button();
            this.lblBrowse        = new Label();
            this.dgvJobs          = new DataGridView();
            this.btnApply         = new Button();
            this.btnViewJob       = new Button();
            this.btnMyApplications = new Button();
            this.btnEditProfile   = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text          = "Employee Dashboard — Employer & Employee Connect";
            this.Size          = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize   = new Size(800, 500);
            this.BackColor     = Color.WhiteSmoke;
            this.Load         += new EventHandler(this.EmployeeDashboardForm_Load);

            // pnlTop
            this.pnlTop.Dock      = DockStyle.Top;
            this.pnlTop.Height    = 60;
            this.pnlTop.BackColor = Color.DarkSlateBlue;

            this.lblWelcome.Text      = "Welcome";
            this.lblWelcome.Font      = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location  = new Point(16, 14);
            this.lblWelcome.Size      = new Size(500, 30);
            this.pnlTop.Controls.Add(this.lblWelcome);

            this.btnLogout.Text      = "Logout";
            this.btnLogout.Font      = new Font("Segoe UI", 9F);
            this.btnLogout.Location  = new Point(780, 14);
            this.btnLogout.Size      = new Size(80, 30);
            this.btnLogout.BackColor = Color.Firebrick;
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.Click    += new EventHandler(this.btnLogout_Click);
            this.pnlTop.Controls.Add(this.btnLogout);

            // pnlSearch
            this.pnlSearch.Location  = new Point(16, 68);
            this.pnlSearch.Size      = new Size(650, 36);

            this.txtSearch.Font        = new Font("Segoe UI", 10F);
            this.txtSearch.Location    = new Point(0, 4);
            this.txtSearch.Size        = new Size(480, 28);
            this.txtSearch.PlaceholderText = "Search jobs by title, company, or location...";
            this.pnlSearch.Controls.Add(this.txtSearch);

            this.btnSearch.Text      = "Search";
            this.btnSearch.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSearch.Location  = new Point(490, 2);
            this.btnSearch.Size      = new Size(80, 32);
            this.btnSearch.BackColor = Color.DarkSlateBlue;
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Click    += new EventHandler(this.btnSearch_Click);
            this.pnlSearch.Controls.Add(this.btnSearch);

            // lblBrowse
            this.lblBrowse.Text     = "Browse Open Jobs";
            this.lblBrowse.Font     = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblBrowse.Location = new Point(16, 112);
            this.lblBrowse.Size     = new Size(200, 24);

            // dgvJobs
            this.dgvJobs.Location            = new Point(16, 140);
            this.dgvJobs.Size                = new Size(650, 390);
            this.dgvJobs.Anchor              = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            this.dgvJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJobs.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            this.dgvJobs.MultiSelect         = false;
            this.dgvJobs.ReadOnly            = true;
            this.dgvJobs.AllowUserToAddRows  = false;
            this.dgvJobs.RowHeadersVisible   = false;
            this.dgvJobs.BackgroundColor     = Color.White;

            // Right-side buttons
            int bx = 690, by = 140, bw = 170, bh = 36, bg = 46;

            this.btnApply.Text      = "Apply for Job";
            this.btnApply.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnApply.Location  = new Point(bx, by); by += bg;
            this.btnApply.Size      = new Size(bw, bh);
            this.btnApply.BackColor = Color.SeaGreen;
            this.btnApply.ForeColor = Color.White;
            this.btnApply.FlatStyle = FlatStyle.Flat;
            this.btnApply.Click    += new EventHandler(this.btnApply_Click);

            this.btnViewJob.Text      = "View Job Details";
            this.btnViewJob.Font      = new Font("Segoe UI", 9F);
            this.btnViewJob.Location  = new Point(bx, by); by += bg;
            this.btnViewJob.Size      = new Size(bw, bh);
            this.btnViewJob.FlatStyle = FlatStyle.Flat;
            this.btnViewJob.Click    += new EventHandler(this.btnViewJob_Click);

            this.btnMyApplications.Text      = "My Applications";
            this.btnMyApplications.Font      = new Font("Segoe UI", 9F);
            this.btnMyApplications.Location  = new Point(bx, by); by += bg;
            this.btnMyApplications.Size      = new Size(bw, bh);
            this.btnMyApplications.BackColor = Color.DarkSlateBlue;
            this.btnMyApplications.ForeColor = Color.White;
            this.btnMyApplications.FlatStyle = FlatStyle.Flat;
            this.btnMyApplications.Click    += new EventHandler(this.btnMyApplications_Click);

            this.btnEditProfile.Text      = "Edit My Profile";
            this.btnEditProfile.Font      = new Font("Segoe UI", 9F);
            this.btnEditProfile.Location  = new Point(bx, by);
            this.btnEditProfile.Size      = new Size(bw, bh);
            this.btnEditProfile.FlatStyle = FlatStyle.Flat;
            this.btnEditProfile.Click    += new EventHandler(this.btnEditProfile_Click);

            this.Controls.AddRange(new Control[] {
                pnlTop, pnlSearch, lblBrowse, dgvJobs,
                btnApply, btnViewJob, btnMyApplications, btnEditProfile
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel          pnlTop, pnlSearch;
        private Label          lblWelcome, lblBrowse;
        private Button         btnLogout;
        private TextBox        txtSearch;
        private Button         btnSearch;
        private DataGridView   dgvJobs;
        private Button         btnApply, btnViewJob, btnMyApplications, btnEditProfile;
    }
}
