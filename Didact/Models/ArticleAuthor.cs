namespace Didact.Models;

public partial class ArticleAuthor
{
    public Guid ArticleId { get; set; }

    public long Author { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual Profile AuthorNavigation { get; set; } = null!;
}
