using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Services.Categories
{
    public interface ICategoriesService
    {
        Task<CustomResponse> CreateCategory(Category Categories);

        Task<List<Category>> GetCategories();

        Task<CustomResponse> UpdateCategory(string id, Category Categories);
        Task<CustomResponse> DeleteCategory(string id);
    }
}
