using Shortly.Data.Models;

namespace Shortly.Data.Services
{
    public interface IUsersService
    {
        List<User> GetUsers();
        User Add(User user);
        User GetById(int id);
        User Update(int id, User user);
        void Delete(int id);
    }
}
