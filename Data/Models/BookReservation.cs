using System.ComponentModel.DataAnnotations.Schema;

namespace ZNSTLibrary.Data.Models
{
    [Table("BookReservations")]
    public class BookReservation : Base
    {
        public string BookId { get; set; } = "";
        public string UserId { get; set; } = "";
        public DateTime ReservationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; } = true;

        public Book Book { get; set; } = null!;
        public User User { get; set; } = null!;
    }

}
