using System.ComponentModel.DataAnnotations.Schema;

namespace ZNSTLibrary.Data.Models
{
    [Table("Books")]
    public class Book : Base
    {
        public string Title { get; set; } = "";
        public string ISBN { get; set; } = "";
        public float Price { get; set; } = 0;
        public bool isAvailableForSale { get; set; } = false;
        public bool isAvailableForBorrow { get; set; } = false;
        public bool isAvailableForReservation { get; set; } = false;
        public bool isAvailableForExchange { get; set; } = false;
        public string AuthorName { get; set; } = "";
        public Publisher Publisher { get; set; } = null!;
        public string PublisherId { get; set; } = "";
        public Category Category { get; set; } = null!;
        public string CategoryId { get; set; } = "";
        public string Language { get; set; } = "";
        public int Pages { get; set; } = 0;
        public int Year { get; set; } = 0;
        public string Description { get; set; } = "";
        public string CoverUrl { get; set; } = "";
        public Author Author { get; set; } = null!;
        public string AuthorId { get; set; } = "";
        public string AuthorUrl { get; set; } = "";
        public string BookUrl { get; set; } = "";
        public string TitleUrl { get; set; } = "";
        public int NumberOfCopies { get; set; } = 0;
        public int NumberOfAvailableCopies { get; set; } = 0;
        public int NumberOfBorrowedCopies { get; set; } = 0;
        public int NumberOfReservedCopies { get; set; } = 0;
        public int NumberOfLostCopies { get; set; } = 0;
        public int NumberOfDamagedCopies { get; set; } = 0;

    }
}
