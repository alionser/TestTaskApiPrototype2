using System.Text.Json.Serialization;


namespace TestTaskApiPrototype2.Models
{
    public enum EmpType
    {
        [JsonPropertyName("Employee")]
        Employee,
        [JsonPropertyName("Ie")]
        Ie,
        [JsonPropertyName("Owner")]
        Owner,
        [JsonPropertyName("Coowner")]
        Coowner, //typo?
        [JsonPropertyName("Retiree")]
        Retiree,
        [JsonPropertyName("Unemployed")]
        Unemployed
    }
}