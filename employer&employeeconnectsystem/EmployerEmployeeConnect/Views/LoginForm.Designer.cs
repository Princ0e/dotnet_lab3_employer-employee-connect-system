namespace EmployerEmployeeConnect.Views
{
    partial class LoginForm
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
            this.lblEmail    = new Label();
            this.txtEmail    = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin    = new Button();
            this.btnRegister = new Button();
            this.lblRegister = new Label();
            this.SuspendLayout();

            // Form
            this.Text            = "Employer & Employee Connect — Login";
            this.Size            = new Size(420, 340);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.BackColor       = Color.WhiteSmoke;

            // lblTitle
            this.lblTitle.Text      = "Welcome Back";
            this.lblTitle.Font      = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.Location  = new Point(120, 20);
            this.lblTitle.Size      = new Size(200, 32);

            // lblEmail
            this.lblEmail.Text     = "Email:";
            this.lblEmail.Font     = new Font("Segoe UI", 10F);
            this.lblEmail.Location = new Point(50, 80);
            this.lblEmail.Size     = new Size(60, 22);

            // txtEmail
            this.txtEmail.Font     = new Font("Segoe UI", 10F);
            this.txtEmail.Location = new Point(50, 104);
            this.txtEmail.Size     = new Size(300, 26);

            // lblPassword
            this.lblPassword.Text     = "Password:";
            this.lblPassword.Font     = new Font("Segoe UI", 10F);
            this.lblPassword.Location = new Point(50, 148);
            this.lblPassword.Size     = new Size(80, 22);

            // txtPassword
            this.txtPassword.Font         = new Font("Segoe UI", 10F);
            this.txtPassword.Location     = new Point(50, 172);
            this.txtPassword.Size         = new Size(300, 26);
            this.txtPassword.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Text      = "Login";
            this.btnLogin.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLogin.Location  = new Point(50, 220);
            this.btnLogin.Size      = new Size(130, 36);
            this.btnLogin.BackColor = Color.SteelBlue;
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Click    += new EventHandler(this.btnLogin_Click);

            // lblRegister
            this.lblRegister.Text     = "Don't have an account?";
            this.lblRegister.Font     = new Font("Segoe UI", 9F);
            this.lblRegister.Location = new Point(50, 270);
            this.lblRegister.Size     = new Size(160, 22);

            // btnRegister
            this.btnRegister.Text      = "Register";
            this.btnRegister.Font      = new Font("Segoe UI", 9F, FontStyle.Underline);
            this.btnRegister.Location  = new Point(210, 266);
            this.btnRegister.Size      = new Size(80, 26);
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.BackColor = Color.WhiteSmoke;
            this.btnRegister.ForeColor = Color.SteelBlue;
            this.btnRegister.Click    += new EventHandler(this.btnRegister_Click);

            this.Controls.AddRange(new Control[] {
                lblTitle, lblEmail, txtEmail,
                lblPassword, txtPassword,
                btnLogin, lblRegister, btnRegister
            });

            this.ResumeLayout(false);
        }

        private Label   lblTitle;
        private Label   lblEmail;
        private TextBox txtEmail;
        private Label   lblPassword;
        private TextBox txtPassword;
        private Button  btnLogin;
        private Label   lblRegister;
        private Button  btnRegister;
    }
}
