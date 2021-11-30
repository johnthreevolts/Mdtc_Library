using Mdtc_library;
using Mdtc_library.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SqliteContext>(options 
    => options.UseSqlite("Data Source=library.db"));

builder.Services.AddResponseCompression(config =>
{
    config.Providers.Add<BrotliCompressionProvider>();
    config.Providers.Add<GzipCompressionProvider>();
    config.EnableForHttps = true;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<AuthorService>();

var app = builder.Build();

app.UseResponseCompression();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();