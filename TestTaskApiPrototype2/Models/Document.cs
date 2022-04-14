using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }


        public Guid DocumentGuid { get; set; } //make migration
    }
}