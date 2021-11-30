using Mdtc_library.Model;
using Microsoft.AspNetCore.Components;

namespace Mdtc_library.Pages.Book;

public class BookModalComponent : ComponentBase
{
    [Parameter]
    public bool State { get; set; }
    
    [Parameter]
    public EventCallback<bool> StateChanged { get; set; }
    
    [Parameter]
    public BookModel Model { get; set; }
    
    [Parameter]
    public Data.Author[] Authors { get; set; }

    [Parameter]
    public Func<BookModel, Task> OnCreateRecord { get; set; }

    protected string? ModalCssClass => State ? "collapse" : null;
    
    protected async Task UpdateState()
    {
        await StateChanged.InvokeAsync();
    }
}