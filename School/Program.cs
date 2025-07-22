using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using School.Data;
using School.Data.Repos;
using School.MiddleWares;
using static System.Net.Mime.MediaTypeNames;

namespace School
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SchoolDBContext>(opt => 
            
                opt.UseSqlServer("Data Source=(localdb)\\Test;Integrated Security=True;Trust Server Certificate=True; Initial Catalog=SchoolDB;"));

            //TODO
            builder.Services.AddScoped<SchoolRepoInterface, SchoolSqlRepo>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var allowedOrigins = builder.Configuration.GetValue<string>("allowedOrigins")!.Split(","); 

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
               
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // My Testing MiddleWare
            //app.AppHeaderTest();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
