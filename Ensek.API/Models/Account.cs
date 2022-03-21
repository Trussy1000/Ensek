using System.Collections.Generic;

namespace Ensek.API.Models
{
    /// <summary>
    /// Accounts for meter readings - properties
    /// </summary>
    public class Account
    {
        public int AccountID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual List<MeterReading> MeterReadings { get; set; }
    }
}




