using Microsoft.AspNetCore.Components;

namespace Mdtc_library.Pages.Author;

public class AuthorSearchComponent : ComponentBase
{
    [Parameter]
    public Func<string, Task> OnSearch { get; set; }
    
    protected string Value { get; set; }
}