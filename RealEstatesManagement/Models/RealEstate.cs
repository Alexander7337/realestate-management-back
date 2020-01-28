namespace RealEstatesManagement.Models
{
    using System;
    using System.Collections.Generic;

    public class RealEstate
    {
        public RealEstate(RealEstateTypes type, string name)
        {
            this.Calendar = new List<AvailablePeriod>();
            this.StartDateLeasing = DateTime.Now;
            this.EndDateLeasing = StartDateLeasing.AddYears(2);
            this.Type = type;
            this.Name = name;
        }

        public int ID { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public RealEstateTypes Type { get; set; } = RealEstateTypes.APARTMENT;

        public IList<AvailablePeriod> Calendar { get; set; }

        public DateTime StartDateLeasing { get; set; }

        public DateTime EndDateLeasing { get; set; }
    }
}
