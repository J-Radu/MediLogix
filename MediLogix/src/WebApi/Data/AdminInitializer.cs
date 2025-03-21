namespace MediLogix.WebApi.Data;

internal static class AdminInitializer
{
    internal static async Task InitializeAdminAccount(IServiceProvider serviceProvider, ILogger<Program> logger)
    {
        try
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                    logger.LogInformation("Rolul {Role} a fost creat cu succes.", role);
                }

            var adminEmail = "schiopu.radu7@gmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var password = "Admin123!";

                var result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                    logger.LogInformation("Contul de administrator cu email {Email} a fost creat cu succes.",
                        adminEmail);
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    logger.LogError("Nu s-a putut crea contul de administrator: {Errors}", errors);
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "A apărut o eroare la inițializarea contului de administrator.");
        }
    }
}