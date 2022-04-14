using System.Collections.Generic;

namespace TestTaskApiPrototype2.Models.Responses
{
    public class ValidationError
    {
        public int Code { get; set; } = 400;
        public string Key { get; set; }
        public ICollection<ValidationErrorMessage> Messages { get; set; } //почему в единственном числе?
    }
}