using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SotrageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public object HelloWorld() 
        {
            return "Hello World";
        }

    }
}
