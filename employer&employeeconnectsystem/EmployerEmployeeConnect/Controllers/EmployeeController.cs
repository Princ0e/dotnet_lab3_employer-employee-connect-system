using EmployerEmployeeConnect.Database;
using EmployerEmployeeConnect.Models;
using MySql.Data.MySqlClient;

namespace EmployerEmployeeConnect.Controllers
{
    /// <summary>
    /// CRUD operations for Employee profiles.
    /// </summary>
    public class EmployeeController
    {
        // ── Create a new employee profile ──────────────────────────────
        public bool CreateProfile(Employee employee)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"INSERT INTO Employees (UserID, Skills, Experience, Education, ResumeText)
                                     VALUES (@uid, @skills, @exp, @edu, @resume);";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid",    employee.UserID);
                cmd.Parameters.AddWithValue("@skills", employee.Skills);
                cmd.Parameters.AddWithValue("@exp",    employee.Experience);
                cmd.Parameters.AddWithValue("@edu",    employee.Education);
                cmd.Parameters.AddWithValue("@resume", employee.ResumeText);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not create employee profile: {ex.Message}", ex);
            }
        }

        // ── Get employee profile by UserID ─────────────────────────────
        public Employee? GetByUserID(int userID)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT e.EmployeeID, e.UserID, e.Skills, e.Experience,
                                            e.Education, e.ResumeText,
                                            u.FullName, u.Email
                                     FROM Employees e
                                     JOIN Users u ON u.UserID = e.UserID
                                     WHERE e.UserID = @uid LIMIT 1;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid", userID);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;
                return MapRow(reader);
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load employee profile: {ex.Message}", ex);
            }
        }

        // ── Get employee profile by EmployeeID ─────────────────────────
        public Employee? GetByEmployeeID(int employeeID)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT e.EmployeeID, e.UserID, e.Skills, e.Experience,
                                            e.Education, e.ResumeText,
                                            u.FullName, u.Email
                                     FROM Employees e
                                     JOIN Users u ON u.UserID = e.UserID
                                     WHERE e.EmployeeID = @eid LIMIT 1;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eid", employeeID);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;
                return MapRow(reader);
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load employee profile: {ex.Message}", ex);
            }
        }

        // ── List all employees ─────────────────────────────────────────
        public List<Employee> GetAll()
        {
            try
            {
                var list = new List<Employee>();
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT e.EmployeeID, e.UserID, e.Skills, e.Experience,
                                            e.Education, e.ResumeText,
                                            u.FullName, u.Email
                                     FROM Employees e
                                     JOIN Users u ON u.UserID = e.UserID
                                     ORDER BY u.FullName;";
                using var cmd    = new MySqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(MapRow(reader));
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load employees: {ex.Message}", ex);
            }
        }

        // ── Update employee profile ────────────────────────────────────
        public bool UpdateProfile(Employee employee)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"UPDATE Employees
                                     SET Skills     = @skills,
                                         Experience = @exp,
                                         Education  = @edu,
                                         ResumeText = @resume
                                     WHERE EmployeeID = @eid;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@skills", employee.Skills);
                cmd.Parameters.AddWithValue("@exp",    employee.Experience);
                cmd.Parameters.AddWithValue("@edu",    employee.Education);
                cmd.Parameters.AddWithValue("@resume", employee.ResumeText);
                cmd.Parameters.AddWithValue("@eid",    employee.EmployeeID);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not update employee profile: {ex.Message}", ex);
            }
        }

        // ── Private row mapper ─────────────────────────────────────────
        private static Employee MapRow(MySqlDataReader r) => new Employee
        {
            EmployeeID = r.GetInt32("EmployeeID"),
            UserID     = r.GetInt32("UserID"),
            Skills     = r.IsDBNull(r.GetOrdinal("Skills"))     ? "" : r.GetString("Skills"),
            Experience = r.IsDBNull(r.GetOrdinal("Experience")) ? "" : r.GetString("Experience"),
            Education  = r.IsDBNull(r.GetOrdinal("Education"))  ? "" : r.GetString("Education"),
            ResumeText = r.IsDBNull(r.GetOrdinal("ResumeText")) ? "" : r.GetString("ResumeText"),
            FullName   = r.GetString("FullName"),
            Email      = r.GetString("Email")
        };
    }
}
