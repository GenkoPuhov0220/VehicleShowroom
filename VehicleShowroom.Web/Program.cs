using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Web;


namespace VehicleShowroom.Web
{
    public class Program
    {
        public static void Main(string[] args)
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

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            var app = builder.Build();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

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
