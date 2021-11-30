using Mdtc_library.Data;
using Mdtc_library.Model;
using Microsoft.AspNetCore.Components;

namespace Mdtc_library.Pages.Author;

public class AuthorComponent : ComponentBase
{
    [Inject]
    private AuthorService Service { get; set; }
    
    protected bool ModalState { get; set; }
    
    protected AuthorModel Model = new ();
    
    protected Data.Author[]? Authors;

    protected override async Task OnInitializedAsync()
    {
        Authors = await FetchAsync();
    }

    protected async Task<Data.Author[]?> FetchAsync()
    {
        return await Service.AllAsync();
    }

    protected async Task SearchAsync(string value)
    {
        Authors = await Service.FindAsync(value);
        StateHasChanged();
    }
    
    protected async Task CreateAsync(AuthorModel model)
    {
        ToggleModal();
        
        await Service.CreateAsync(model);
        Authors = await FetchAsync();
        
        Model = new AuthorModel();
        
        StateHasChanged();
    }

    protected async Task RemoveAsync(Guid id)
    {
        await Service.RemoveAsync(id);
        Authors = await FetchAsync();
        
        StateHasChanged();
    }
    
    protected void ToggleModal()
    {
        ModalState = !ModalState;
    }
}
