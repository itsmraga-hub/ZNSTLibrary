using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Services.Authors
{
    public interface IAuthorService
    {
        Task<CustomResponse> CreateAuthor(Author Author);

        Task<List<Author>> GetAuthors();

        Task<CustomResponse> UpdateAuthor(string id, Author Author);
        Task<CustomResponse> DeleteAuthor(string id);
    }
}
