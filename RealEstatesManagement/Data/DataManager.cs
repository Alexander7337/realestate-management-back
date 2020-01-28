namespace RealEstatesManagement.Data
{
    using RealEstatesManagement.Models;
    using System.Collections.Generic;

    public class DataManager
    {
        public DataManager()
        {
            this.Properties = new List<RealEstate>();
        }

        public IList<RealEstate> Properties { get; set; }
    }
}
