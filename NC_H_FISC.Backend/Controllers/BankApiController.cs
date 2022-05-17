using Microsoft.AspNetCore.Mvc;
using NC_H_FISC.Backend.Models;

namespace NC_H_FISC.Backend.Controllers
{
    [ApiController]
    public class BankApiController : ControllerBase
    {
        [Route("QueryOpc")]
        public OpcModelRsp QueryOpc(OpcModelReq req)
        {
            return new OpcModelRsp();
        }
    }
}
