using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class Child
    {
        [Key] //стоит ли явно указывать?
        public int ChildId { get; set; }


        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "surname")]
        public string Surname { get; set; }

        [DataMember(Name = "patronymic")]
        public string Patronymic { get; set; }

        [DataMember(Name = "dob")]
        public DateTime DateOfBirth { get; set; }
    }
}