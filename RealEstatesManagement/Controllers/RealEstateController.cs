namespace RealEstatesManagement.Controllers
{
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using RealEstatesManagement.Data;
    using RealEstatesManagement.Models;
    using RealEstatesManagement.Models.DTOs;
    using RealEstatesManagement.Services;
    using System;
    using System.Linq;

    [Route("[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private static DataManager _dataManaer = new DataManager();
        private RealEstateService _service = new RealEstateService(_dataManaer);

        public RealEstateController()
        {
        }

        /// <summary>
        /// Endpoint for creating a calendar for a property
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [EnableCors("MyPolicy")]
        public object LeaseOut([FromBody] RealEstateDTO leaseOutModel)
        {
            RealEstate realEstate = null;

            if (ModelState.IsValid)
            {
                realEstate = new RealEstate(leaseOutModel.type, leaseOutModel.name);

                _service.Add(realEstate);
            }

            return realEstate;
        }

        /// <summary>
        /// Endpoint for retrieving information about a range of the calendar
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public object GetPeriodByProperty(DateTime startDate, DateTime endDate, string name)
        {
            RealEstate property = null;

            if (ModelState.IsValid && this._service.GetAll().Any(e => e.Name.ToLower() == name.ToLower()))
            {
                property = this._service.GetPropertyByName(name);
            }

            return property;
        }

        /// <summary>
        /// Endpoint for updating a period of the calendar
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public object UpdatePeriodByProperty(
            DateTime startDate, DateTime endDate, string name, decimal amount, CurrencyTypes currency = CurrencyTypes.BGN)
        {
            RealEstate property = null;

            if (ModelState.IsValid && this._service.GetAll().Any(e => e.Name.ToLower() == name.ToLower()))
            {
                property = this._service.GetPropertyByName(name);

                var availablePeriod = new AvailablePeriod(startDate, endDate, amount, currency);
                availablePeriod.PropertyName = property.Name;

                property.Calendar.Add(availablePeriod);
            }
            
            return property;
        }
    }
}