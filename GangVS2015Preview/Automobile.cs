using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangVS2015Preview
{
    internal sealed class Automobile
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Make { get; } = "Toyota";
        public string Model { get; } = "Camry";
        public DateTime ManufactureDate { get; } = DateTime.UtcNow;

        public Automobile()
        {
            // no code
        }

        public Automobile(string make, string model, DateTime manufactureDate)
        {
            this.Make = make;
            this.Model = model;
            this.ManufactureDate = manufactureDate;
        }
    }
}