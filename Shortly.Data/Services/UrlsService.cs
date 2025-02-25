﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<Url> GetByIdAsync(int id)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);
            return url;
        }

        public async Task<List<Url>> GetUrlsAsync()
        {
            var allUrls = await _context.Urls.Include(n => n.User).ToListAsync();
            return allUrls;
        }

        public async Task<Url> AddAsync(Url url)
        {
            await _context.Urls.AddAsync(url);
            await _context.SaveChangesAsync();

            return url;
        }

        public async Task<Url> UpdateAsync(int id, Url url)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);
            if (urlDb != null)
            {
                urlDb.OriginalLink = url.OriginalLink;
                urlDb.ShortLink = url.ShortLink;
                urlDb.DateUpdated = DateTime.UtcNow;

                await _context.SaveChangesAsync();
            }

            return urlDb;
        }

        public async Task DeleteAsync(int id)
        {
            var urlDb = await _context.Urls.FirstOrDefaultAsync(n => n.Id == id);

            if (urlDb != null)
            {
                _context.Remove(urlDb);
                await _context.SaveChangesAsync();
            }
        }

    }
}
