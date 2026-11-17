using EmployerEmployeeConnect.Database;
using EmployerEmployeeConnect.Models;
using MySql.Data.MySqlClient;

namespace EmployerEmployeeConnect.Controllers
{
    /// <summary>
    /// CRUD operations for Employer profiles.
    /// </summary>
    public class EmployerController
    {
        // ── Create a new employer profile ──────────────────────────────
        public bool CreateProfile(Employer employer)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"INSERT INTO Employers (UserID, CompanyName, Industry, Location, Website, Description)
                                     VALUES (@uid, @company, @industry, @location, @website, @desc);";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid",      employer.UserID);
                cmd.Parameters.AddWithValue("@company",  employer.CompanyName);
                cmd.Parameters.AddWithValue("@industry", employer.Industry);
                cmd.Parameters.AddWithValue("@location", employer.Location);
                cmd.Parameters.AddWithValue("@website",  employer.Website);
                cmd.Parameters.AddWithValue("@desc",     employer.Description);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not create employer profile: {ex.Message}", ex);
            }
        }

        // ── Get employer profile by UserID ─────────────────────────────
        public Employer? GetByUserID(int userID)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT e.EmployerID, e.UserID, e.CompanyName, e.Industry,
                                            e.Location, e.Website, e.Description,
                                            u.FullName, u.Email
                                     FROM Employers e
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
                throw new ApplicationException($"Could not load employer profile: {ex.Message}", ex);
            }
        }

        // ── Get employer profile by EmployerID ─────────────────────────
        public Employer? GetByEmployerID(int employerID)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT e.EmployerID, e.UserID, e.CompanyName, e.Industry,
                                            e.Location, e.Website, e.Description,
                                            u.FullName, u.Email
                                     FROM Employers e
                                     JOIN Users u ON u.UserID = e.UserID
                                     WHERE e.EmployerID = @eid LIMIT 1;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eid", employerID);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;
                return MapRow(reader);
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load employer profile: {ex.Message}", ex);
            }
        }

        // ── List all employers ─────────────────────────────────────────
        public List<Employer> GetAll()
        {
            try
            {
                var list = new List<Employer>();
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT e.EmployerID, e.UserID, e.CompanyName, e.Industry,
                                            e.Location, e.Website, e.Description,
                                            u.FullName, u.Email
                                     FROM Employers e
                                     JOIN Users u ON u.UserID = e.UserID
                                     ORDER BY e.CompanyName;";
                using var cmd    = new MySqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(MapRow(reader));
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load employers: {ex.Message}", ex);
            }
        }

        // ── Update employer profile ────────────────────────────────────
        public bool UpdateProfile(Employer employer)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"UPDATE Employers
                                     SET CompanyName = @company,
                                         Industry    = @industry,
                                         Location    = @location,
                                         Website     = @website,
                                         Description = @desc
                                     WHERE EmployerID = @eid;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@company",  employer.CompanyName);
                cmd.Parameters.AddWithValue("@industry", employer.Industry);
                cmd.Parameters.AddWithValue("@location", employer.Location);
                cmd.Parameters.AddWithValue("@website",  employer.Website);
                cmd.Parameters.AddWithValue("@desc",     employer.Description);
                cmd.Parameters.AddWithValue("@eid",      employer.EmployerID);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not update employer profile: {ex.Message}", ex);
            }
        }

        // ── Private row mapper ─────────────────────────────────────────
        private static Employer MapRow(MySqlDataReader r) => new Employer
        {
            EmployerID  = r.GetInt32("EmployerID"),
            UserID      = r.GetInt32("UserID"),
            CompanyName = r.GetString("CompanyName"),
            Industry    = r.IsDBNull(r.GetOrdinal("Industry"))    ? "" : r.GetString("Industry"),
            Location    = r.IsDBNull(r.GetOrdinal("Location"))    ? "" : r.GetString("Location"),
            Website     = r.IsDBNull(r.GetOrdinal("Website"))     ? "" : r.GetString("Website"),
            Description = r.IsDBNull(r.GetOrdinal("Description")) ? "" : r.GetString("Description"),
            FullName    = r.GetString("FullName"),
            Email       = r.GetString("Email")
        };
    }
}
