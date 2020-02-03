using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace BE.RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        public async Task<bool> Get() {
            return true;
        }
    }
}