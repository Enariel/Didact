namespace Didact.Models;

public partial class WorldArticle
{
    public Guid WorldId { get; set; }

    public Guid ArticleId { get; set; }

    public virtual World World { get; set; } = null!;
}
