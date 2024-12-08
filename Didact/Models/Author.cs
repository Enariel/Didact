using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Didact.Models;

[DataContract]
public class Author
{
    [DataMember] public Guid AuthorId { get; set; }

    [DataMember] public string PenName { get; set; }

    [DataMember] public string FirstName { get; set; }

    [DataMember] public string LastName { get; set; }

    [DataMember] public DateTime? Birthday { get; set; }

    [DataMember] public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [DataMember] public DateTime? ModifiedOn { get; set; }

    [DataMember] public ICollection<Article> Articles { get; set; } = new List<Article>();

    [DataMember] public ICollection<World> Worlds { get; set; } = new List<World>();

    // [XmlAttribute("AuthorId")]
    // public string AuthorIdString { get => this.AuthorId.ToString().ToUpper(); set => this.AuthorId = Guid.Parse(value); }
    //
    // [XmlElement("Birthday")]
    // public string BirthdayString { get => this.Birthday?.ToString("yyyy-MM-dd HH:mm:ss"); set => this.Birthday = DateTime.Parse(value); }
    //
    // [XmlAttribute("CreatedOn")]
    // public string CreatedOnString { get => this.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss");  set => this.CreatedOn = DateTime.Parse(value); }
    //
    // [XmlAttribute("ModifiedOn")]
    // public string ModifiedOnString { get => this.ModifiedOn?.ToString("yyyy-MM-dd HH:mm:ss"); set => this.ModifiedOn = DateTime.Parse(value); }
}