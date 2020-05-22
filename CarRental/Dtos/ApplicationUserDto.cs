using System.ComponentModel.DataAnnotations;

namespace CarRental.Dtos
{
    public class RegisterUserDto : LoginUserDto
    {
         
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

         
        public string UserRole { get; set; }
        public string CurrentToken { get; set; }
    }

    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}