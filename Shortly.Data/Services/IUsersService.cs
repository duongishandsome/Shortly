using Shortly.Data.Models;

namespace Shortly.Data.Services
{
    public interface IUsersService
    {
        Task<List<AppUser>> GetUsersAsync();
    }
}
