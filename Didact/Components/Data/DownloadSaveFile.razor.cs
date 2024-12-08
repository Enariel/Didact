using Didact.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Didact.Components.Data;

public partial class DownloadSaveFile
{
    public async Task DownloadFile()
    {
        var content = await base.GetDataAsync<DidactData>(Utils.Keys.GameFile);
        if (content == null)
            return;
        var fileName = content.FileName;
        var xml = await SerializeToXmlDataContractAsync(content);
        await Js.InvokeAsync<object>("saveFile", fileName, xml);
        await Task.CompletedTask;
    }
}