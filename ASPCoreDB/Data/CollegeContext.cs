using ASPCoreDB.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ASPCoreDB.Data
{
    /*
    CollegeContext extends (derived from) DbContext

    > We define our properties with type of "DbSet"
    > Each DbSet for each property maps to a table in our database
     */
    public class CollegeContext : DbContext
    {
        // Adding the constructor:
        // accepting the connections options:
        // Link: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-7.0&tabs=visual-studio#examine-the-generated-database-context-class-and-registration
        public CollegeContext(DbContextOptions<CollegeContext> options)
          : base(options)
        {
        }

        // adding the properties:
        // type prop then tab, tab
        /*
        Specify the tables that we want to have in our database

        each property will represent a table in our database
        property "Students" for Students table
        the Student table is built on the entity "Student"
        and we have a class for this entity named "Student"

        notice that we might have a list of students, so with EF,
        we don't use list, or array, we use a special set named DbSet

        DbSet<ClassType> PropertyName (based on the table name)
        */
        public DbSet<Student> Students { get; set; }

        // we can more properties if we have more tables:

        /*
        Overriding the OnConfiguring method to include 
        the connection configuration:
        using VSIDE auto complete...
        */

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        */

    } // class
} // namespace
