namespace Backend.Models
{
 public class User
    {
        public int UserId { get; set; } // Unique identifier for the user (Primary Key)
        
        // Personal Information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; } // URL or path to profile picture
        
        // Employment Information
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string EmploymentType { get; set; } // Full-time, Part-time, etc.
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Status { get; set; } // Active, On Leave, Retired
        
        // Academic/Qualification Information
        public string Qualifications { get; set; }
        public string Institution { get; set; }
        public string Specialization { get; set; }
        
        // Work Schedule
        public int WorkHoursPerWeek { get; set; }
        public string WorkSchedule { get; set; } // Morning, Evening, etc.
        public string DaysOff { get; set; } // Days off in the week
        
        // Emergency Contact
        public string EmergencyContactName { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string EmergencyContactPhone { get; set; }

        // Leave and Attendance Information
        public int LeaveBalance { get; set; }
        public string LeaveType { get; set; } // Sick Leave, Annual Leave, etc.
        
        // Security and Permissions
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store a hashed password
        public string Role { get; set; } // Admin, Teacher, Staff, etc.

        // Subjects Taught (if applicable)
        public string[] SubjectsTaught { get; set; }

        // School/Work Location
        public string WorkLocation { get; set; }

        // Employee Reviews
        public string PerformanceReview { get; set; }
        
        // Training and Certifications
        public string[] TrainingCourses { get; set; }
    }
}
