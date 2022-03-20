using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

namespace Ensek.API.Models
{
    public class MeterReadingRetrieve
    {
            public string AccountId { get; set; }
            public string MeterReadingDateTime { get; set; }
            public string MeterReadValue { get; set; }

            

        

    }
}
