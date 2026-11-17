namespace EmployerEmployeeConnect.Views
{
    partial class EmployeeProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle      = new Label();
            this.lblSkills     = new Label(); this.txtSkills     = new TextBox();
            this.lblExperience = new Label(); this.txtExperience = new TextBox();
            this.lblEducation  = new Label(); this.txtEducation  = new TextBox();
            this.lblResume     = new Label(); this.txtResume     = new RichTextBox();
            this.btnSave       = new Button();
            this.btnCancel     = new Button();
            this.SuspendLayout();

            this.Text            = "Edit My Profile";
            this.Size            = new Size(480, 500);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;
            this.Load           += new EventHandler(this.EmployeeProfileForm_Load);

            int lx = 30, tx = 30, w = 400, y = 20;

            this.lblTitle.Text = "Edit My Profile"; this.lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitle.Location = new Point(lx, y); this.lblTitle.Size = new Size(300, 28); y += 44;

            AddRow(ref y, lblSkills,     "Skills:",      txtSkills,     lx, tx, w);
            AddRow(ref y, lblExperience, "Experience:",  txtExperience, lx, tx, w);
            AddRow(ref y, lblEducation,  "Education:",   txtEducation,  lx, tx, w);

            this.lblResume.Text = "Resume / Summary:"; this.lblResume.Font = new Font("Segoe UI", 10F);
            this.lblResume.Location = new Point(lx, y); this.lblResume.Size = new Size(160, 22); y += 24;
            this.txtResume.Font = new Font("Segoe UI", 10F);
            this.txtResume.Location = new Point(tx, y); this.txtResume.Size = new Size(w, 100); y += 110;

            this.btnSave.Text = "Save"; this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.Location = new Point(lx, y); this.btnSave.Size = new Size(110, 36);
            this.btnSave.BackColor = Color.DarkSlateBlue; this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel"; this.btnCancel.Font = new Font("Segoe UI", 10F);
            this.btnCancel.Location = new Point(lx + 126, y); this.btnCancel.Size = new Size(100, 36);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            this.Controls.AddRange(new Control[] {
                lblTitle, lblSkills, txtSkills, lblExperience, txtExperience,
                lblEducation, txtEducation, lblResume, txtResume,
                btnSave, btnCancel
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

        private Label       lblTitle, lblSkills, lblExperience, lblEducation, lblResume;
        private TextBox     txtSkills, txtExperience, txtEducation;
        private RichTextBox txtResume;
        private Button      btnSave, btnCancel;
    }
}
