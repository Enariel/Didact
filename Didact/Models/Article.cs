namespace Didact.Models;

public partial class Article
{
    public Guid ArticleId { get; set; }
    public Guid? WorldId { get; set; }
    public Guid? AuthorId { get; set; }
    public string Title { get; set; } = null!;
    public string Slug { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public World World { get; set; }
    public ICollection<ArticleContent> ArticleContents { get; set; } = new List<ArticleContent>();


}
