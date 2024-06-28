using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Services.Rentals
{
    public class BookRental : IBookRental
    {
        public Task<CustomResponse> CreateBookRental(BookRental rental)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse> DeleteBookRental(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BookRental> GetBookRental(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookRental>> GetBookRentals()
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse> UpdateBookRental(string id, BookRental rental)
        {
            throw new NotImplementedException();
        }
    }
}
