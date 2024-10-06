using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.IdentityEntities;

namespace Store.Repo
{
    public class StoreIdentitySeeding
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Yousef Ahmed",
                    Email = "yousef@gmail.com" ,
                    UserName = "Joe" ,
                    Address = new Address
                    {
                        FirstName = "Yousef",
                        LastName = "Ahmed",
                        City = "Giza",
                        State="Fesal",
                        Street = "8" ,
                        PostalCode = "43264"
                    }
                };
                await userManager.CreateAsync(user, "Pass0123");
            }
        }
    }
}
