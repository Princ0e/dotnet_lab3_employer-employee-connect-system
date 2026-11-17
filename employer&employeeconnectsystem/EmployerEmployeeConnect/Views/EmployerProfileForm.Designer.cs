namespace EmployerEmployeeConnect.Views
{
    partial class EmployerProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle       = new Label();
            this.lblCompany     = new Label(); this.txtCompany     = new TextBox();
            this.lblIndustry    = new Label(); this.txtIndustry    = new TextBox();
            this.lblLocation    = new Label(); this.txtLocation    = new TextBox();
            this.lblWebsite     = new Label(); this.txtWebsite     = new TextBox();
            this.lblDescription = new Label(); this.txtDescription = new RichTextBox();
            this.btnSave        = new Button();
            this.btnCancel      = new Button();
            this.SuspendLayout();

            this.Text            = "Edit Company Profile";
            this.Size            = new Size(480, 500);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;
            this.Load           += new EventHandler(this.EmployerProfileForm_Load);

            int lx = 30, tx = 30, w = 400, y = 20;

            this.lblTitle.Text = "Edit Company Profile"; this.lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitle.Location = new Point(lx, y); this.lblTitle.Size = new Size(300, 28); y += 44;

            AddRow(ref y, lblCompany, "Company Name *", txtCompany, lx, tx, w);
            AddRow(ref y, lblIndustry, "Industry:", txtIndustry, lx, tx, w);
            AddRow(ref y, lblLocation, "Location:", txtLocation, lx, tx, w);
            AddRow(ref y, lblWebsite, "Website:", txtWebsite, lx, tx, w);

            this.lblDescription.Text = "Description:"; this.lblDescription.Font = new Font("Segoe UI", 10F);
            this.lblDescription.Location = new Point(lx, y); this.lblDescription.Size = new Size(120, 22); y += 24;
            this.txtDescription.Font = new Font("Segoe UI", 10F);
            this.txtDescription.Location = new Point(tx, y); this.txtDescription.Size = new Size(w, 80); y += 94;

            this.btnSave.Text = "Save"; this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.Location = new Point(lx, y); this.btnSave.Size = new Size(110, 36);
            this.btnSave.BackColor = Color.SteelBlue; this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel"; this.btnCancel.Font = new Font("Segoe UI", 10F);
            this.btnCancel.Location = new Point(lx + 126, y); this.btnCancel.Size = new Size(100, 36);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            this.Controls.AddRange(new Control[] {
                lblTitle, lblCompany, txtCompany, lblIndustry, txtIndustry,
                lblLocation, txtLocation, lblWebsite, txtWebsite,
                lblDescription, txtDescription, btnSave, btnCancel
            });

            this.ResumeLayout(false);
        }

        private static void AddRow(ref int y, Label lbl, string text, Control ctrl, int lx, int tx, int w)
        {
            lbl.Text = text; lbl.Font = new Font("Segoe UI", 10F);
            lbl.Location = new Point(lx, y); lbl.Size = new Size(140, 22); y += 24;
            ctrl.Font = new Font("Segoe UI", 10F);
            ctrl.Location = new Point(tx, y); ctrl.Size = new Size(w, 26); y += 44;
        }

        private Label       lblTitle, lblCompany, lblIndustry, lblLocation, lblWebsite, lblDescription;
        private TextBox     txtCompany, txtIndustry, txtLocation, txtWebsite;
        private RichTextBox txtDescription;
        private Button      btnSave, btnCancel;
    }
}
