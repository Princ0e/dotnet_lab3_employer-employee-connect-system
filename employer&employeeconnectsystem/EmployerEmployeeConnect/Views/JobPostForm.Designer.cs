namespace EmployerEmployeeConnect.Views
{
    partial class JobPostForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle    = new Label();
            this.lblJobTitle = new Label();
            this.txtTitle    = new TextBox();
            this.lblDesc     = new Label();
            this.txtDesc     = new RichTextBox();
            this.lblLocation = new Label();
            this.txtLocation = new TextBox();
            this.lblSalary   = new Label();
            this.txtSalary   = new TextBox();
            this.lblJobType  = new Label();
            this.cmbJobType  = new ComboBox();
            this.lblStatus   = new Label();
            this.cmbStatus   = new ComboBox();
            this.btnSave     = new Button();
            this.btnCancel   = new Button();
            this.SuspendLayout();

            this.Text            = "New Job Post";
            this.Size            = new Size(500, 540);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;
            this.Load           += new EventHandler(this.JobPostForm_Load);

            int lx = 30, tx = 30, w = 420, y = 20;

            this.lblTitle.Text     = "New Job Post";
            this.lblTitle.Font     = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitle.Location = new Point(lx, y); y += 36;
            this.lblTitle.Size     = new Size(300, 28);

            SetupRow(ref y, this.lblJobTitle, "Job Title *", this.txtTitle, lx, tx, w);
            this.lblDesc.Text = "Description:"; this.lblDesc.Font = new Font("Segoe UI", 10F);
            this.lblDesc.Location = new Point(lx, y); this.lblDesc.Size = new Size(120, 22); y += 24;
            this.txtDesc.Location = new Point(tx, y); this.txtDesc.Size = new Size(w, 80); y += 90;
            SetupRow(ref y, this.lblLocation, "Location:", this.txtLocation, lx, tx, w);
            SetupRow(ref y, this.lblSalary, "Salary:", this.txtSalary, lx, tx, w);

            this.lblJobType.Text = "Job Type:"; this.lblJobType.Font = new Font("Segoe UI", 10F);
            this.lblJobType.Location = new Point(lx, y); this.lblJobType.Size = new Size(80, 22); y += 24;
            this.cmbJobType.Font = new Font("Segoe UI", 10F); this.cmbJobType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbJobType.Location = new Point(tx, y); this.cmbJobType.Size = new Size(w, 26); y += 44;

            this.lblStatus.Text = "Status:"; this.lblStatus.Font = new Font("Segoe UI", 10F);
            this.lblStatus.Location = new Point(lx, y); this.lblStatus.Size = new Size(60, 22); y += 24;
            this.cmbStatus.Font = new Font("Segoe UI", 10F); this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new Point(tx, y); this.cmbStatus.Size = new Size(w, 26); y += 50;

            this.btnSave.Text = "Save"; this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.Location = new Point(tx, y); this.btnSave.Size = new Size(120, 36);
            this.btnSave.BackColor = Color.SeaGreen; this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel"; this.btnCancel.Font = new Font("Segoe UI", 10F);
            this.btnCancel.Location = new Point(tx + 140, y); this.btnCancel.Size = new Size(100, 36);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            this.Controls.AddRange(new Control[] {
                lblTitle, lblJobTitle, txtTitle, lblDesc, txtDesc,
                lblLocation, txtLocation, lblSalary, txtSalary,
                lblJobType, cmbJobType, lblStatus, cmbStatus,
                btnSave, btnCancel
            });

            this.ResumeLayout(false);
        }

        private static void SetupRow(ref int y, Label lbl, string labelText, Control ctrl, int lx, int tx, int w)
        {
            lbl.Text = labelText; lbl.Font = new Font("Segoe UI", 10F);
            lbl.Location = new Point(lx, y); lbl.Size = new Size(140, 22); y += 24;
            ctrl.Font = new Font("Segoe UI", 10F);
            ctrl.Location = new Point(tx, y); ctrl.Size = new Size(w, 26); y += 44;
        }

        private Label      lblTitle, lblJobTitle, lblDesc, lblLocation, lblSalary, lblJobType, lblStatus;
        private TextBox    txtTitle, txtLocation, txtSalary;
        private RichTextBox txtDesc;
        private ComboBox   cmbJobType, cmbStatus;
        private Button     btnSave, btnCancel;
    }
}
