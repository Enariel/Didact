using Blazored.LocalStorage;
using Didact.Models;
using Microsoft.AspNetCore.Components;

namespace Didact.Layout;

public partial class MainLayout
{
    private DidactData _didact;
    [Inject] public ILocalStorageService Storage { get; set; }
    [Inject] public ILogger<MainLayout> Logger { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Logger.LogInformation("Finding file in local storage...");
            var data = await Storage.GetItemAsStringAsync(Utils.Keys.GameFile);
            if (string.IsNullOrEmpty(data))
                Logger.LogWarning("No file found...");
            else
            {
                _didact = await Serialization.DeserializeFromXmlDataContractAsync<DidactData>(data);
                Logger.LogInformation("Success!");
                StateHasChanged();
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Something went wrong...");
            Logger.LogError(ex.Message);
            throw;
        }

        await base.OnInitializedAsync();
    }
}