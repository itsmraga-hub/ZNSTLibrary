using Microsoft.EntityFrameworkCore;
using ZNSTLibrary.Data.Models;
using ZNSTLibrary.Data;

namespace ZNSTLibrary.Services.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly ZNSTLibraryContext _context;

        public AuthorService(ZNSTLibraryContext context)
        {
            _context = context;
        }

        public async Task<CustomResponse> CreateAuthor(Author author)
        {
            if (author == null)
            {
                return await Task.FromResult(new CustomResponse("Author cannot be null", 500));
            }
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new CustomResponse(author.Id, "Author created successfully", 200));
        }

        public async Task<CustomResponse> DeleteAuthor(string id)
        {
            if (_context.Authors == null)
            {
                return await Task.FromResult(new CustomResponse("Author cannot be null", 500));
            }
            var Author = await _context.Authors.FindAsync(id);
            if (Author == null)
            {
                return await Task.FromResult(new CustomResponse("Author not found", 500));
            }

            _context.Authors.Remove(Author);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new CustomResponse("Deleted successfully!", 200));
        }

        public async Task<List<Author>> GetAuthors()
        {
            if (_context.Authors == null)
            {
                return new List<Author>();
            }
            return await _context.Authors.ToListAsync();
        }

        public async Task<CustomResponse> UpdateAuthor(string id, Author author)
        {
            if (id != author.Id)
            {
                return await Task.FromResult(new CustomResponse("Author id does bot match", 500));
            }
            if (author == null)
            {
                return await Task.FromResult(new CustomResponse("Author cannot be null", 500));
            }
            // _context.Authors.Update(Author);
            _context.Entry(author).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return await Task.FromResult(new CustomResponse("Author cannot be null", 500));
                }
                else
                {
                    throw;
                }
            }
            // await _context.SaveChangesAsync(true);
            return await Task.FromResult(new CustomResponse(author.Id, "Author updated successfully", 200));
        }
        private bool AuthorExists(string id)
        {
            return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
