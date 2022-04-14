using System.ComponentModel.DataAnnotations;

namespace TestTaskApiPrototype2.Models
{
    public class PhoneNumber
    {
        [Key]
        public int PhoneNumberId { get; set; }


        public string Number { get; set; }
    }
}