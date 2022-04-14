using System.Runtime.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class ClientCommunication
    {
        public int ClientCommunicationId { get; set; }


        [DataMember(Name = "Type")]
        public ClientCommunicationType Type { get; set; }

        [DataMember(Name = "phone")]
        public ClientCommunicationType Phone { get; set; }
    }
}