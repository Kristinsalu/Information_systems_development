using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarsAndPeople.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string? Manufacturer { get; set; }
        public string? ModelName { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
    }
}