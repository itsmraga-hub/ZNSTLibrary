using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZNSTLibrary.Data.Models
{
    [Table("Users")]
    public class User : IdentityUser
    {
        public int age { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now.Date;
        public string Role { get; set; } = "Default";
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string ProfilePictureUrl { get; set; } = "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50";
        public string Bio { get; set; } = "";
        public DateTime DateJoined { get; set; } = DateTime.Now.Date;
    }

    public enum UserRole
    {
        Default,
        Student,
        Instructor,
        Administrator
    }

}
