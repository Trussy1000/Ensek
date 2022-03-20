using CsvHelper.Configuration.Attributes;

namespace Ensek.API.Models
{
    public class Test
    {
        [Name("ID")]
        public string? ID { get; set; }
        [Name("Name")]
        public string? Name { get; set; }


        //SQL
        public string? SQLID { get; set; }
        public string? SQLNAME { get; set; }


    }
}
