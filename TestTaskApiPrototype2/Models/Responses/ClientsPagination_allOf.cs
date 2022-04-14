using System.Collections.Generic;

namespace TestTaskApiPrototype2.Models.Responses
{
    public class ClientsPagination_allOf //TODO: переименовать
    {
        public ICollection<Client> Data { get; set; }
    }
}