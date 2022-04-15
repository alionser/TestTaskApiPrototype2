using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class Job
    {
        [Key]
        [JsonIgnore]
        public int JobId { get; set; }


        [DataMember(Name="companyName")]
        public string CompanyName { get; set; }

        [DataMember(Name="type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public JobType Type { get; set; }

        [DataMember(Name="dateEmp")]
        public DateTime DateEmp { get; set; }

        [DataMember(Name="dateDismissal")]
        public DateTime DateDismissal { get; set; }

        [DataMember(Name="tin")]
        public string Tin { get; set; }

        [DataMember(Name="address")]
        public Address Address { get; set; }

        [DataMember(Name="jobTitle")]
        public string JobTitle { get; set; }

        [DataMember(Name="monIncome")]
        public int MonthIncome { get; set; } //тут точно int?

        [DataMember(Name="fioManager")]
        public string FioManager { get; set; }

        [DataMember(Name="site")]
        public Uri Site { get; set; } //or common string is better?

        [DataMember(Name="phoneNumbers")]
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        [DataMember(Name="createdAt")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name="updatedAt")]
        public DateTime UpdatedAt { get; set; }

    }
}