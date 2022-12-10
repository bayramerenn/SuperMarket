using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities.Models;

namespace SuperMarket.Business.InitializerData
{
    public class DbInitializer
    {
        public readonly UserManager<ApplicationUser> _userManager;

        public DbInitializer(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Ensure()
        {
            var existUser = await _userManager.Users.AnyAsync();

            if (!existUser)
            {
                ApplicationUser applicationUser = new()
                {
                    Email = "admin@gmail.com",
                    UserName = "admin",
                    FirstName = "Muhammed",
                    LastName = "Ilhan",
                    PhoneNumber = "05434562233"
                };

                await _userManager.CreateAsync(applicationUser, "Password12-*");
            }
        }
    }
}