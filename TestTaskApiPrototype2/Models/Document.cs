using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class Document
    {
        [Key]
        [JsonIgnore]
        public int DocumentId { get; set; }


        [DataMember]
        public Guid DocumentGuid { get; set; } //make migration
    }
}