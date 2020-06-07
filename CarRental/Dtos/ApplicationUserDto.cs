using System.ComponentModel.DataAnnotations;

namespace CarRental.Dtos
{
    public class RegisterUserDto : LoginUserDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }
        [Required]
        public int BranchId { get; set; }
        public string CurrentToken { get; set; }
        public string BranchName { get; set; }
    }

    public class LoginUserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}