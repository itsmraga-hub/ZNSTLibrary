using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using ZNSTLibrary.Data;
using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Services.Books
{
    public class BooksService : IBooksService
    {
        private readonly ZNSTLibraryContext _context;

        public BooksService(ZNSTLibraryContext context)
        {
            _context = context;
        }

        public async Task<CustomResponse> CreateBook(Book book)
        {
            if (book == null)
            {
                return await Task.FromResult(new CustomResponse("Book cannot be null", 500));
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new CustomResponse(book.Id, "Book created successfully", 200));
        }

        public async Task<CustomResponse> DeleteBook(string id)
        {
            if (_context.Books == null)
            {
                return await Task.FromResult(new CustomResponse("Book cannot be null", 500));
            }
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return await Task.FromResult(new CustomResponse("Book not found", 500));
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new CustomResponse("Deleted successfully!", 200));
        }

        public async Task<Book> GetBook(string id)
        {
            if (_context.Books == null)
            {
                return await Task.FromResult(new Book());
            }
            var book = await _context.Books.Include(_ => _.Author).Include(_ => _.Category).Include(_ => _.Publisher).FirstOrDefaultAsync(_ => _.Id == id);
            return await Task.FromResult(book!);
        }

        public async Task<List<Book>> GetBooks()
        {
            if (_context.Books == null)
            {
                return new List<Book>();
            }
            return await _context.Books.Include(_ => _.Author).ToListAsync();
        }

        public async Task<CustomResponse> UpdateBook(string id, Book book)
        {
            if (id != book.Id)
            {
                return await Task.FromResult(new CustomResponse("Book id does bot match", 500));
            }            
            if (book == null)
            {
                return await Task.FromResult(new CustomResponse("Book cannot be null", 500));
            }
            // _context.Books.Update(book);
            _context.Entry(book).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return await Task.FromResult(new CustomResponse("Book cannot be null", 500));
                }
                else
                {
                    throw;
                }
            }
            // await _context.SaveChangesAsync(true);
            return await Task.FromResult(new CustomResponse(book.Id, "Book updated successfully", 200));
        }
        private bool BookExists(string id)
        {
            return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
