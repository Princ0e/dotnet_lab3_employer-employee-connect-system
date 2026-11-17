using EmployerEmployeeConnect.Database;
using EmployerEmployeeConnect.Models;
using MySql.Data.MySqlClient;

namespace EmployerEmployeeConnect.Controllers
{
    /// <summary>
    /// Handles job applications — submitting, listing, and status updates.
    /// </summary>
    public class ApplicationController
    {
        // ── Submit a new application ───────────────────────────────────
        public bool Apply(int jobPostID, int employeeID, string coverLetter)
        {
            try
            {
                // Prevent duplicate applications
                if (HasApplied(jobPostID, employeeID))
                    return false;

                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"INSERT INTO Applications (JobPostID, EmployeeID, CoverLetter, Status)
                                     VALUES (@jid, @eid, @cover, 'Pending');";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@jid",   jobPostID);
                cmd.Parameters.AddWithValue("@eid",   employeeID);
                cmd.Parameters.AddWithValue("@cover", coverLetter);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not submit application: {ex.Message}", ex);
            }
        }

        // ── Check whether an employee already applied for a job ────────
        public bool HasApplied(int jobPostID, int employeeID)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT COUNT(*) FROM Applications
                                     WHERE JobPostID = @jid AND EmployeeID = @eid;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@jid", jobPostID);
                cmd.Parameters.AddWithValue("@eid", employeeID);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not check application status: {ex.Message}", ex);
            }
        }

        // ── All applications submitted by one employee ─────────────────
        public List<Models.Application> GetByEmployee(int employeeID)
        {
            try
            {
                var list = new List<Models.Application>();
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT a.ApplicationID, a.JobPostID, a.EmployeeID,
                                            a.CoverLetter, a.Status, a.AppliedAt,
                                            j.Title AS JobTitle, e.CompanyName,
                                            u.FullName AS ApplicantName, u.Email AS ApplicantEmail
                                     FROM Applications a
                                     JOIN JobPosts  j   ON j.JobPostID    = a.JobPostID
                                     JOIN Employers e   ON e.EmployerID   = j.EmployerID
                                     JOIN Employees emp ON emp.EmployeeID = a.EmployeeID
                                     JOIN Users     u   ON u.UserID       = emp.UserID
                                     WHERE a.EmployeeID = @eid
                                     ORDER BY a.AppliedAt DESC;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eid", employeeID);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(MapRow(reader));
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load applications: {ex.Message}", ex);
            }
        }

        // ── All applications received for a specific job post ──────────
        public List<Models.Application> GetByJobPost(int jobPostID)
        {
            try
            {
                var list = new List<Models.Application>();
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT a.ApplicationID, a.JobPostID, a.EmployeeID,
                                            a.CoverLetter, a.Status, a.AppliedAt,
                                            j.Title AS JobTitle, e.CompanyName,
                                            u.FullName AS ApplicantName, u.Email AS ApplicantEmail
                                     FROM Applications a
                                     JOIN JobPosts  j   ON j.JobPostID    = a.JobPostID
                                     JOIN Employers e   ON e.EmployerID   = j.EmployerID
                                     JOIN Employees emp ON emp.EmployeeID = a.EmployeeID
                                     JOIN Users     u   ON u.UserID       = emp.UserID
                                     WHERE a.JobPostID = @jid
                                     ORDER BY a.AppliedAt DESC;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@jid", jobPostID);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(MapRow(reader));
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load applications: {ex.Message}", ex);
            }
        }

        // ── All applications across all jobs for one employer ──────────
        public List<Models.Application> GetByEmployer(int employerID)
        {
            try
            {
                var list = new List<Models.Application>();
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT a.ApplicationID, a.JobPostID, a.EmployeeID,
                                            a.CoverLetter, a.Status, a.AppliedAt,
                                            j.Title AS JobTitle, e.CompanyName,
                                            u.FullName AS ApplicantName, u.Email AS ApplicantEmail
                                     FROM Applications a
                                     JOIN JobPosts  j   ON j.JobPostID    = a.JobPostID
                                     JOIN Employers e   ON e.EmployerID   = j.EmployerID
                                     JOIN Employees emp ON emp.EmployeeID = a.EmployeeID
                                     JOIN Users     u   ON u.UserID       = emp.UserID
                                     WHERE e.EmployerID = @eid
                                     ORDER BY a.AppliedAt DESC;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eid", employerID);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(MapRow(reader));
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load applications: {ex.Message}", ex);
            }
        }

        // ── Update application status (Employer action) ────────────────
        public bool UpdateStatus(int applicationID, string status)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"UPDATE Applications SET Status = @status
                                     WHERE ApplicationID = @aid;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@aid",    applicationID);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not update application status: {ex.Message}", ex);
            }
        }

        // ── Withdraw an application (Employee action) ──────────────────
        public bool Withdraw(int applicationID)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = "DELETE FROM Applications WHERE ApplicationID = @aid;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@aid", applicationID);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not withdraw application: {ex.Message}", ex);
            }
        }

        // ── Private row mapper ─────────────────────────────────────────
        private static Models.Application MapRow(MySqlDataReader r) => new Models.Application
        {
            ApplicationID  = r.GetInt32("ApplicationID"),
            JobPostID      = r.GetInt32("JobPostID"),
            EmployeeID     = r.GetInt32("EmployeeID"),
            CoverLetter    = r.IsDBNull(r.GetOrdinal("CoverLetter")) ? "" : r.GetString("CoverLetter"),
            Status         = r.GetString("Status"),
            AppliedAt      = r.GetDateTime("AppliedAt"),
            JobTitle       = r.GetString("JobTitle"),
            CompanyName    = r.GetString("CompanyName"),
            ApplicantName  = r.GetString("ApplicantName"),
            ApplicantEmail = r.GetString("ApplicantEmail")
        };
    }
}
