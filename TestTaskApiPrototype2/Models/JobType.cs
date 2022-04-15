using System.Runtime.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public enum JobType
    {
        [DataMember(Name = "main")]
        Main = 1,

        [DataMember(Name = "pluralistically")]
        Pluralistically = 2,

        [DataMember(Name = "owner")]
        Owner = 3,

        [DataMember(Name = "participant")]
        Participant = 3
    }
}