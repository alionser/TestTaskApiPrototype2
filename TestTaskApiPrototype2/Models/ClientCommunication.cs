using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class ClientCommunication
    {
        [Key]
        [JsonIgnore]
        public int ClientCommunicationId { get; set; }


        [DataMember(Name = "Type")]
        public ClientCommunicationType Type { get; set; }

        [DataMember(Name = "phone")]
        public string Value { get; set; }
    }
}