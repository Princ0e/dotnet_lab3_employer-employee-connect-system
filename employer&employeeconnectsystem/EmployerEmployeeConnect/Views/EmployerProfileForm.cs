using EmployerEmployeeConnect.Controllers;
using EmployerEmployeeConnect.Models;

namespace EmployerEmployeeConnect.Views
{
    public partial class EmployerProfileForm : Form
    {
        private readonly Employer           _employer;
        private readonly EmployerController _ctrl = new();

        public EmployerProfileForm(Employer employer)
        {
            _employer = employer;
            InitializeComponent();
        }

        private void EmployerProfileForm_Load(object sender, EventArgs e)
        {
            txtCompany.Text     = _employer.CompanyName;
            txtIndustry.Text    = _employer.Industry;
            txtLocation.Text    = _employer.Location;
            txtWebsite.Text     = _employer.Website;
            txtDescription.Text = _employer.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompany.Text))
            {
                MessageBox.Show("Company name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _employer.CompanyName = txtCompany.Text.Trim();
            _employer.Industry    = txtIndustry.Text.Trim();
            _employer.Location    = txtLocation.Text.Trim();
            _employer.Website     = txtWebsite.Text.Trim();
            _employer.Description = txtDescription.Text.Trim();

            try
            {
                bool ok = _ctrl.UpdateProfile(_employer);
                MessageBox.Show(ok ? "Profile updated." : "Update failed.",
                    ok ? "Success" : "Error",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (ok) this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save profile:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}
