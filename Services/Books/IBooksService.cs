using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Services.Books
{
    public interface IBooksService
    {
        Task<CustomResponse> CreateBook(Book book);

        Task<List<Book>> GetBooks();

        Task<Book> GetBook(string id);

        Task<CustomResponse> UpdateBook(string id, Book book);
        Task<CustomResponse> DeleteBook(string id);
    }
}
