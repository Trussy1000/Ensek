using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ensek.API.Models
{
    public class MeterReading
    {
        [Key]
        public Guid Id { get; set; }
        public string AccountId { get; set; }
        public string MeterReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }

    }
}
