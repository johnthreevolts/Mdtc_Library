using Microsoft.EntityFrameworkCore;

namespace Mdtc_library.Data;

public class Book
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public string Name { get; set; }
    
    public Author Author { get; set; }

    internal static void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.Author);
        });
    }
}