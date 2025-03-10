using Microsoft.EntityFrameworkCore;
using Shortly.Data;
using Shortly.Data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUrlsService, UrlsService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapGet("/{path}", async (string path, IUrlsService urlService) =>
{
    var urlObj = await urlService.GetOriginalUrlAsync(path);
    if (urlObj != null)
    {
        await urlService.IncrementNumberOfClicksAsync(urlObj.Id);

        return Results.Redirect(urlObj.OriginalLink);
    }

    return Results.Redirect("/");
});


app.Run();

