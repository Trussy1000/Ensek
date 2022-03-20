using Microsoft.EntityFrameworkCore;

namespace Ensek.API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account { AccountID = 2344, FirstName = "Tommy", LastName = "Test" },
                new Account { AccountID = 2233, FirstName = "Barry", LastName = "Test" },
                new Account { AccountID = 8766, FirstName = "Sally", LastName = "Test" },
                new Account { AccountID = 2345, FirstName = "Jerry", LastName = "Test" },
                new Account { AccountID = 2346, FirstName = "Ollie", LastName = "Test" },
                new Account { AccountID = 2347, FirstName = "Tara", LastName = "Test" },
                new Account { AccountID = 2348, FirstName = "Tammy", LastName = "Test" },
                new Account { AccountID = 2349, FirstName = "Simon", LastName = "Test" },
                new Account { AccountID = 2350, FirstName = "Colin", LastName = "Test" },
                new Account { AccountID = 2351, FirstName = "Gladys", LastName = "Test" },
                new Account { AccountID = 2352, FirstName = "Greg", LastName = "Test" },
                new Account { AccountID = 2353, FirstName = "Tony", LastName = "Test" },
                new Account { AccountID = 2355, FirstName = "Arthur", LastName = "Test" },
                new Account { AccountID = 2356, FirstName = "Craig", LastName = "Test" },
                new Account { AccountID = 6776, FirstName = "Laura", LastName = "Test" },
                new Account { AccountID = 4534, FirstName = "JOSH", LastName = "TEST" },
                new Account { AccountID = 1234, FirstName = "Freya", LastName = "Test" },
                new Account { AccountID = 1239, FirstName = "Noddy", LastName = "Test" },
                new Account { AccountID = 1240, FirstName = "Archie", LastName = "Test" },
                new Account { AccountID = 1241, FirstName = "Lara", LastName = "Test" },
                new Account { AccountID = 1242, FirstName = "Tim", LastName = "Test" },
                new Account { AccountID = 1243, FirstName = "Graham", LastName = "Test" },
                new Account { AccountID = 1244, FirstName = "Tony", LastName = "Test" },
                new Account { AccountID = 1245, FirstName = "Neville", LastName = "Test" },
                new Account { AccountID = 1246, FirstName = "Jo", LastName = "Test" },
                new Account { AccountID = 1247, FirstName = "Jim", LastName = "Test" },
                new Account { AccountID = 1248, FirstName = "Pam", LastName = "Test" });
        }
    }
}
