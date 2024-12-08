using System.Runtime.Serialization;

namespace Didact.Models;

[DataContract]
public class Profile
{
    public Profile(Author author)
    {
        AuthorId = author.AuthorId;
        PreferredName = author.PenName;
        ModifiedOn = DateTime.UtcNow;
    }

    [DataMember]
    public Guid AuthorId { get; set; }

    [DataMember]
    public string PreferredName { get; set; }

    [DataMember]
    public string Avatar { get; set; }

    [DataMember]
    public string AvatarAlt { get; set; }

    [DataMember]
    public string Bio { get; set; }

    [DataMember]
    public string Skills { get; set; }

    [DataMember]
    public string Interests { get; set; }

    [DataMember]
    public string Aspirations { get; set; }

    [DataMember]
    public long WordCount { get; set; }

    [DataMember]
    public DateTime? ModifiedOn { get; set; }

}
