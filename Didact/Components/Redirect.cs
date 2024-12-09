using Microsoft.AspNetCore.Components;

namespace Didact.Components;

public class Redirect : ComponentBase
{
    [Parameter] public string RedirectTo { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    protected override Task OnInitializedAsync()
    {
        NavigationManager.NavigateTo(RedirectTo);
        return base.OnInitializedAsync();
    }
}