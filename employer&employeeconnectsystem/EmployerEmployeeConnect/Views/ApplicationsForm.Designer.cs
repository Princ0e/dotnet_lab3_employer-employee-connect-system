namespace EmployerEmployeeConnect.Views
{
    partial class ApplicationsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle          = new Label();
            this.dgvApplications   = new DataGridView();
            this.lblChangeStatus   = new Label();
            this.cmbStatus         = new ComboBox();
            this.btnUpdateStatus   = new Button();
            this.btnViewCover      = new Button();
            this.btnClose          = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.SuspendLayout();

            this.Text            = "Applications";
            this.Size            = new Size(820, 520);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;
            this.Load           += new EventHandler(this.ApplicationsForm_Load);

            this.lblTitle.Text     = "Applications";
            this.lblTitle.Font     = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitle.Location = new Point(16, 16);
            this.lblTitle.Size     = new Size(500, 28);

            this.dgvApplications.Location            = new Point(16, 56);
            this.dgvApplications.Size                = new Size(770, 340);
            this.dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplications.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplications.MultiSelect         = false;
            this.dgvApplications.ReadOnly            = true;
            this.dgvApplications.AllowUserToAddRows  = false;
            this.dgvApplications.RowHeadersVisible   = false;
            this.dgvApplications.BackgroundColor     = Color.White;

            this.lblChangeStatus.Text     = "Change Status:";
            this.lblChangeStatus.Font     = new Font("Segoe UI", 10F);
            this.lblChangeStatus.Location = new Point(16, 414);
            this.lblChangeStatus.Size     = new Size(120, 24);

            this.cmbStatus.Font          = new Font("Segoe UI", 10F);
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "Pending", "Reviewed", "Accepted", "Rejected" });
            this.cmbStatus.Location = new Point(140, 412);
            this.cmbStatus.Size     = new Size(140, 28);

            this.btnUpdateStatus.Text      = "Update Status";
            this.btnUpdateStatus.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnUpdateStatus.Location  = new Point(296, 410);
            this.btnUpdateStatus.Size      = new Size(130, 32);
            this.btnUpdateStatus.BackColor = Color.SteelBlue;
            this.btnUpdateStatus.ForeColor = Color.White;
            this.btnUpdateStatus.FlatStyle = FlatStyle.Flat;
            this.btnUpdateStatus.Click    += new EventHandler(this.btnUpdateStatus_Click);

            this.btnViewCover.Text      = "View Cover Letter";
            this.btnViewCover.Font      = new Font("Segoe UI", 9F);
            this.btnViewCover.Location  = new Point(440, 410);
            this.btnViewCover.Size      = new Size(140, 32);
            this.btnViewCover.FlatStyle = FlatStyle.Flat;
            this.btnViewCover.Click    += new EventHandler(this.btnViewCover_Click);

            this.btnClose.Text      = "Close";
            this.btnClose.Font      = new Font("Segoe UI", 9F);
            this.btnClose.Location  = new Point(596, 410);
            this.btnClose.Size      = new Size(90, 32);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Click    += new EventHandler(this.btnClose_Click);

            this.Controls.AddRange(new Control[] {
                lblTitle, dgvApplications,
                lblChangeStatus, cmbStatus, btnUpdateStatus,
                btnViewCover, btnClose
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.ResumeLayout(false);
        }

        private Label          lblTitle, lblChangeStatus;
        private DataGridView   dgvApplications;
        private ComboBox       cmbStatus;
        private Button         btnUpdateStatus, btnViewCover, btnClose;
    }
}
