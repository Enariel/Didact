using System.Runtime.Serialization;

namespace Didact.Models;

[DataContract]
public class Category
{
    [DataMember]
    public Guid CategoryId { get; set; } = Guid.NewGuid();

    [DataMember]
    public string Title { get; set; } = null!;

    [DataMember]
    public string Description { get; set; } = null!;

    [DataMember]
    public DateTime? CreatedOn { get; set; }

    [DataMember]
    public DateTime? ModifiedOn { get; set; }
}