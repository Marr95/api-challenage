using api_challenge.dal;
using api_challenge.dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyDataController : ControllerBase
    {
        BodyDataDAL bodyDataDAL = new BodyDataDAL();

        [HttpPost(Name = "PostBodyData")]
        public HttpResponseMessage postBodyData(BodyDataDTO bodyData)
        {
            if(bodyDataDAL.postBodyData(bodyData))
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
