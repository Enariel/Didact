using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Didact.Components.Data;

public partial class RemoveSaveFile
{
    [Inject] private NavigationManager Nav { get; set; }

    private async Task RemoveSaveFileAsync(MouseEventArgs obj)
    {
        Logger.LogWarning("Removing and deleting save file...");
        _isModifyingData = true;
        try
        {
            await Task.Delay(500);
            await LocalStorage.RemoveItemAsync(Utils.Keys.GameFile);
            await LocalStorage.ClearAsync();
            _isModifyingData = false;
            StateHasChanged();
            Logger.LogWarning("File has been removed.");
            Nav.NavigateTo("/", true);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message);
        }

        _isModifyingData = false;
        StateHasChanged();
    }
}