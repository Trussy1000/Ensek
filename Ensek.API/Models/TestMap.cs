using CsvHelper.Configuration;

namespace Ensek.API.Models
{
    public sealed class Testmap : ClassMap<Test>
    {
        public Testmap()
        {
            Map(m => m.SQLID).Name("ID");
            Map(m => m.SQLNAME).Name("Name");
            //Map(m => m.SQLNAME).ConvertUsing(row => row.GetField<string>("CsvColumn2") + " " + row.GetField<string>("CsvColumn3"));
        }
    }
}
