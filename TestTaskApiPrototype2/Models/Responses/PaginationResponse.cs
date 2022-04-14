using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestTaskApiPrototype2.Models.Responses
{
    public class PaginationResponse
    {
        [JsonPropertyName("total")]
        public int TotalClients { get; set; } //TODO: сделать вычисляемыми
        [JsonPropertyName("perPage")]
        public int ClientsPerPage { get; set; } //TODO: измнить название для сериализцаии
        public int LastPage { get; set; }
        public int Page { get; set; }
        public ICollection<Client> Date { get; set; }
    }
}