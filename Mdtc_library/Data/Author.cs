using Microsoft.EntityFrameworkCore;

namespace Mdtc_library.Data;

public class Author
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; }
    
    public List<Book>? Books { get; set; }
    
    internal static void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Author>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasMany(x => x.Books);
        });
    }
}