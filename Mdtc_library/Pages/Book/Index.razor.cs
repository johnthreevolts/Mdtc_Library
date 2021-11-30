using Mdtc_library.Data;
using Mdtc_library.Model;
using Microsoft.AspNetCore.Components;

namespace Mdtc_library.Pages.Book;

public class BookComponent : ComponentBase
{
    [Inject]
    private BookService Service { get; set; }
    
    [Inject]
    private AuthorService AuthorService { get; set; }
    
    protected bool ModalState { get; set; }
    
    protected BookModel Model = new ();

    protected Data.Book[]? Books;

    protected Data.Author[]? Authors;


    protected override async Task OnInitializedAsync()
    {
        Books = await FetchAsync();
        Authors = await FetchAuthorsAsync();
    }
    
    protected async Task<Data.Book[]?> FetchAsync()
    {
        return await Service.AllAsync();
    }

    protected async Task<Data.Author[]?> FetchAuthorsAsync()
    {
        return await AuthorService.AllAsync();
    }

    protected async Task SearchAsync(string value)
    {
        Books = await Service.FindAsync(value);
        StateHasChanged();
    }

    protected async Task CreateAsync(BookModel model)
    {
        ToggleModal();
        
        await Service.CreateAsync(model);
        Books = await FetchAsync();
        
        Model = new BookModel();
        
        StateHasChanged();
    }

    protected async Task RemoveAsync(Guid id)
    {
        await Service.RemoveAsync(id);
        Books = await FetchAsync();
        
        StateHasChanged();
    }
    
    protected void ToggleModal()
    {
        ModalState = !ModalState;
    }
}