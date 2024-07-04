using Microsoft.EntityFrameworkCore;
using ZNSTLibrary.Data.Models;
using ZNSTLibrary.Data;

namespace ZNSTLibrary.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ZNSTLibraryContext _context;

        public CategoriesService(ZNSTLibraryContext context)
        {
            _context = context;
        }

        public async Task<CustomResponse> CreateCategory(Category Categories)
        {
            if (Categories == null)
            {
                return await Task.FromResult(new CustomResponse("Categories cannot be null", 500));
            }
            _context.Categories.Add(Categories);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new CustomResponse(Categories.Id, "Categories created successfully", 200));
        }

        public async Task<CustomResponse> DeleteCategory(string id)
        {
            if (_context.Categories == null)
            {
                return await Task.FromResult(new CustomResponse("Categories cannot be null", 500));
            }
            var Categories = await _context.Categories.FindAsync(id);
            if (Categories == null)
            {
                return await Task.FromResult(new CustomResponse("Categories not found", 500));
            }

            _context.Categories.Remove(Categories);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new CustomResponse("Deleted successfully!", 200));
        }

        public async Task<List<Category>> GetCategories()
        {
            if (_context.Categories == null)
            {
                return new List<Category>();
            }
            return await _context.Categories.ToListAsync();
        }

        public async Task<CustomResponse> UpdateCategory(string id, Category category)
        {
            if (id != category.Id)
            {
                return await Task.FromResult(new CustomResponse("Categories id does bot match", 500));
            }
            if (category == null)
            {
                return await Task.FromResult(new CustomResponse("Categories cannot be null", 500));
            }
            // _context.Categoriess.Update(Categories);
            _context.Entry(category).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesExists(id))
                {
                    return await Task.FromResult(new CustomResponse("Categories cannot be null", 500));
                }
                else
                {
                    throw;
                }
            }
            // await _context.SaveChangesAsync(true);
            return await Task.FromResult(new CustomResponse(category.Id, "Categories updated successfully", 200));
        }
        private bool CategoriesExists(string id)
        {
            return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
