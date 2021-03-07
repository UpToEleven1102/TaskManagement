using System;
using System.ComponentModel.DataAnnotations;

namespace HuyenVu.TaskManagement.Core.Models
{
    public class UserRequestModel
    {
        public int? Id { get; set; }

        [Required] 
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters and maximum of 10 characters long", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
        public string Password { get; set; }

        public string FullName { get; set; }

        public string MobileNo { get; set; }
    }
    
    public class UserUpdateRequestModel
    {
        public int Id { get; set; }

        [Required] 
        [EmailAddress] 
        public string Email { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters and maximum of 10 characters long", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
        public string Password { get; set; }
        
        public string FullName { get; set; }

        public string MobileNo { get; set; }
    }

    public class TaskRequestModel
    {
        public int Id { get; set; }
        
        public int? UserId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public DateTime? DueDate { get; set; }
        
        public char? Priority { get; set; }
        
        public string Remarks { get; set; }
    }

    public class TaskHistoryRequestModel
    {
        public int TaskId { get; set; }
        
        public int? UserId { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime? DueDate { get; set; }

        public DateTime? Completed { get; set; }
        
        public string Remarks { get; set; }
    }
}