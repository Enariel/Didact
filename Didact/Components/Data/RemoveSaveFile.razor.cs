using Microsoft.AspNetCore.Components.Web;

namespace Didact.Components.Data;

public partial class RemoveSaveFile
{
    private async Task RemoveSaveFileAsync(MouseEventArgs obj)
    {
        Logger.LogWarning("Removing and deleting save file...");
        _isModifyingData = true;
        StateHasChanged();
        try
        {
            await Task.Delay(500);
            await LocalStorage.RemoveItemAsync(Utils.Keys.GameFile);
            await LocalStorage.ClearAsync();
            _isModifyingData = false;
            StateHasChanged();
            Logger.LogWarning("File has been removed.");
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.Message);
        }

        _isModifyingData = false;
        StateHasChanged();
    }
}