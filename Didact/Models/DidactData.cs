using System.Runtime.Serialization;

namespace Didact.Models;

[DataContract]
public class DidactData
{
    public DidactData()
    {
        Author = new Author();
        FileName = Guid.NewGuid().ToString() + ".xml";
        Settings = new SettingData();
        Profile = new Profile(Author);
        Worlds = new List<World>();
        Articles = new List<Article>();
        Categories = new List<Category>();
    }

    public DidactData(Author author)
    {
        Author = author;
        FileName = author.PenName + ".xml";
        Settings = new SettingData();
        Profile = new Profile(author);
        Worlds = new List<World>();
        Articles = new List<Article>();
        Categories = new List<Category>();
    }

    [DataMember] public Guid FileId { get; set; } = Guid.NewGuid();
    [DataMember] public string FileName { get; set; }
    [DataMember] public Author Author { get; set; }
    [DataMember] public Profile Profile { get; set; }
    [DataMember] public SettingData Settings { get; set; }
    [DataMember] public List<World> Worlds { get; set; }
    [DataMember] public List<Article> Articles { get; set; }
    [DataMember] public List<Category> Categories { get; set; }
}