// We need to use DataAnnotations
// for adding the attributes []
using System.ComponentModel.DataAnnotations;

namespace ASPCoreDB.Models
{
    /*
    Creating Object Relation Mapper (ORM)
    
    Table Students <= ORM => class Student

    The ORM that we are using is "Entity Framework"
    from Microsoft
    */
    public class Student
    {
        /*
        Adding the class fields that represent table fields in our DB

        We can just use the C# properties right away without fields:
         */

        // private string _id; // No need for this field, just the property:

        /*
        The ID field is required by the database for the primary key.
        
        the property Id will represent the primary key for our table.
        now we can decorate the property with an attribute named "[key]"
        with capital "K" to indicate that it's the primary key if we need

        The [PrimaryKey] attribute was introduced in EF Core 7.0. 

        Link:https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations 

        By convention, a property named Id or <type name>Id 
        will be configured as the primary key of an entity.
        */

        [Key] // Remember that here is the use of [Key] is optional
        public int Id { get; set; }


        // or using this way from the intellisense menu
        // public string Id { get => _id; set => _id = value; }

        /*
        NOTE:
        Notice that all the string properties 
        have been initialized with either "null!" or "string.Empty"
        because in .NET6 and later, all projects enable nullable reference type by default.
        
        Otherwise we receive a warning:
        Nonnullable reference not initialized
        CS8618 - Non-nullable variable must contain a non-null value 
        when exiting constructor. Consider declaring it as nullable.
        */

        [Required] // to make sure that this field is required
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        public string LastDate { get; set; } = null!;
        
        [Required]
        public string Program { get; set; } = null!;

        /*
        NOTE:
        A [DataType] attribute specifies the type of data in the EnrollmentDate property. 
        which means:
        - The user isn't required to enter time information in the date field.
        - Only the date is displayed, not time information.
        */
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }    
    } // class
}// namespace
