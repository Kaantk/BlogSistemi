using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Concrete.EntityFramework.SeedData
{
    public class IdentitySeed
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            // UserManager ve RoleManager servislerini al
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Roller
            var roles = new[] { "Admin", "Author", "User", "Guest" };

            // Rolleri oluştur
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Default kullanıcıları oluştur
            foreach (var role in roles)
            {
                var defaultUserEmail = $"{role.ToLower()}@gmail.com";
                var getUser = await userManager.FindByEmailAsync(defaultUserEmail);
                
                // Kullanıcıyı oluştur
                if (getUser == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = role.ToLower(),
                        Email = defaultUserEmail,
                        NormalizedEmail = defaultUserEmail.ToLower(),
                        EmailConfirmed = true,
                        IsDeleted = false,
                        Status = true,
                        CreatedDate = DateTime.Now,
                    };

                    // Parola ve rol atama
                    var createUserResult = await userManager.CreateAsync(user, $"{role}123!");

                    // Kullanıcı başarıyla oluşturulduysa rolünü ata
                    if (createUserResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }

            }

            // Varsayılan admin kullanıcısı
            var defaultAdminEmail = "admin@gmail.com";
            var getAdminUser = await userManager.FindByEmailAsync(defaultAdminEmail);

            // Admin kullanıcısını oluştur
            if (getAdminUser == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = defaultAdminEmail,
                    EmailConfirmed = true
                };

                // Parola ve rol atama
                var createAdminResult = await userManager.CreateAsync(adminUser, "Admin123!");

                // Kullanıcı başarıyla oluşturulduysa Admin rolünü ata
                if (createAdminResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

        }
    }
}
