namespace Didact.Models;

public partial class ArticleContent
{
    public Guid ArticleId { get; set; }

    public int ContentId { get; set; }

    public string? Content { get; set; }

    public string? ContentType { get; set; }

    public int? Order { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual Article Article { get; set; } = null!;
}
