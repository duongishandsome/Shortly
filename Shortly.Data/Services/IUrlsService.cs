using Shortly.Data.Models;

namespace Shortly.Data.Services
{
    public interface IUrlsService
    {
        List<Url> GetUrls();
        Url Add(Url url);
        Url GetById(int id);
        Url Update(int id, Url url);
        void Delete(int id);
    }
}
