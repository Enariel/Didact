using System.Xml.Serialization;

namespace Didact.Models;

[Serializable]
public class World
{
    [XmlElement]
    public Guid WorldId { get; set; }
    [XmlAttribute]
    public string WorldName { get; set; }
    [XmlAttribute]
    public string SubTitle { get; set; }
    [XmlElement]
    public string Summary { get; set; }
    [XmlAttribute]
    public bool IsActiveWorld { get; set; }
}