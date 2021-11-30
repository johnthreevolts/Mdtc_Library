using Mdtc_library.Model;
using Microsoft.AspNetCore.Components;

namespace Mdtc_library.Pages.Author;

public class AuthorModalComponent : ComponentBase
{
    [Parameter]
    public bool State { get; set; }
    
    [Parameter]
    public EventCallback<bool> StateChanged { get; set; }
    
    [Parameter]
    public AuthorModel Model { get; set; }

    [Parameter]
    public Func<AuthorModel, Task> OnCreateRecord { get; set; }

    protected string? ModalCssClass => State ? "collapse" : null;
    
    protected async Task UpdateState()
    {
        await StateChanged.InvokeAsync();
    }
}