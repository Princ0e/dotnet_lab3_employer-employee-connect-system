-- ============================================
-- Employer & Employee Connect System
-- Database: employeeconnect
-- Run this in phpMyAdmin (XAMPP)
-- ============================================

CREATE DATABASE IF NOT EXISTS employeeconnect;
USE employeeconnect;

-- Users table (shared login for both roles)
CREATE TABLE IF NOT EXISTS Users (
    UserID      INT AUTO_INCREMENT PRIMARY KEY,
    FullName    VARCHAR(100) NOT NULL,
    Email       VARCHAR(100) NOT NULL UNIQUE,
    Password    VARCHAR(255) NOT NULL,
    Role        ENUM('Employer','Employee') NOT NULL,
    CreatedAt   DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Employer profiles
CREATE TABLE IF NOT EXISTS Employers (
    EmployerID   INT AUTO_INCREMENT PRIMARY KEY,
    UserID       INT NOT NULL,
    CompanyName  VARCHAR(150) NOT NULL,
    Industry     VARCHAR(100),
    Location     VARCHAR(150),
    Website      VARCHAR(200),
    Description  TEXT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);

-- Employee profiles
CREATE TABLE IF NOT EXISTS Employees (
    EmployeeID  INT AUTO_INCREMENT PRIMARY KEY,
    UserID      INT NOT NULL,
    Skills      TEXT,
    Experience  VARCHAR(100),
    Education   VARCHAR(150),
    ResumeText  TEXT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);

-- Job postings by employers
CREATE TABLE IF NOT EXISTS JobPosts (
    JobPostID   INT AUTO_INCREMENT PRIMARY KEY,
    EmployerID  INT NOT NULL,
    Title       VARCHAR(150) NOT NULL,
    Description TEXT,
    Location    VARCHAR(150),
    Salary      VARCHAR(80),
    JobType     ENUM('Full-Time','Part-Time','Contract','Internship') DEFAULT 'Full-Time',
    Status      ENUM('Open','Closed') DEFAULT 'Open',
    PostedAt    DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (EmployerID) REFERENCES Employers(EmployerID) ON DELETE CASCADE
);

-- Applications by employees
CREATE TABLE IF NOT EXISTS Applications (
    ApplicationID  INT AUTO_INCREMENT PRIMARY KEY,
    JobPostID      INT NOT NULL,
    EmployeeID     INT NOT NULL,
    CoverLetter    TEXT,
    Status         ENUM('Pending','Reviewed','Accepted','Rejected') DEFAULT 'Pending',
    AppliedAt      DATETIME DEFAULT CURRENT_TIMESTAMP,
    UNIQUE KEY uq_application (JobPostID, EmployeeID),
    FOREIGN KEY (JobPostID)  REFERENCES JobPosts(JobPostID)  ON DELETE CASCADE,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
);

-- ============================================
-- Sample seed data
-- ============================================

-- Passwords stored as plain text here for demo;
-- in production use bcrypt / SHA256.
INSERT INTO Users (FullName, Email, Password, Role) VALUES
('Alice Corp',      'alice@corp.com',   'alice123',   'Employer'),
('Bob Smith',       'bob@email.com',    'bob123',     'Employee'),
('TechHire Ltd',    'hr@techhire.com',  'tech123',    'Employer'),
('Carol Jones',     'carol@email.com',  'carol123',   'Employee');

INSERT INTO Employers (UserID, CompanyName, Industry, Location, Website) VALUES
(1, 'Alice Corp',   'Finance',    'New York',   'www.alicecorp.com'),
(3, 'TechHire Ltd', 'Technology', 'San Francisco', 'www.techhire.com');

INSERT INTO Employees (UserID, Skills, Experience, Education) VALUES
(2, 'C#, SQL, WinForms',    '2 years',  'BSc Computer Science'),
(4, 'Java, Python, React',  '4 years',  'BSc Software Engineering');

INSERT INTO JobPosts (EmployerID, Title, Description, Location, Salary, JobType) VALUES
(1, 'Junior .NET Developer',  'Build internal finance tools using C# and WinForms.', 'New York',      '$55,000/yr',  'Full-Time'),
(1, 'Database Administrator', 'Manage MySQL databases and optimize queries.',          'Remote',        '$60,000/yr',  'Full-Time'),
(2, 'Python Developer',       'Work on ML pipelines and data processing scripts.',     'San Francisco', '$85,000/yr',  'Full-Time'),
(2, 'Frontend Intern',        'Build React UIs for our recruitment platform.',         'Remote',        '$20/hr',      'Internship');
