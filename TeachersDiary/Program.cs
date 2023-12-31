using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeachersDiary.Data;
using TeachersDiary.Entities;
using TeachersDiary.Service;

namespace TeachersDiary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IAchievementService, AchievementService>();

            var configuration = builder.Configuration;

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BloggingDatabase")));

            builder.Services.AddDefaultIdentity<Teacher>()
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped<UserManager<Teacher>>();
            builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}