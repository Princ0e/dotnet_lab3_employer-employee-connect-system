using EmployerEmployeeConnect.Database;
using EmployerEmployeeConnect.Models;
using MySql.Data.MySqlClient;

namespace EmployerEmployeeConnect.Controllers
{
    /// <summary>
    /// Handles registration, login, and user lookups.
    /// </summary>
    public class UserController
    {
        // ── Register a new user (returns new UserID or -1 on failure) ──
        public int Register(string fullName, string email, string password, string role)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"INSERT INTO Users (FullName, Email, Password, Role)
                                     VALUES (@name, @email, @pwd, @role);
                                     SELECT LAST_INSERT_ID();";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name",  fullName);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pwd",   password);
                cmd.Parameters.AddWithValue("@role",  role);

                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Registration failed: {ex.Message}", ex);
            }
        }

        // ── Login — returns User object or null if credentials invalid ──
        public User? Login(string email, string password)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT UserID, FullName, Email, Password, Role, CreatedAt
                                     FROM Users
                                     WHERE Email = @email AND Password = @pwd
                                     LIMIT 1;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pwd",   password);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;

                return new User
                {
                    UserID    = reader.GetInt32("UserID"),
                    FullName  = reader.GetString("FullName"),
                    Email     = reader.GetString("Email"),
                    Password  = reader.GetString("Password"),
                    Role      = reader.GetString("Role"),
                    CreatedAt = reader.GetDateTime("CreatedAt")
                };
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Login failed: {ex.Message}", ex);
            }
        }

        // ── Check whether an email is already registered ──
        public bool EmailExists(string email)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = "SELECT COUNT(*) FROM Users WHERE Email = @email;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@email", email);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Email check failed: {ex.Message}", ex);
            }
        }

        // ── Fetch a single user by ID ──
        public User? GetByID(int userID)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT UserID, FullName, Email, Password, Role, CreatedAt
                                     FROM Users WHERE UserID = @id LIMIT 1;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", userID);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;

                return new User
                {
                    UserID    = reader.GetInt32("UserID"),
                    FullName  = reader.GetString("FullName"),
                    Email     = reader.GetString("Email"),
                    Password  = reader.GetString("Password"),
                    Role      = reader.GetString("Role"),
                    CreatedAt = reader.GetDateTime("CreatedAt")
                };
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"User lookup failed: {ex.Message}", ex);
            }
        }
    }
}
