using Didact.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Didact.Components.Data;

public partial class UploadSaveFile
{
    private async Task SingleUpload(InputFileChangeEventArgs e)
    {
        // Get file extension and reject if its not .xml

        var fileNameParts = e.File.Name.Split('.');
        var extension = fileNameParts.LastOrDefault();
        if (extension != "xml")
            return;

        try
        {
            MemoryStream ms = new MemoryStream();
            await e.File.OpenReadStream().CopyToAsync(ms);
            var bytes = ms.ToArray();
            var str = System.Text.Encoding.UTF8.GetString(bytes);
            var author = await base.DeserializeFromXmlAsync<Author>(str);
        }
        catch (Exception ex)
        {
            Logger.LogError($"\n{ex.Message} \n{ex.Source} \n" +
                            $"\n{ex.StackTrace}");
        }
    }
}