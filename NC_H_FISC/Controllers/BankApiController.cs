using Microsoft.AspNetCore.Mvc;
using NC_H_FISC.Models;

namespace NC_H_FISC.Controllers
{
    [ApiController]
    public class BankApiController : ControllerBase
    {
        [Route("api/v1/fisc/bank")]
        [HttpPost]
        public InsertModelRsp Insert(InsertModelReq req)
        {
            return new InsertModelRsp();
        }

        [Route("api/v1/fisc/bank/{bankCode}")]
        [HttpGet]
        public GetModelRsp Get(GetModelReq req)
        {
            return new GetModelRsp();
        }

        [Route("api/v1/fisc/bank")]
        [HttpGet]
        public GetManyModelRsp GetMany(GetManyModelReq req)
        {
            return new GetManyModelRsp();
        }

        [Route("api/v1/fisc/bank")]
        [HttpDelete]
        public DeleteModelRsp Delete(DeleteModelReq req)
        {
            return new DeleteModelRsp();
        }

        [Route("api/v1/fisc/bank")]
        [HttpPut]
        public UpdateModelRsp Update(UpdateModelReq req)
        {
            return new UpdateModelRsp();
        }
    }
}
