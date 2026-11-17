using EmployerEmployeeConnect.Controllers;
using EmployerEmployeeConnect.Models;

namespace EmployerEmployeeConnect.Views
{
    public partial class EmployeeProfileForm : Form
    {
        private readonly Employee           _employee;
        private readonly EmployeeController _ctrl = new();

        public EmployeeProfileForm(Employee employee)
        {
            _employee = employee;
            InitializeComponent();
        }

        private void EmployeeProfileForm_Load(object sender, EventArgs e)
        {
            txtSkills.Text     = _employee.Skills;
            txtExperience.Text = _employee.Experience;
            txtEducation.Text  = _employee.Education;
            txtResume.Text     = _employee.ResumeText;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _employee.Skills      = txtSkills.Text.Trim();
            _employee.Experience  = txtExperience.Text.Trim();
            _employee.Education   = txtEducation.Text.Trim();
            _employee.ResumeText  = txtResume.Text.Trim();

            try
            {
                bool ok = _ctrl.UpdateProfile(_employee);
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
