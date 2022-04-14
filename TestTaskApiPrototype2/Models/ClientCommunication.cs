using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class ClientCommunication
    {
        [JsonIgnore]
        public int ClientCommunicationId { get; set; }


        [DataMember(Name = "Type")]
        public ClientCommunicationType Type { get; set; }

        [DataMember(Name = "phone")]
        public string Value { get; set; }
    }
}