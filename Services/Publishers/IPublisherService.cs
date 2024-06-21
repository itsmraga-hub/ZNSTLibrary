using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Services.Publishers
{
    public interface IPublisherService
    {
        Task<CustomResponse> CreatePublisher(Publisher publisher);

        Task<List<Publisher>> GetPublishers();

        Task<CustomResponse> UpdatePublisher(string id, Publisher publisher);
        Task<CustomResponse> DeletePublisher(string id);
    }
}
