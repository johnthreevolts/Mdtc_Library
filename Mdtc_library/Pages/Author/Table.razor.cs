using Microsoft.AspNetCore.Components;

namespace Mdtc_library.Pages.Author;

public class AuthorTableComponent: ComponentBase
{
    [Parameter] 
    public Data.Author[] Authors { get; set; }

    [Parameter] 
    public Func<Guid, Task> OnRemoveAction { get; set; }
}