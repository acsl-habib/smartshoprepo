using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SmartShop.DataApi.HostedServices
{
    public class IdentityDbInitializer
    {
        //private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public IdentityDbInitializer(/*ApplicationDbContext db,*/ UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task SeedAsync()
        {


            await CreateRoleAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            await CreateRoleAsync(new IdentityRole { Name = "Staff", NormalizedName = "STAFF" });
            await CreateRoleAsync(new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER" });

            var hasher = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser { UserName = "admin", NormalizedUserName = "ADMIN" };
            user.PasswordHash = hasher.HashPassword(user, "@Open1234");
            await CreateUserAsync(user, "Admin");
            

            user = new IdentityUser { UserName = "wada04", NormalizedUserName = "WADA04" };
            user.PasswordHash = hasher.HashPassword(user, "@Open1234");
            await CreateUserAsync(user, "Staff");
            
        }
        private async Task CreateRoleAsync(IdentityRole role)
        {
            var exits = await roleManager.RoleExistsAsync(role.Name);
            if (!exits)
                await roleManager.CreateAsync(role);
        }
        private async Task CreateUserAsync(IdentityUser user, string role)
        {
            var exists = await userManager.FindByNameAsync(user.UserName);
            if (exists == null)
            {               
                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, role);
            }
                
        }
    }
}