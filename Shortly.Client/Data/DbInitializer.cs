using Shortly.Data.Models;
using Shortly.Data;

namespace Shortly.Client.Data
{
    public class DbInitializer
    {
        public static void SeedDefaultData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!dbContext.Users.Any())
                {
                    dbContext.Users.Add(new User()
                    {
                        FullName = "Hoang Duong",
                        Email = "hvdvietnamquetoi@gmail.com"
                    });

                    dbContext.SaveChanges();
                }

                if (!dbContext.Urls.Any())
                {
                    dbContext.Urls.Add(new Url()
                    {
                        OriginalLink = "https://github.com",
                        ShortLink = "hvd",
                        NrOfClicks = 20,
                        DateCreated = DateTime.Now,

                        UserId = dbContext.Users.First().Id
                    });

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
