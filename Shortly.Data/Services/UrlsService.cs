using Microsoft.EntityFrameworkCore;
using Shortly.Data.Models;

namespace Shortly.Data.Services
{
    public class UrlsService : IUrlsService
    {
        private AppDbContext _context;

        public UrlsService(AppDbContext context)
        {
            _context = context;
        }

        public Url GetById(int id)
        {
            var url = _context
                .Urls
                .FirstOrDefault(n => n.Id == id);
            return url;

        }

        public List<Url> GetUrls()
        {
            var allUrls = _context.Urls.Include(n => n.User).ToList();
            return allUrls;
        }

        public Url Add(Url url)
        {
           _context.Urls.Add(url);
           _context.SaveChanges();

            return url;
        }

        public Url Update(int id, Url url)
        {
            var urlDb = _context.Urls.FirstOrDefault(n => n.Id == id);

            if(url != null)
            {
                urlDb.OriginalLink = url.OriginalLink;
                urlDb.ShortLink = url.ShortLink;
                urlDb.DateUpdated = DateTime.UtcNow;

                _context.SaveChanges();
            }

            return url;
        }

        public void Delete(int id)
        {
            var urlDb = _context.Urls.FirstOrDefault(n => n.Id == id);

            if(urlDb != null)
            {
                _context.Urls.Remove(urlDb);
                _context.SaveChanges();
            }

            
        }

        
    }
}
