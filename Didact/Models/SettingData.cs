using System.Runtime.Serialization;

namespace Didact.Models;

[DataContract]
public class SettingData
{
    [DataMember] public bool UseSessionStorage { get; set; }
}