using System.Text.Json.Serialization;

namespace Ensek.API.Models
{
    public class MeterReading
    {
        public string AccountId { get; set; }
        public string MeterReadingDateTime { get; set; }
        public string MeterReadValue { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }

    }
}
