namespace RealEstatesManagement.Services
{
    using RealEstatesManagement.Data;
    using RealEstatesManagement.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class RealEstateService
    {
        public RealEstateService(DataManager _dataManager)
        {
            this.DataManager = _dataManager;
        }

        private DataManager DataManager { get; set; }

        /// <summary>
        /// Inserts a new property to the collection of properties or DB
        /// </summary>
        /// <param name="property"></param>
        public void Add(RealEstate property)
        {
            this.DataManager.Properties.Add(property);
        }

        /// <summary>
        /// Retrieves a property by a certain name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public RealEstate GetPropertyByName(string name)
        {
            return this.DataManager.Properties.SingleOrDefault(e => e.Name.ToLower() == name?.ToLower());
        }

        /// <summary>
        /// Retrieves all properties
        /// </summary>
        /// <returns></returns>
        public IList<RealEstate> GetAll()
        {
            return this.DataManager.Properties;
        }
    }
}
