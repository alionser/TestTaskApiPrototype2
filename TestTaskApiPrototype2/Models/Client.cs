using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata;
using JsonExtensionDataAttribute = Newtonsoft.Json.JsonExtensionDataAttribute;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class Client
    {
        [Key]
        public int ClientId { get; set; }


        [DataMember(Name= "id")]
        public Guid Id { get; set; }

        [DataMember(Name= "name")]
        public string Name;

        [DataMember(Name= "surname")]
        public string Surname { get; set; }

        [DataMember(Name= "patronymic")]
        public string Patronymic { get; set; }

        [DataMember(Name= "dob")]
        [JsonPropertyName("dob")] //TODO: КО ВСЕМ СВОЕЙСТВАМ ДОБАВЛЯТЬ?
        public DateTime DateOfBirth { get; set; }

        [DataMember(Name= "spouse")]
        public Client Spouse { get; set; }

        [DataMember(Name= "children")]
        public ICollection<Child> Children { get; set; }

        [DataMember(Name= "passport")]
        public DocumentPassport Passport { get; set; }

        [DataMember(Name= "livingAddress")] //разобраться с наименованиями
        public Address LivingAddress { get; set; }

        [DataMember(Name= "regAddress")]
        public Address RegAddress { get; set; }

        [DataMember(Name= "jobs")]
        public ICollection<Job> Jobs { get; set; }

        [DataMember(Name= "generalExp")]
        public double GeneralExp { get; set; } //int?

        [DataMember(Name= "curWorkExp")]
        public double CurWorkExp { get; set; } //int?

        [DataMember(Name= "curFieldExp")]
        public double CurFieldExp { get; set; } //int?

        [DataMember(Name= "status")]
        // [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusType Status { get; set; }

        [DataMember(Name= "typeEducation")]
        // [JsonConverter(typeof(JsonStringEnumConverter))]
        public EducationType TypeEducation { get; set; }

        [DataMember(Name= "maritalStatus")]
        // [JsonConverter(typeof(JsonStringEnumConverter))]
        public MaritalStatusType MaritalStatus { get; set; }

        [DataMember(Name= "typeEmp")]
        // [JsonConverter(typeof(JsonStringEnumConverter))]
        public EmpType TypeEmp { get; set; }

        [DataMember(Name= "monIncome")]
        public double MonthIncome { get; set; }

        [DataMember(Name= "monExpenses")]
        public double MonthExpense { get; set; }

        [DataMember(Name= "files")]
        public ICollection<File> Files { get; set; }

        [DataMember(Name= "documents")]
        public ICollection<Document> Documents { get; set; }

        [DataMember(Name= "communications")]
        public ICollection<ClientCommunication> Communications { get; set; }

        [DataMember(Name= "createdAt")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name= "updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}