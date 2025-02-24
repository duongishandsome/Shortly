using Shortly.Data.Models;

namespace Shortly.Data.Services
{
    public interface IUrlsService
    {
        Task<List<Url>> GetUrlsAsync();
        Task<Url> AddAsync(Url url);
        Task<Url> GetByIdAsync(int id);
        Task<Url> UpdateAsync(int id, Url url);
        Task DeleteAsync(int id);
    }
}
