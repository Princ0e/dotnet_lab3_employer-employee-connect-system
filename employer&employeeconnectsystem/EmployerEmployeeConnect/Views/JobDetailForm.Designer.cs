namespace EmployerEmployeeConnect.Views
{
    partial class JobDetailForm
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
            this.lblCompany     = new Label();
            this.lblLocation    = new Label();
            this.lblSalary      = new Label();
            this.lblJobType     = new Label();
            this.lblStatus      = new Label();
            this.lblPosted      = new Label();
            this.lblDescHeader  = new Label();
            this.txtDescription = new RichTextBox();
            this.btnClose       = new Button();
            this.SuspendLayout();

            this.Text            = "Job Details";
            this.Size            = new Size(540, 500);
            this.StartPosition   = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;
            this.Load           += new EventHandler(this.JobDetailForm_Load);

            this.lblTitle.Text      = "";
            this.lblTitle.Font      = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblTitle.Location  = new Point(20, 16);
            this.lblTitle.Size      = new Size(490, 32);

            int y = 60; int lh = 24;
            Label[] meta = { lblCompany, lblLocation, lblSalary, lblJobType, lblStatus, lblPosted };
            foreach (var lbl in meta)
            {
                lbl.Font     = new Font("Segoe UI", 10F);
                lbl.Location = new Point(20, y);
                lbl.Size     = new Size(490, lh);
                y += lh + 4;
            }

            this.lblDescHeader.Text     = "Description:";
            this.lblDescHeader.Font     = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDescHeader.Location = new Point(20, y + 6);
            this.lblDescHeader.Size     = new Size(120, 22);
            y += 32;

            this.txtDescription.Font     = new Font("Segoe UI", 10F);
            this.txtDescription.Location = new Point(20, y);
            this.txtDescription.Size     = new Size(490, 180);
            this.txtDescription.ReadOnly = true;
            this.txtDescription.BackColor = Color.White;
            y += 190;

            this.btnClose.Text      = "Close";
            this.btnClose.Font      = new Font("Segoe UI", 10F);
            this.btnClose.Location  = new Point(20, y);
            this.btnClose.Size      = new Size(100, 34);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Click    += new EventHandler(this.btnClose_Click);

            this.Controls.AddRange(new Control[] {
                lblTitle, lblCompany, lblLocation, lblSalary,
                lblJobType, lblStatus, lblPosted,
                lblDescHeader, txtDescription, btnClose
            });

            this.ResumeLayout(false);
        }

        private Label       lblTitle, lblCompany, lblLocation, lblSalary;
        private Label       lblJobType, lblStatus, lblPosted, lblDescHeader;
        private RichTextBox txtDescription;
        private Button      btnClose;
    }
}
