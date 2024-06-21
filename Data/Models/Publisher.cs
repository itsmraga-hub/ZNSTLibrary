using System.ComponentModel.DataAnnotations.Schema;

namespace ZNSTLibrary.Data.Models
{
    [Table("Publishers")]
    public class Publisher : Base
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string LogoUrl { get; set; } = "";
        public string Website { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string ContactPerson { get; set; } = "";
        public string ContactPersonEmail { get; set; } = "";
        public string ContactPersonPhoneNumber { get; set; } = "";
        public string ContactPersonPosition { get; set; } = "";


    }
}
