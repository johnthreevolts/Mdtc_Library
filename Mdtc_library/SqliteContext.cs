using Mdtc_library.Data;
using Microsoft.EntityFrameworkCore;

namespace Mdtc_library;

public class SqliteContext: DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public SqliteContext(DbContextOptions<SqliteContext>)
    {
        
    }
}