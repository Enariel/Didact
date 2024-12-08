namespace Didact.Flatify.Forms;

public interface IFormComponent
{
    public bool Required { get; set; }
    public bool Error { get; set; }
    public bool HasErrors { get; }
    public bool Touched { get; }
}