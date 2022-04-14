using System;
using System.ComponentModel.DataAnnotations;

namespace TestTaskApiPrototype2.Models
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }


        public Guid FileGuid { get; set; }
    }
}