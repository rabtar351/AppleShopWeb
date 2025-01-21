using AppleStore.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppleStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Document()
        {
            using (var db = new DbAppleTechnicStoreContext())
            {
                return Ok(db.Documents);
            }
        }
    }
}
