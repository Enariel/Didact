using System.Runtime.Serialization;

namespace Didact.Models;

[DataContract]
public enum ArticleContentType
{
    Text,
    Image,
    Video,
    Audio,
    Code,
    Quote,
    List,
    Table,
    Link,
}