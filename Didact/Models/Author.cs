using System.Xml.Serialization;

namespace Didact.Models;

[Serializable]
[XmlRoot("Author", Namespace = "https://www.fuchsfarbestudios.com/Didact/Models")]
public class Author
{
    [XmlIgnore]
    public Guid AuthorId { get; set; }

    [XmlAttribute]
    public string PenName { get; set; }

    [XmlAttribute]
    public string FirstName { get; set; }

    [XmlAttribute]
    public string LastName { get; set; }

    [XmlIgnore]
    public DateTime? Birthday { get; set; }

    [XmlIgnore]
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [XmlIgnore]
    public DateTime? ModifiedOn { get; set; }

    [XmlAttribute("AuthorId")]
    public string AuthorIdString { get => this.AuthorId.ToString().ToUpper(); set => this.AuthorId = Guid.Parse(value); }

    [XmlElement("Birthday")]
    public string BirthdayString { get => this.Birthday?.ToString("yyyy-MM-dd HH:mm:ss"); set => this.Birthday = DateTime.Parse(value); }

    [XmlAttribute("CreatedOn")]
    public string CreatedOnString { get => this.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss");  set => this.CreatedOn = DateTime.Parse(value); }

    [XmlAttribute("ModifiedOn")]
    public string ModifiedOnString { get => this.ModifiedOn?.ToString("yyyy-MM-dd HH:mm:ss"); set => this.ModifiedOn = DateTime.Parse(value); }
}