using Microsoft.AspNetCore.Mvc;

namespace ComAp.Sc.Ws.Controllers
{
    [Route("api/[controller]")]
    public class SystemController : ControllerBase
    {
        public SystemController()
        {
        }

        [HttpGet]
        [Route("Status")]
        public IActionResult IsStatusOk()
        {
            return Ok(true);
        }
    }
}