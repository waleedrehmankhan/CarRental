using CarRental.Helpers;

namespace CarRental.Persistence.Repositories.Branch
{
    public class GetBranchInput : PagedAndSortedInputDto
    {
        public int Id { get; set; }
    }
}