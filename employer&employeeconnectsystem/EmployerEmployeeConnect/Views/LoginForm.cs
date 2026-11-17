using EmployerEmployeeConnect.Controllers;
using EmployerEmployeeConnect.Models;

namespace EmployerEmployeeConnect.Views
{
    public partial class LoginForm : Form
    {
        private readonly UserController _userController = new();

        public LoginForm()
        {
            InitializeComponent();
        }

        // ── Login button ───────────────────────────────────────────────
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email    = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User? user = _userController.Login(email, password);
                if (user == null)
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Open the correct dashboard, then close this form.
                // OnDashboardClosed calls Application.Exit() when the user
                // closes the window; the Logout button detaches it first.
                if (user.Role == "Employer")
                {
                    var dash = new EmployerDashboardForm(user);
                    dash.FormClosed += dash.OnDashboardClosed;
                    dash.Show();
                }
                else
                {
                    var dash = new EmployeeDashboardForm(user);
                    dash.FormClosed += dash.OnDashboardClosed;
                    dash.Show();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Register link ──────────────────────────────────────────────
        private void btnRegister_Click(object sender, EventArgs e)
        {
            var form = new RegisterForm();
            form.FormClosed += (s, args) => this.Show();
            form.Show();
            this.Hide();
        }
    }
}
