using Mdtc_library.Model;
using Microsoft.EntityFrameworkCore;

namespace Mdtc_library.Data;

public class BookService
{
    private DbContext Context { get; set; }
    
    private DbSet<Book> Repo { get; set; }
    
    private DbSet<Author> AuthorRepo { get; set; }
    
    public BookService(SqliteContext context)
    {
        Context = context;
        Repo = context.Books;
        AuthorRepo = context.Authors;
    }
    
    public async Task<Book[]> AllAsync()
    {
        var books = await Repo.Include(x => x.Author).ToArrayAsync();
        return books;
    }

    public async Task<Book[]> FindAsync(string name)
    {
        var books = await Repo.Where(condition => condition.Name.Contains(name))
            .ToArrayAsync();
        return books;
    }
    
    public async Task<bool> CreateAsync(BookModel model)
    {
        var author = await AuthorRepo.FindAsync(model.Author);
        if (author == null) return false;

        var record = new Book()
        {
            Name = model.Name,
            Author = author,
        };

        Repo.Add(record);
        await Context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        var record = await Repo.FindAsync(id);
        if (record == null) return false;
        
        Repo.Remove(record);
        await Context.SaveChangesAsync();
        
        return true;
    }
}