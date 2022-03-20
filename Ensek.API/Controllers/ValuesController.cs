using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ensek.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet(Name = "Get")]
        public string Get(string filename)
        {
            return filename;
        }

    }
}
