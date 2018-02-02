using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ListenThen.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Values")]
    public class ValuesController : Controller
    {

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public List<string> Get()
        {
            return new List<string> { "OI", "A VIDA", "É UMA DOIDEIRA" };
        }
    }
}