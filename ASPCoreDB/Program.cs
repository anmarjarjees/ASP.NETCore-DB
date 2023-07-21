using ASPCoreDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ASPCoreDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            /*
            Adding Our custom services first with: builder.Services.Add...
            before building the application with: builder.Build();

            The database context is registered with the Dependency Injection container

            - using the method "AddDbContext()"
            - mapping it to our class <CollegeContext> as the data type
            - adding the lambda expression with the parameter "options"

            NOTES:
            *****
            1. the statement: using ASPCoreDB.Data;
            is added to access our class "CollegeContext" inside "Data" folder

            2. the statement: using Microsoft.EntityFrameworkCore;
            is added for using options.UseSqlServer EF

            Link: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-7.0&tabs=visual-studio#dependency-injection

            NOTE: 
            Since we installed the SQL Server Package with Packages Manager,
            we have the "UseSqlServer" method

            CollegeContext is just the name for our connection string 
            (It can be any name that we specify inside the "appsettings.json" file).
            This "CollegeContext" name is defined/added to the JSON file for the application
            */
            builder.Services.AddDbContext<CollegeContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeContext")));

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

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}