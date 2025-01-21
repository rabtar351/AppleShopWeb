using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Server.Context;

namespace Web_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Document()
        {
            using (var db = new Test11234Context())
            {
                return Ok(db.Documents);
            }
        }
    }
}
