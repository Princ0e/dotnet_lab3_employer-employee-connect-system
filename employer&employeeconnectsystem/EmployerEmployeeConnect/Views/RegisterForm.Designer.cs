namespace EmployerEmployeeConnect.Views
{
    partial class RegisterForm
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
            this.lblFullName = new Label();
            this.txtFullName = new TextBox();
            this.lblEmail    = new Label();
            this.txtEmail    = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblConfirm  = new Label();
            this.txtConfirm  = new TextBox();
            this.lblRole     = new Label();
            this.cmbRole     = new ComboBox();
            this.lblCompany  = new Label();
            this.txtCompany  = new TextBox();
            this.btnRegister = new Button();
            this.btnBack     = new Button();
            this.SuspendLayout();

            // Form
            this.Text            = "Register — Employer & Employee Connect";
            this.Size            = new Size(440, 500);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;

            int lx = 50, tx = 50, w = 320, lh = 22, th = 26, gap = 52;
            int y = 20;

            // Title
            this.lblTitle.Text     = "Create an Account";
            this.lblTitle.Font     = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblTitle.Location = new Point(100, y);
            this.lblTitle.Size     = new Size(240, 30);
            y += 46;

            // FullName
            this.lblFullName.Text = "Full Name:"; this.lblFullName.Font = new Font("Segoe UI", 10F);
            this.lblFullName.Location = new Point(lx, y); this.lblFullName.Size = new Size(100, lh);
            y += 24;
            this.txtFullName.Font = new Font("Segoe UI", 10F);
            this.txtFullName.Location = new Point(tx, y); this.txtFullName.Size = new Size(w, th);
            y += gap;

            // Email
            this.lblEmail.Text = "Email:"; this.lblEmail.Font = new Font("Segoe UI", 10F);
            this.lblEmail.Location = new Point(lx, y); this.lblEmail.Size = new Size(60, lh);
            y += 24;
            this.txtEmail.Font = new Font("Segoe UI", 10F);
            this.txtEmail.Location = new Point(tx, y); this.txtEmail.Size = new Size(w, th);
            y += gap;

            // Password
            this.lblPassword.Text = "Password:"; this.lblPassword.Font = new Font("Segoe UI", 10F);
            this.lblPassword.Location = new Point(lx, y); this.lblPassword.Size = new Size(80, lh);
            y += 24;
            this.txtPassword.Font = new Font("Segoe UI", 10F); this.txtPassword.PasswordChar = '*';
            this.txtPassword.Location = new Point(tx, y); this.txtPassword.Size = new Size(w, th);
            y += gap;

            // Confirm
            this.lblConfirm.Text = "Confirm Password:"; this.lblConfirm.Font = new Font("Segoe UI", 10F);
            this.lblConfirm.Location = new Point(lx, y); this.lblConfirm.Size = new Size(140, lh);
            y += 24;
            this.txtConfirm.Font = new Font("Segoe UI", 10F); this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Location = new Point(tx, y); this.txtConfirm.Size = new Size(w, th);
            y += gap;

            // Role
            this.lblRole.Text = "Register as:"; this.lblRole.Font = new Font("Segoe UI", 10F);
            this.lblRole.Location = new Point(lx, y); this.lblRole.Size = new Size(100, lh);
            y += 24;
            this.cmbRole.Font = new Font("Segoe UI", 10F); this.cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRole.Items.AddRange(new object[] { "Employee", "Employer" });
            this.cmbRole.Location = new Point(tx, y); this.cmbRole.Size = new Size(w, th);
            this.cmbRole.SelectedIndexChanged += new EventHandler(this.cmbRole_SelectedIndexChanged);
            y += gap;

            // Company (Employer only)
            this.lblCompany.Text = "Company Name:"; this.lblCompany.Font = new Font("Segoe UI", 10F);
            this.lblCompany.Location = new Point(lx, y); this.lblCompany.Size = new Size(130, lh);
            this.lblCompany.Visible = false;
            y += 24;
            this.txtCompany.Font = new Font("Segoe UI", 10F);
            this.txtCompany.Location = new Point(tx, y); this.txtCompany.Size = new Size(w, th);
            this.txtCompany.Visible = false;
            y += gap;

            // Buttons
            this.btnRegister.Text = "Register"; this.btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRegister.Location = new Point(50, y); this.btnRegister.Size = new Size(130, 36);
            this.btnRegister.BackColor = Color.SteelBlue; this.btnRegister.ForeColor = Color.White;
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            this.btnBack.Text = "Back to Login"; this.btnBack.Font = new Font("Segoe UI", 9F);
            this.btnBack.Location = new Point(200, y); this.btnBack.Size = new Size(120, 36);
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            this.Controls.AddRange(new Control[] {
                lblTitle, lblFullName, txtFullName,
                lblEmail, txtEmail, lblPassword, txtPassword,
                lblConfirm, txtConfirm, lblRole, cmbRole,
                lblCompany, txtCompany, btnRegister, btnBack
            });

            this.AutoScroll = true;
            this.ResumeLayout(false);
        }

        private Label   lblTitle, lblFullName, lblEmail, lblPassword, lblConfirm, lblRole, lblCompany;
        private TextBox txtFullName, txtEmail, txtPassword, txtConfirm, txtCompany;
        private ComboBox cmbRole;
        private Button  btnRegister, btnBack;
    }
}
