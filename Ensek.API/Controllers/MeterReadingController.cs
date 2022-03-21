using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Ensek.API.Models;
using System.Data.SqlClient;
using System.Collections;
using System;
using Ensek.API.Classes;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Ensek.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeterReadingController : ControllerBase
    {

        private readonly MeterReadingContext _context;

        /// <summary>
        /// Controller constructor to initialise the context for the model information
        /// </summary>
        /// <param name="context"></param>
        //Create context
        //And check that data is there for use
        public MeterReadingController(MeterReadingContext context)
        {
            _context = context;

            //check if DB has been created - if not fill with sample data in seed function
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<MeterReading> GetAllReadings()
        {
            return _context.MeterReading.ToArray();
        }

        /// <summary>
        /// Validate the entered data.
        /// Check if the accountID and meter read value are numeric.
        /// Check that there is an accountID and meter read value
        /// Meter reading length has to have a length of 5 digits.
        /// </summary>
        /// <param name="reading"></param>
        /// <returns></returns>
        private bool ValidateData(MeterReading reading)
        {
            //Check the value is numeric
            if (!(Regex.IsMatch(reading.AccountId, @"^\d+$")))
            {
                return false;
            }

            if (!(Regex.IsMatch(reading.MeterReadValue, @"^\d+$")))
            {
                return false;
            }

            //Check AccountID
            if (Convert.ToInt32(reading.AccountId) <= 0)
            {
                return false;
            }

            //Cannot have negative or empty read value
            if (Convert.ToInt32(reading.MeterReadValue) <= 0)
            {
                return false;
            }

            //reading values must be in format NNNNN
            if (reading.MeterReadValue.Length != 5)
            {
                return false;

            }
            return true;
        }

        /// <summary>
        /// Store the values sent in through filename reference within query parameters on post.
        /// </summary>
        /// <param name="queryParameters"></param>
        [HttpPost("meter-reading-uploads")]
        public async void LoadCSVValues([FromQuery] QueryParameters queryParameters)
        {
            string filename = queryParameters.filename;
            if (!(String.IsNullOrEmpty(filename)))
            {
                MeterReading reading = new MeterReading();

                int processcount = 0;
                int notprocesscount = 0;
                using (var reader = new StreamReader(filename))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        PrepareHeaderForMatch = args => args.Header.ToLower(),
                    };

                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        ArrayList reclist = new ArrayList();

                        while (csv.Read())
                        {
                            var record = csv.GetRecord<MeterReadingRetrieve>();

                            reading.Id = Guid.NewGuid();
                            reading.AccountId = record.AccountId;
                            reading.MeterReadingDateTime = record.MeterReadingDateTime;
                            reading.MeterReadValue = record.MeterReadValue;

                            //Check that the current account and meter reading combination has not been entered before.
                            if (reclist.Contains(reading.AccountId.ToString() + reading.MeterReadValue.ToString()))
                            {
                                notprocesscount++;
                            }
                            else
                            {
                                //Data is valid, store the data
                                if (ValidateData(reading))
                                {
                                    processcount++;
                                    _context.MeterReading.Add(reading);
                                    await _context.SaveChangesAsync();

                                    processcount++;
                                    reclist.Add(reading.AccountId.ToString() + reading.MeterReadValue.ToString());
                                }
                                else
                                {
                                    notprocesscount++;
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
