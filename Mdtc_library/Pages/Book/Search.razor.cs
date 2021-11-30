using Microsoft.AspNetCore.Components;

namespace Mdtc_library.Pages.Book;

public class BookSearchComponent : ComponentBase
{
    [Parameter]
    public Func<string, Task> OnSearch { get; set; }
    
    protected string Value { get; set; }
}