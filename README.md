Employer & Employee Connect System
A Windows Forms desktop application that connects employers with employees through job postings and applications. Built with C# and MySQL following the MVC (Model-View-Controller) architecture pattern.

Features
For Employers
Post Jobs — Create and manage job postings with details like title, description, location, salary, and job type
Edit & Delete Jobs — Update existing job posts or remove them
View Applications — Review all applications received across all jobs or filter by specific job
Manage Applications — Update application status (Pending, Reviewed, Accepted, Rejected)
Company Profile — Maintain company information including name, industry, location, and website
For Employees
Browse Jobs — View all open job postings from employers
Search Jobs — Find jobs by keyword (searches title, description, company name, location)
Apply for Jobs — Submit applications with cover letters
Track Applications — View all submitted applications with color-coded status indicators
Withdraw Applications — Remove applications before they're processed
Employee Profile — Manage skills, experience, education, and resume
Shared Features
User Authentication — Secure registration and login system with email validation
Role-Based Dashboards — Different interfaces for employers and employees
Real-Time Updates — Application status changes reflect immediately
Technology Stack
Frontend: Windows Forms (.NET 6.0)
Backend: C# with MVC Architecture
Database: MySQL (via XAMPP)
ORM: ADO.NET with MySql.Data
Pattern: Model-View-Controller (MVC)
Project Structure

EmployerEmployeeConnect/
├── Controllers/          # Business logic and database operations
│   ├── UserController.cs
│   ├── EmployeeController.cs
│   ├── EmployerController.cs
│   ├── JobPostController.cs
│   └── ApplicationController.cs
├── Models/              # Data models
│   ├── User.cs
│   ├── Employee.cs
│   ├── Employer.cs
│   ├── JobPost.cs
│   └── Application.cs
├── Views/               # UI Forms
│   ├── LoginForm.cs
│   ├── RegisterForm.cs
│   ├── EmployeeDashboardForm.cs
│   ├── EmployerDashboardForm.cs
│   └── [Other Forms...]
├── Database/            # Database connection helper
│   └── DatabaseHelper.cs
└── SQL/
    └── employeeconnect.sql  # Database schema and seed data
Database Schema
Users — User accounts with role-based access (Employer/Employee)
Employers — Employer profiles with company information
Employees — Employee profiles with skills and experience
JobPosts — Job postings created by employers
Applications — Job applications submitted by employees
All tables include proper foreign key relationships with cascading deletes.

Prerequisites
.NET 6.0 SDK or later
Visual Studio 2022 (Community Edition or higher)
XAMPP (for MySQL database)
Installation & Setup
1. Clone the Repository
bash

git clone https://github.com/yourusername/employer-employee-connect.git
cd employer-employee-connect
2. Set Up the Database
Start XAMPP Control Panel
Start Apache and MySQL services
Open phpMyAdmin at http://localhost/phpmyadmin
Click Import tab
Choose file: 
employeeconnect.sql
Click Import button
Verify the employeeconnect database was created with 5 tables
3. Configure Database Connection (if needed)
If you have a MySQL password set, update the connection string in:

File: 
DatabaseHelper.cs

csharp

private const string ConnectionString =
    "Server=localhost;Port=3306;Database=employeeconnect;Uid=root;Pwd=YOUR_PASSWORD;";
4. Build and Run
Open EmployerEmployeeConnect.sln in Visual Studio
Press F5 or click Start
The application will launch after a successful build
Usage
First-Time Setup
The database comes with sample seed data for testing:

Employer Accounts:

Email: alice@corp.com | Password: alice123
Email: hr@techhire.com | Password: tech123
Employee Accounts:

Email: bob@email.com | Password: bob123
Email: carol@email.com | Password: carol123
Creating a New Account
Click Register on the login screen
Fill in all required fields:
Full Name
Email (must be valid format)
Password (minimum 6 characters)
Confirm Password
Select Role: Employer or Employee
If Employer: Enter Company Name (optional)
Click Register
You can now log in with your credentials
As an Employer
Post a Job:

Click Post New Job
Enter job title, description, location, salary
Select job type (Full-Time, Part-Time, Contract, Internship)
Select status (Open/Closed)
Click Save
Manage Applications:

Click All Applications to view all applications across all jobs
Or select a job and click View Applicants for that specific job
Click View Cover Letter to read the applicant's message
Update status using the dropdown: Pending → Reviewed → Accepted/Rejected
Edit Profile:

Click Edit Profile
Update company information
Click Save
As an Employee
Browse & Search Jobs:

All open jobs appear on the dashboard
Use the search box to filter by keyword
Click View Details to see full job information
Apply for a Job:

Select a job from the list
Click Apply
Write a cover letter (optional)
Click Submit
Track Applications:

Click My Applications
Status colors:
🟢 Green = Accepted
🔴 Red = Rejected
🟠 Orange = Reviewed
⚫ Black = Pending
Click Withdraw to cancel an application
Edit Profile:

Click Edit Profile
Update skills, experience, education, resume
Click Save
Architecture
This project follows the MVC (Model-View-Controller) design pattern:

Models
Plain C# classes (POCOs) representing database entities. No business logic.

Controllers
Handle all business logic and database operations:

Parameterized SQL queries (prevents SQL injection)
Error handling with user-friendly exception messages
Data validation before database operations
Views
Windows Forms that handle user interaction:

Event-driven UI with button click handlers
Data binding to DataGridView for lists
Form lifecycle management (login → dashboard → logout)
Key Design Decisions
✅ Separation of Concerns — Each layer has a single responsibility ✅ Error Handling — All database operations wrapped in try/catch ✅ Input Validation — Email format, password length, required fields ✅ Database Integrity — Foreign keys, unique constraints, cascading deletes ✅ User Experience — Real-time validation, color-coded statuses, clear error messages

Security Considerations
⚠️ Important: This is an educational project. For production use, implement:

Password Hashing — Currently stores plain text passwords (use BCrypt or Argon2)
SQL Injection Prevention — Already implemented via parameterized queries ✓
Input Sanitization — Basic validation exists; add length limits for production
Session Management — Implement proper authentication tokens
HTTPS — Not applicable for desktop apps, but secure the database connection
Role-Based Access Control — Basic role system exists; expand for granular permissions
Known Limitations
Passwords stored in plain text (demo only)
No pagination for large datasets
Salary stored as text (can't sort by amount)
No password reset functionality
No email notifications for application status changes
No file upload for resumes (text field only)
Future Enhancements
 Add password hashing (BCrypt.Net-Next)
 Implement resume file upload
 Add email notifications
 Create admin dashboard
 Add data export (CSV/PDF)
 Implement advanced search filters
 Add pagination for job listings
 Real-time chat between employer and applicant
 Dashboard analytics (application metrics)
License
This project is created for educational purposes as part of a university lab assignment.

Author
RUKESHA Prince

Acknowledgments
Built as part of Lab 3 assignment
MySQL database management via XAMPP
Windows Forms UI framework by Microsoft
