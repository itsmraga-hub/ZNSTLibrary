using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Services.Rentals
{
    public interface IBookRentalService
    {
        Task<CustomResponse> CreateBookRental(BookRental rental);
        Task<List<BookRental>> GetBookRentals();
        Task<List<BookReservation>> GetUserBooksReserved(string userId);
        Task<BookRental> GetBookRental(string id);
        Task<CustomResponse> UpdateBookRental(string id, BookRental rental);
        Task<CustomResponse> DeleteBookRental(string id);
    }
}
