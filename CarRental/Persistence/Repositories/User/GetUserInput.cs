using CarRental.Helpers;

namespace CarRental.Persistence.Repositories.User
{
    public class GetUserInput : PagedAndSortedInputDto
    {
        public string Email { get; set; }
    }
}