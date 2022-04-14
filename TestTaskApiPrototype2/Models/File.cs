using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class File
    {
        [Key]
        [JsonIgnore]
        public int FileId { get; set; }


        public Guid FileGuid { get; set; }
    }
}