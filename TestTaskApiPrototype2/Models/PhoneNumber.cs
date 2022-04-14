using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class PhoneNumber
    {
        [Key]
        public int PhoneNumberId { get; set; }


        public string Number { get; set; }
    }
}