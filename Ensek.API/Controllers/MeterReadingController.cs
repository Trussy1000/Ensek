﻿using Microsoft.AspNetCore.Http;
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

namespace Ensek.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeterReadingController : ControllerBase
    {
        [HttpGet("Seed_data")]
        public string SeedCSVValues(string filename)
        {
            //Get the csv data and then use this to insert into the entity framework
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
                        var record = csv.GetRecord<MeterReading>();

                        //get the meter reading information and seed the database

                        // public int AccountId { get; set; }
                        // public DateTime MeterReadingDateTime { get; set; }
                       // public int MeterReadValue { get; set; }

                        int AccountId = Convert.ToInt32(record.AccountId);
                        DateTime MeterReadingDateTime = Convert.ToDateTime(record.MeterReadingDateTime);
                        int MeterReadValue = Convert.ToInt32(record.MeterReadValue);

                        //insert these values into the database - open a connection before here and then enter the information

                          
                    }
                   
                }
            }
            return "";
        }

        [HttpPost("meter_reading_uploads")]
        public string LoadCSVValues(string filename)
        {
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
                        var record = csv.GetRecord<MeterReading>();

                        int ID = Convert.ToInt32(record.AccountId);
                        DateTime readdate = Convert.ToDateTime(record.MeterReadingDateTime);
                        int val = Convert.ToInt32(record.MeterReadValue);

                        //insert these values into the database - open a connection before here and then enter the information

                        //does this store correctly?
                        if(reclist.Contains(ID.ToString() + val.ToString()))
                        {
                            //Already entered - ignore and move onto the next item
                            notprocesscount++;
                        }
                        else
                        {
                            //Must have ID and Name
                            if (ID == 0 && val == 0)
                            {
                                notprocesscount++;
                            }
                            else if (ID != 0 && val == 0)
                            {
                                notprocesscount++;
                            }
                            else if (ID == 0 && val != 0)
                            {
                                notprocesscount++;
                            }

                            //check reading is not negative
                            if(val > 0)
                            {
                                //Check reading is 5 digits

                            }
                            else
                            {
                                notprocesscount++;
                            }
                        }

                       
                        //var meterread = db.Set<C>();
                        //customers.Add(new Customer { CustomerId = id, Name = "John Doe" });

                        // Do something with the record.
                        //record.ID
                        //record.Name




                        //Account ID neds to be valid
                        //What makes the account ID valid, no strings?

                        //Reading values should be in format NNNNN
                        //Check that it matches this format.

                        // reclist.Add(ID + Name);
                    }
                    if(reclist.Count > 0)
                    {

                    }
                }
                return "Number of readings processed - " + processcount + " Number of readings not processed - " + notprocesscount;
            }


           /* using (var reader = new StreamReader(filename))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                };

                using (var csvRead = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    try
                    {
                        
                        //var records = csvRead.GetRecords<Test>().ToList();
                        var records = csvRead.GetRecords<Test>();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    //Insert the date into the database now

                    
                    
                    using (var csv = new CsvReader(reader, config))
                    {
                        var records = csv.GetRecords<Foo>();
                    }

                }
            }*/

            /*     List<string> listA = new List<string>();
             List<string> listB = new List<string>();
             while (!reader.EndOfStream)
             {
                 var line = reader.ReadLine();
                 var values = line.Split(','); ;

                 listA.Add(values[0]);
                 listA.Add(values[1]);
                 listA.Add(values[2]);
                 listA.Add(values[3]);
             }
         }*/
            
          //  return filename;
        }
    }
}