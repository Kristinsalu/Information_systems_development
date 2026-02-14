using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarsAndPeople.Models
{
    public record Person
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public Gender Gender { get; init; }
        public DateTime? DateOfBirth { get; init; }
        public HairColor HairColor{ get; init; }
        public decimal? Height { get; init; }
        public decimal? Weight { get; init; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender{
        Male = 1,
        Female = 2
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HairColor{
        Brunette = 1,
        Blonde = 2,
        Ginger = 3,
        Other = 4
    }
}