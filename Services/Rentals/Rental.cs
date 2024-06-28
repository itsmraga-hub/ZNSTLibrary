using Microsoft.EntityFrameworkCore;
using ZNSTLibrary.Data;
using ZNSTLibrary.Data.Models;
using ZNSTLibrary.Pages.Books;

namespace ZNSTLibrary.Services.Rentals
{
    public class Rental : IBookRental
    {
        private readonly ZNSTLibraryContext _context;

        public Rental(ZNSTLibraryContext context)
        {
            _context = context;
        }

        public async Task<CustomResponse> CreateBookRental(BookRental rental)
        {
            if (rental == null)
            {
                return await Task.FromResult(new CustomResponse("Rental cannot be null", 500));
            }
            _context.BookRentals.Add(rental);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new CustomResponse(rental.Id, "Rental created successfully", 200));
        }

        public async Task<CustomResponse> DeleteBookRental(string id)
        {
            if (_context.BookRentals == null)
            {
                return await Task.FromResult(new CustomResponse("Rental cannot be null", 500));
            }
            var rental = await _context.BookRentals.FindAsync(id);
            if (rental == null)
            {
                return await Task.FromResult(new CustomResponse("Rental not found", 500));
            }

            _context.BookRentals.Remove(rental);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new CustomResponse("Deleted successfully!", 200));
        }

        public async Task<BookRental> GetBookRental(string id)
        {
            if (_context.BookRentals == null)
            {
                return await Task.FromResult(new BookRental());
            }
            var rental = await _context.BookRentals.Include(_ => _.User).Include(_ => _.Book).FirstOrDefaultAsync(_ => _.Id == id);
            return await Task.FromResult(rental!);
        }

        public async Task<List<BookRental>> GetBookRentals()
        {
            if (_context.BookRentals == null)
            {
                return new List<BookRental>();
            }
            return await _context.BookRentals.Include(_ => _.Book).ToListAsync();
        }

        public Task<CustomResponse> UpdateBookRental(string id, BookRental rental)
        {
            throw new NotImplementedException();
        }
    }
}
