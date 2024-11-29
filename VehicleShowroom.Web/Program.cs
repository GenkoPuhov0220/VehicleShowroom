using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data;
using VehicleShowroom.Services.Data.Interfaces;
using VehicleShowroom.Web;


namespace VehicleShowroom.Web
{
    public class Program
    {
        public static  async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<VehicleDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole>(options =>
                {

                    ConfigureIdentity(builder, options);
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<VehicleDbContext>()
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddUserManager<UserManager<ApplicationUser>>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
            });

            //Add Services
            builder.Services.AddScoped<IVehicleServices, VehicleServices>();
            builder.Services.AddScoped<ICarServices, CarServices>();
            builder.Services.AddScoped<IBusServices, BusServices>();
            builder.Services.AddScoped<ISuperCarServices, SuperCarServices>();
            builder.Services.AddScoped<IMotorcycleServices, MotorcycleServices>();
            builder.Services.AddScoped<ITruckServices , TruckServices>();
            builder.Services.AddScoped<IFavoritesVehicleServices, FavoritesServices>();


            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
           {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStatusCodePagesWithRedirects("/StatusCodeError/{0}");

          // app.MapControllerRoute(
            //  name: "Errors",
              // pattern: "{controller=Home}/{action=Index}/{statusCode}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "Admin", "User" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider
                    .GetRequiredService<UserManager<ApplicationUser>>();

                string email = "admin@admin.com";
                string password = "admin123";

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new ApplicationUser();
                    user.UserName = email;
                    user.Email = email;

                   await userManager.CreateAsync(user, password);

                   await userManager.AddToRoleAsync(user, "Admin");
                }
            }



            app.Run();
        }
        private static void ConfigureIdentity(WebApplicationBuilder builder,IdentityOptions options)
        {   //Password
            options.Password.RequireDigit =
                          builder.Configuration.GetValue<bool>("Identity:Password:RequireDigits");
            options.Password.RequireLowercase =
                   builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
            options.Password.RequireUppercase =
                   builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
            options.Password.RequireNonAlphanumeric =
                   builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumerical");
            options.Password.RequiredLength =
                   builder.Configuration.GetValue<int>("Identity:Password:RequireLenght");
            options.Password.RequiredUniqueChars =
                   builder.Configuration.GetValue<int>("Identity:Password:RequiredUniqueCharacters");
            //SignIn
           options.SignIn.RequireConfirmedAccount =
                   builder.Configuration.GetValue<bool>("Identity:SingIn:RequireConfirmedAccount");
            options.SignIn.RequireConfirmedEmail =
                   builder.Configuration.GetValue<bool>("Identity:SingIn:RequireConfirmedEmail");
            options.SignIn.RequireConfirmedPhoneNumber =
                   builder.Configuration.GetValue<bool>("Identity:SingIn:RequireConfirmedPhoneNumber");
            //User
            options.User.RequireUniqueEmail =
                   builder.Configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");

        }
    }
}
