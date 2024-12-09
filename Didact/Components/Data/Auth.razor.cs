using Didact.Models;
using Microsoft.AspNetCore.Components;

namespace Didact.Components.Data;

public partial class Auth
{
    [Parameter] public RenderFragment Authorized { get; set; }
    [Parameter] public RenderFragment NotAuthorized { get; set; }

    [CascadingParameter(Name = Utils.Keys.GameFile)]
    public DidactData Didact { get; set; }
}