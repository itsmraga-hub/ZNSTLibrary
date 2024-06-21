using System.ComponentModel.DataAnnotations.Schema;

namespace ZNSTLibrary.Data.Models
{
    [Table("Authors")]
    public class Author : Base
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string PhotoUrl { get; set; } = "";
        public string Website { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";
        public string PostalCode { get; set; } = "";

    }
}
