using System.Runtime.Serialization;

namespace Didact.Models;

[DataContract]
public class Article
{
    public Article(Author author)
    {
        AuthorId = author.AuthorId;
        ArticleContents = new HashSet<ArticleContent>();
    }

    public Article(Author author, World world)
    {
        AuthorId = author.AuthorId;
        WorldId = world.WorldId;
        ArticleContents = new HashSet<ArticleContent>();
    }

    [DataMember]
    public Guid ArticleId { get; set; } = Guid.NewGuid();

    [DataMember]
    public Guid? WorldId { get; set; }

    [DataMember]
    public Guid? AuthorId { get; set; }

    [DataMember]
    public string Title { get; set; } = null!;

    [DataMember]
    public string SubTitle { get; set; } = null!;

    [DataMember]
    public string Slug { get; set; }

    [DataMember]
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [DataMember]
    public DateTime? ModifiedOn { get; set; }

    [DataMember]
    public ICollection<ArticleContent> ArticleContents { get; set; } = new List<ArticleContent>();


}
