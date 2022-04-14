using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TestTaskApiPrototype2.Models
{
    [DataContract]
    public class Address
    {
        [Key]
        [JsonIgnore]
        public int AddressId { get; set; }


        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "zipCode")]
        public string ZipCode { get; set; }

        [Required]
        [DataMember(Name = "country")]
        public string Country { get; set; }

        [Required]
        [DataMember(Name = "region")]
        public string Region { get; set; }

        [Required]
        [DataMember(Name = "city")]
        public string City { get; set; }

        [Required]
        [DataMember(Name = "street")]
        public string Street { get; set; }

        [Required]
        [DataMember(Name = "house")]
        public string House { get; set; }

        [DataMember(Name = "block")]
        public string Block { get; set; }

        [DataMember(Name = "apartment")]
        public string Apartment { get; set; }

        [DataMember(Name = "createdAt")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}