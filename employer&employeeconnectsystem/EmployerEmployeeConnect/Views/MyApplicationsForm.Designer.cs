namespace EmployerEmployeeConnect.Views
{
    partial class MyApplicationsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle        = new Label();
            this.dgvApplications = new DataGridView();
            this.btnWithdraw     = new Button();
            this.btnClose        = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.SuspendLayout();

            this.Text            = "My Applications";
            this.Size            = new Size(720, 480);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;
            this.Load           += new EventHandler(this.MyApplicationsForm_Load);

            this.lblTitle.Text     = "My Applications";
            this.lblTitle.Font     = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitle.Location = new Point(16, 16);
            this.lblTitle.Size     = new Size(400, 28);

            this.dgvApplications.Location            = new Point(16, 56);
            this.dgvApplications.Size                = new Size(672, 340);
            this.dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplications.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplications.MultiSelect         = false;
            this.dgvApplications.ReadOnly            = true;
            this.dgvApplications.AllowUserToAddRows  = false;
            this.dgvApplications.RowHeadersVisible   = false;
            this.dgvApplications.BackgroundColor     = Color.White;

            this.btnWithdraw.Text      = "Withdraw Application";
            this.btnWithdraw.Font      = new Font("Segoe UI", 9F);
            this.btnWithdraw.Location  = new Point(16, 414);
            this.btnWithdraw.Size      = new Size(170, 32);
            this.btnWithdraw.BackColor = Color.IndianRed;
            this.btnWithdraw.ForeColor = Color.White;
            this.btnWithdraw.FlatStyle = FlatStyle.Flat;
            this.btnWithdraw.Click    += new EventHandler(this.btnWithdraw_Click);

            this.btnClose.Text      = "Close";
            this.btnClose.Font      = new Font("Segoe UI", 9F);
            this.btnClose.Location  = new Point(200, 414);
            this.btnClose.Size      = new Size(90, 32);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Click    += new EventHandler(this.btnClose_Click);

            this.Controls.AddRange(new Control[] {
                lblTitle, dgvApplications, btnWithdraw, btnClose
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.ResumeLayout(false);
        }

        private Label        lblTitle;
        private DataGridView dgvApplications;
        private Button       btnWithdraw, btnClose;
    }
}
