using System.Threading.Tasks;
using CarRental.Models;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Helpers
{
    public static class IdentityExtensions
    {
        public static async Task<ApplicationUser> FindByNameOrEmailAsync
            (this UserManager<ApplicationUser> userManager, string usernameOrEmail)
        {
            if (usernameOrEmail.Contains("@"))
            {
                return await userManager.FindByEmailAsync(usernameOrEmail);
            }

            return await userManager.FindByNameAsync(usernameOrEmail);
        }
    }
}