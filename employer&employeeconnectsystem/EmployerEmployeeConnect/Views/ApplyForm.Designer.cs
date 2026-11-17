namespace EmployerEmployeeConnect.Views
{
    partial class ApplyForm
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
            this.lblJobInfo     = new Label();
            this.lblCoverLetter = new Label();
            this.txtCoverLetter = new RichTextBox();
            this.btnSubmit      = new Button();
            this.btnCancel      = new Button();
            this.SuspendLayout();

            this.Text            = "Apply for Job";
            this.Size            = new Size(500, 400);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;
            this.Load           += new EventHandler(this.ApplyForm_Load);

            this.lblTitle.Text     = "Job Application";
            this.lblTitle.Font     = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Size     = new Size(300, 28);

            this.lblJobInfo.Text     = "";
            this.lblJobInfo.Font     = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblJobInfo.ForeColor = Color.SteelBlue;
            this.lblJobInfo.Location = new Point(30, 56);
            this.lblJobInfo.Size     = new Size(430, 24);

            this.lblCoverLetter.Text     = "Cover Letter (optional):";
            this.lblCoverLetter.Font     = new Font("Segoe UI", 10F);
            this.lblCoverLetter.Location = new Point(30, 92);
            this.lblCoverLetter.Size     = new Size(200, 22);

            this.txtCoverLetter.Font     = new Font("Segoe UI", 10F);
            this.txtCoverLetter.Location = new Point(30, 118);
            this.txtCoverLetter.Size     = new Size(430, 180);

            this.btnSubmit.Text      = "Submit Application";
            this.btnSubmit.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSubmit.Location  = new Point(30, 316);
            this.btnSubmit.Size      = new Size(170, 36);
            this.btnSubmit.BackColor = Color.SeaGreen;
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.Click    += new EventHandler(this.btnSubmit_Click);

            this.btnCancel.Text      = "Cancel";
            this.btnCancel.Font      = new Font("Segoe UI", 10F);
            this.btnCancel.Location  = new Point(220, 316);
            this.btnCancel.Size      = new Size(100, 36);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Click    += new EventHandler(this.btnCancel_Click);

            this.Controls.AddRange(new Control[] {
                lblTitle, lblJobInfo, lblCoverLetter, txtCoverLetter, btnSubmit, btnCancel
            });

            this.ResumeLayout(false);
        }

        private Label       lblTitle, lblJobInfo, lblCoverLetter;
        private RichTextBox txtCoverLetter;
        private Button      btnSubmit, btnCancel;
    }
}
