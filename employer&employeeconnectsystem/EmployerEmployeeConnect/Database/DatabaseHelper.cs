using MySql.Data.MySqlClient;

namespace EmployerEmployeeConnect.Database
{
    /// <summary>
    /// Central place for all database access.
    /// Change the connection string here if your XAMPP
    /// MySQL port or credentials differ.
    /// </summary>
    public static class DatabaseHelper
    {
        // ── Connection string ──────────────────────────────────────────
        // Default XAMPP MySQL: host=localhost, port=3306, user=root, no password.
        // Change Password= if you set one in phpMyAdmin.
        private const string ConnectionString =
            "Server=localhost;Port=3306;Database=employeeconnect;Uid=root;Pwd=;";

        // ── Open a fresh connection ────────────────────────────────────
        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        // ── Verify the DB is reachable at startup ──────────────────────
        public static bool TestConnection(out string errorMessage)
        {
            try
            {
                using var conn = GetConnection();
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
