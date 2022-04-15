using System.Collections.Generic;

namespace TestTaskApiPrototype2.Models.Responses
{
    public class ClientsPaginationAll //TODO: переименовать
    {
        public ICollection<Client> Data { get; set; }
    }
}