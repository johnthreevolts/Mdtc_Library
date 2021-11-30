using Microsoft.AspNetCore.Components;

namespace Mdtc_library.Pages.Book;

public class BookTableComponent : ComponentBase
{
    [Parameter] 
    public Data.Book[] Books { get; set; }

    [Parameter] 
    public Func<Guid, Task> OnRemoveAction { get; set; }
}