using System.Runtime.Serialization;

namespace TestTaskApiPrototype2.Models
{
    public enum ClientCommunicationType
    {
        [DataMember(Name = "email")]
        Email = 1,

        [DataMember(Name = "phone")]
        Phone = 2
    }
}