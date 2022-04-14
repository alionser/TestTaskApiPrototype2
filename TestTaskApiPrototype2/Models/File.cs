using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class File
    {
        [Key]
        public int FileId { get; set; }


        public Guid FileGuid { get; set; }
    }
}