using System.Runtime.Serialization;

namespace Didact.Models;

[DataContract]
public class ArticleContent
{
    public ArticleContent(){}

    public ArticleContent(Article article)
    {
        ParentArticleId = article.ArticleId;
    }

    [DataMember] public Guid ParentArticleId { get; set; }

    [DataMember] public string Content { get; set; }

    [DataMember] public ArticleContentType ContentType { get; set; } = ArticleContentType.Text;

    [DataMember] public int Order { get; set; } = 0;

    [DataMember] public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [DataMember] public DateTime? ModifiedOn { get; set; }
}