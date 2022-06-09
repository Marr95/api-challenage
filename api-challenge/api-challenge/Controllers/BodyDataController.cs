using api_challenge.dal;
using api_challenge.dto;
using api_challenge.models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

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

        [HttpGet(Name = "GetBodyData")]
        public Object getBodyData()
        {
            List<BodyData> bodyDatas = bodyDataDAL.GetBodyDatas();
            if(bodyDatas != null)
            {
                return Ok(bodyDatas);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
