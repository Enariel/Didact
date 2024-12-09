using Didact.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Didact.Components.Forms;

public partial class NewAuthorForm
{
    private string _messages;
    private bool _isValid;
    private Author _model = new Author()
    {
        AuthorId = Guid.NewGuid()
    };

    [CascadingParameter(Name = "Didact")] public DidactData Didact { get; set; }
    [Inject] private NavigationManager Nav { get; set; }

    private async Task OnValidSubmitAsync(EditContext arg)
    {
        _isValid = arg.Validate();
        if (_isValid)
        {
            try
            {
                _model.AuthorId = Guid.NewGuid();
                _model.CreatedOn = DateTime.UtcNow;
                Didact = new DidactData(_model);
                await base.SaveAsync(Utils.Keys.GameFile, Didact);
                StateHasChanged();
                Nav.Refresh(true);
            }
            catch (Exception ex)
            {
                _messages = ex.Message;
                _messages += $"\n\tSource: {ex.Source}";
                _messages += $"\n\tStack Trace: {ex.StackTrace}";
            }
        }
    }
}