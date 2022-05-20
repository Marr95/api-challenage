using api_challenge.models;
using Microsoft.AspNetCore.Mvc;

namespace api_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyDataController : ControllerBase
    {
        [HttpPost(Name = "PostBodyData")]
        public BodyData postBodyData(BodyData bodyData)
        {
            //voor dit, data in database stoppen
            return bodyData;
        }
    }
}
