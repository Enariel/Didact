using Didact.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Didact.Components;

public partial class ProfileDropdown
{
    [CascadingParameter(Name = Utils.Keys.GameFile)]
    public DidactData Didact { get; set; }

    private Task UploadFileAsync(MouseEventArgs arg)
    {
        throw new NotImplementedException();
    }
}