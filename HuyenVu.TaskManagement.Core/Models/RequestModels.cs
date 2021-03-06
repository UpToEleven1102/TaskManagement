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
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
        public string Password { get; set; }

        public string FullName { get; set; }

        public string MobileNo { get; set; }
    }
}