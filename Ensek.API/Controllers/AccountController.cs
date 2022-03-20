using Ensek.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ensek.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MeterReadingContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        //Create context
        //And check that data is there for use
        public AccountController(MeterReadingContext context)
        {
            _context = context;

            //check if DB has been created - if not fill with sample data in seed function
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<Account> GetAllAccounts()
        {
            return _context.Accounts.ToArray();
        }

        /// <summary>
        /// Allows entry of a new account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
       [HttpPost]
        public async Task<ActionResult<Account>> PostProduct([FromBody] Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetAccount",
                new { id = account.AccountID },
                account
            );
        }


    }
}
