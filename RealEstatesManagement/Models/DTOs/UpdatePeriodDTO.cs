namespace RealEstatesManagement.Models.DTOs
{
    using System;

    public class UpdatePeriodDTO
    {
        public string name { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public decimal amount { get; set; }

        public CurrencyTypes currency { get; set; } = CurrencyTypes.BGN;
    }
}
