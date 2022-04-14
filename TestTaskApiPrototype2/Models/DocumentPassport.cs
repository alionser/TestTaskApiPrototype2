using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TestTaskApiPrototype2.Models
{
    public class DocumentPassport
    {
        [Key]
        public int DocumentPassportId { get; set; }


        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "series")]
        public string Series { get; set; }

        [DataMember(Name = "number")]
        public string Number { get; set; }

        [DataMember(Name = "giver")]
        public string Giver { get; set; }

        [DataMember(Name = "dateIssued")]
        public DateTime DateIssued { get; set; }

        [DataMember(Name = "birthPlace")]
        public string BirthPlace { get; set; }

        [DataMember(Name = "createdAt")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}