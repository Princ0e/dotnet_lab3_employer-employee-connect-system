using EmployerEmployeeConnect.Controllers;
using EmployerEmployeeConnect.Models;
using System.Text.RegularExpressions;

namespace EmployerEmployeeConnect.Views
{
    public partial class RegisterForm : Form
    {
        private readonly UserController     _userCtrl     = new();
        private readonly EmployerController _employerCtrl = new();
        private readonly EmployeeController _employeeCtrl = new();

        public RegisterForm()
        {
            InitializeComponent();
        }

        // ── Register button ────────────────────────────────────────────
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email    = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm  = txtConfirm.Text.Trim();
            string role     = cmbRole.SelectedItem?.ToString() ?? "";

            // ── Basic field validation ─────────────────────────────────
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_userCtrl.EmailExists(email))
                {
                    MessageBox.Show("An account with that email already exists.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create user
                int userID = _userCtrl.Register(fullName, email, password, role);
                if (userID <= 0)
                {
                    MessageBox.Show("Registration failed. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create matching profile row
                if (role == "Employer")
                {
                    _employerCtrl.CreateProfile(new Employer
                    {
                        UserID      = userID,
                        CompanyName = txtCompany.Text.Trim().Length > 0 ? txtCompany.Text.Trim() : fullName
                    });
                }
                else
                {
                    _employeeCtrl.CreateProfile(new Employee { UserID = userID });
                }

                MessageBox.Show("Registration successful! You can now log in.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Email format check ─────────────────────────────────────────
        private static bool IsValidEmail(string email)
        {
            // Simple RFC-5322-ish check: local@domain.tld
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }

        // ── Show/hide company field based on role selection ────────────
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isEmployer = cmbRole.SelectedItem?.ToString() == "Employer";
            lblCompany.Visible = isEmployer;
            txtCompany.Visible = isEmployer;
        }

        private void btnBack_Click(object sender, EventArgs e) => this.Close();
    }
}
