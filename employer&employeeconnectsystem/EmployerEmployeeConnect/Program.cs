using EmployerEmployeeConnect.Database;
using EmployerEmployeeConnect.Views;

namespace EmployerEmployeeConnect
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Verify DB connection before showing any UI
            if (!DatabaseHelper.TestConnection(out string error))
            {
                MessageBox.Show(
                    $"Cannot connect to the database.\n\n" +
                    $"Make sure XAMPP MySQL is running and the database 'employeeconnect' exists.\n\n" +
                    $"Error: {error}",
                    "Database Connection Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Use a plain ApplicationContext so the message loop is NOT tied to
            // LoginForm's lifetime. The app stays alive until Application.Exit()
            // is called explicitly (from the dashboard's OnDashboardClosed hook).
            var ctx = new ApplicationContext();
            var login = new LoginForm();
            login.Show();
            Application.Run(ctx);
        }
    }
}
