using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class PhoneNumber
    {
        [Key]
        [JsonIgnore]
        public int PhoneNumberId { get; set; }


        [DataMember]
        public string Number { get; set; }
    }
}