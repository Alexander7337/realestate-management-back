namespace RealEstatesManagement.Models
{
    using Newtonsoft.Json;
    using System;

    public class AvailablePeriod
    {
        public AvailablePeriod(DateTime startDate, DateTime endDate, decimal amount, CurrencyTypes currency)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Amount = amount;
            this.Currency = currency;
        }

        public int ID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Amount { get; set; }

        public CurrencyTypes Currency { get; set; }

        public string PropertyName { get; set; }

        //TODO: resolve the circular reference
        //[JsonIgnore]
        //public virtual RealEstate Property { get; set; }

        public override string ToString()
        {
            return this.Amount + " " + this.Currency;
        }
    }
}
