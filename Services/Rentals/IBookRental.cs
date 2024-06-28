using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Services.Rentals
{
    public interface IBookRental
    {
        Task<CustomResponse> CreateBookRental(BookRental rental);

        Task<List<BookRental>> GetBookRentals();

        Task<BookRental> GetBookRental(string id);

        Task<CustomResponse> UpdateBookRental(string id, BookRental rental);
        Task<CustomResponse> DeleteBookRental(string id);

        // Task<CustomResponse> ReserveBook(BookReservation bookReservation);
    }
}
