using Microsoft.EntityFrameworkCore;
using ZNSTLibrary.Data.Models;
using ZNSTLibrary.Data;

namespace ZNSTLibrary.Services.Publishers
{
    public class PublisherService : IPublisherService
    {
        private readonly ZNSTLibraryContext _context;

        public PublisherService(ZNSTLibraryContext context)
        {
            _context = context;
        }

        public async Task<CustomResponse> CreatePublisher(Publisher publisher)
        {
            if (publisher == null)
            {
                return await Task.FromResult(new CustomResponse("Publisher cannot be null", 500));
            }
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new CustomResponse(publisher.Id, "Publisher created successfully", 200));
        }

        public async Task<CustomResponse> DeletePublisher(string id)
        {
            if (_context.Publishers == null)
            {
                return await Task.FromResult(new CustomResponse("Publisher cannot be null", 500));
            }
            var Publisher = await _context.Publishers.FindAsync(id);
            if (Publisher == null)
            {
                return await Task.FromResult(new CustomResponse("Publisher not found", 500));
            }

            _context.Publishers.Remove(Publisher);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new CustomResponse("Deleted successfully!", 200));
        }

        public async Task<List<Publisher>> GetPublishers()
        {
            if (_context.Publishers == null)
            {
                return new List<Publisher>();
            }
            return await _context.Publishers.ToListAsync();
        }

        public async Task<CustomResponse> UpdatePublisher(string id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return await Task.FromResult(new CustomResponse("Publisher id does bot match", 500));
            }
            if (publisher == null)
            {
                return await Task.FromResult(new CustomResponse("Publisher cannot be null", 500));
            }
            // _context.Publishers.Update(Publisher);
            _context.Entry(publisher).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(id))
                {
                    return await Task.FromResult(new CustomResponse("Publisher cannot be null", 500));
                }
                else
                {
                    throw;
                }
            }
            // await _context.SaveChangesAsync(true);
            return await Task.FromResult(new CustomResponse(publisher.Id, "Publisher updated successfully", 200));
        }
        private bool PublisherExists(string id)
        {
            return (_context.Publishers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
