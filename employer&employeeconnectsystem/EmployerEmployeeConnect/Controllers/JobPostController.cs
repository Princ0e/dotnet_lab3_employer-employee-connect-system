using EmployerEmployeeConnect.Database;
using EmployerEmployeeConnect.Models;
using MySql.Data.MySqlClient;

namespace EmployerEmployeeConnect.Controllers
{
    /// <summary>
    /// CRUD operations for Job Postings.
    /// </summary>
    public class JobPostController
    {
        // ── Create a new job post ──────────────────────────────────────
        public bool CreateJobPost(JobPost job)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"INSERT INTO JobPosts (EmployerID, Title, Description, Location, Salary, JobType, Status)
                                     VALUES (@eid, @title, @desc, @loc, @salary, @type, @status);";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eid",    job.EmployerID);
                cmd.Parameters.AddWithValue("@title",  job.Title);
                cmd.Parameters.AddWithValue("@desc",   job.Description);
                cmd.Parameters.AddWithValue("@loc",    job.Location);
                cmd.Parameters.AddWithValue("@salary", job.Salary);
                cmd.Parameters.AddWithValue("@type",   job.JobType);
                cmd.Parameters.AddWithValue("@status", job.Status);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not create job post: {ex.Message}", ex);
            }
        }

        // ── All open job posts (employee browse view) ──────────────────
        public List<JobPost> GetAllOpen()
        {
            try
            {
                var list = new List<JobPost>();
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT j.JobPostID, j.EmployerID, j.Title, j.Description,
                                            j.Location, j.Salary, j.JobType, j.Status, j.PostedAt,
                                            e.CompanyName
                                     FROM JobPosts j
                                     JOIN Employers e ON e.EmployerID = j.EmployerID
                                     WHERE j.Status = 'Open'
                                     ORDER BY j.PostedAt DESC;";
                using var cmd    = new MySqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(MapRow(reader));
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load job posts: {ex.Message}", ex);
            }
        }

        // ── All job posts by a specific employer ───────────────────────
        public List<JobPost> GetByEmployer(int employerID)
        {
            try
            {
                var list = new List<JobPost>();
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT j.JobPostID, j.EmployerID, j.Title, j.Description,
                                            j.Location, j.Salary, j.JobType, j.Status, j.PostedAt,
                                            e.CompanyName
                                     FROM JobPosts j
                                     JOIN Employers e ON e.EmployerID = j.EmployerID
                                     WHERE j.EmployerID = @eid
                                     ORDER BY j.PostedAt DESC;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eid", employerID);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(MapRow(reader));
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load job posts: {ex.Message}", ex);
            }
        }

        // ── Get a single job post by ID ────────────────────────────────
        public JobPost? GetByID(int jobPostID)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT j.JobPostID, j.EmployerID, j.Title, j.Description,
                                            j.Location, j.Salary, j.JobType, j.Status, j.PostedAt,
                                            e.CompanyName
                                     FROM JobPosts j
                                     JOIN Employers e ON e.EmployerID = j.EmployerID
                                     WHERE j.JobPostID = @jid LIMIT 1;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@jid", jobPostID);
                using var reader = cmd.ExecuteReader();
                if (!reader.Read()) return null;
                return MapRow(reader);
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not load job post: {ex.Message}", ex);
            }
        }

        // ── Update job post ────────────────────────────────────────────
        public bool UpdateJobPost(JobPost job)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"UPDATE JobPosts
                                     SET Title       = @title,
                                         Description = @desc,
                                         Location    = @loc,
                                         Salary      = @salary,
                                         JobType     = @type,
                                         Status      = @status
                                     WHERE JobPostID = @jid;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title",  job.Title);
                cmd.Parameters.AddWithValue("@desc",   job.Description);
                cmd.Parameters.AddWithValue("@loc",    job.Location);
                cmd.Parameters.AddWithValue("@salary", job.Salary);
                cmd.Parameters.AddWithValue("@type",   job.JobType);
                cmd.Parameters.AddWithValue("@status", job.Status);
                cmd.Parameters.AddWithValue("@jid",    job.JobPostID);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not update job post: {ex.Message}", ex);
            }
        }

        // ── Delete a job post ──────────────────────────────────────────
        public bool DeleteJobPost(int jobPostID)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = "DELETE FROM JobPosts WHERE JobPostID = @jid;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@jid", jobPostID);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Could not delete job post: {ex.Message}", ex);
            }
        }

        // ── Search open posts by keyword ───────────────────────────────
        public List<JobPost> Search(string keyword)
        {
            try
            {
                var list = new List<JobPost>();
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT j.JobPostID, j.EmployerID, j.Title, j.Description,
                                            j.Location, j.Salary, j.JobType, j.Status, j.PostedAt,
                                            e.CompanyName
                                     FROM JobPosts j
                                     JOIN Employers e ON e.EmployerID = j.EmployerID
                                     WHERE j.Status = 'Open'
                                       AND (j.Title LIKE @kw OR j.Description LIKE @kw
                                            OR e.CompanyName LIKE @kw OR j.Location LIKE @kw)
                                     ORDER BY j.PostedAt DESC;";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(MapRow(reader));
                return list;
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException($"Search failed: {ex.Message}", ex);
            }
        }

        // ── Private row mapper ─────────────────────────────────────────
        private static JobPost MapRow(MySqlDataReader r) => new JobPost
        {
            JobPostID   = r.GetInt32("JobPostID"),
            EmployerID  = r.GetInt32("EmployerID"),
            Title       = r.GetString("Title"),
            Description = r.IsDBNull(r.GetOrdinal("Description")) ? "" : r.GetString("Description"),
            Location    = r.IsDBNull(r.GetOrdinal("Location"))    ? "" : r.GetString("Location"),
            Salary      = r.IsDBNull(r.GetOrdinal("Salary"))      ? "" : r.GetString("Salary"),
            JobType     = r.GetString("JobType"),
            Status      = r.GetString("Status"),
            PostedAt    = r.GetDateTime("PostedAt"),
            CompanyName = r.GetString("CompanyName")
        };
    }
}
