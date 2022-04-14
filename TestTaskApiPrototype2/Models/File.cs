using System;
using System.ComponentModel.DataAnnotations;

namespace TestTaskApiPrototype2.Models
{
    public class File
    {
        [Key]
        public int FileId { get; set; }


        public Guid FileGuid { get; set; }
    }
}