using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Didact.Models;

[DataContract]
public class World
{
    [DataMember]
    public Guid WorldId { get; set; }

    [DataMember]
    public string WorldName { get; set; }

    [DataMember]
    public string SubTitle { get; set; }

    [DataMember]
    public string Summary { get; set; }

    [DataMember]
    public bool IsActiveWorld { get; set; }
}