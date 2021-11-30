using Mdtc_library.Model;
using Microsoft.EntityFrameworkCore;

namespace Mdtc_library.Data;

public class AuthorService
{
    private DbContext Context { get; set; }
    
    private DbSet<Author> Repo { get; set; }

    public AuthorService(SqliteContext context)
    {
        Context = context;
        Repo = context.Authors;
    }

    public async Task<Author[]> AllAsync()
    {
        var authors = await Repo.Include(x => x.Books).ToArrayAsync();
        return authors;
    }

    public async Task<Author[]> FindAsync(string name)
    {
        var authors = await Repo.Where(condition => condition.Name.Contains(name))
            .ToArrayAsync();
        return authors;
    }

    public async Task<bool> CreateAsync(AuthorModel model)
    {
        var record = new Author()
        {
            Name = model.Name
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