using System.ComponentModel.DataAnnotations.Schema;

namespace ZNSTLibrary.Data.Models
{
    [Table("BookRentals")]
    public class BookRental : Base
    {
        public string BookId { get; set; } = "";
        public string UserId { get; set; } = "";
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;

        public Book Book { get; set; } = null!;
        public User User { get; set; } = null!;
    }

}
