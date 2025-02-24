using Shortly.Data.Models;

namespace Shortly.Data.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> AddAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<User> UpdateAsync(int id, User user);
        Task DeleteAsync(int id);
    }
}
