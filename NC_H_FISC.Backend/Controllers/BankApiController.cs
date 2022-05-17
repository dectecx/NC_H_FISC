using Microsoft.AspNetCore.Mvc;
using NC_H_FISC.Backend.Models;
using NC_H_FISC.Backend.Service;
using NC_H_FISC.Backend.Service.Interface;
using System;

namespace NC_H_FISC.Backend.Controllers
{
    [ApiController]
    public class BankApiController : ControllerBase
    {
        private readonly IFiscService fiscService;

        public BankApiController()
        {
            // fiscService = new FiscService();     // 正式版
            fiscService = new MockFiscService();    // 測試版
        }


        [Route("QueryOpc")]
        public ModelResult<OpcModelReq, OpcModelRsp> QueryOpc(OpcModelReq req)
        {
            try
            {
                var fiscResp = fiscService.QueryOpc(new FiscStatusModelReq());
                if (fiscResp.Success)
                {
                    var result = new OpcModelRsp
                    {
                        bankCode = fiscResp.Data.Rsp.bankCode,
                        fiscStatus = fiscResp.Data.Rsp.fiscStatus,
                        bankStatus = fiscResp.Data.Rsp.bankStatus,
                        appStatus = fiscResp.Data.Rsp.appStatus
                    };
                    return BuildResponse<OpcModelReq, OpcModelRsp>(true, null, req, result);
                }
                else
                {
                    return BuildResponse<OpcModelReq, OpcModelRsp>(false, fiscResp.ErrorMessage, req, null);
                }
            }
            catch (Exception ex)
            {
                return BuildResponse<OpcModelReq, OpcModelRsp>(false, ex.InnerException?.Message ?? ex.Message, null, null);
            }
        }

        private ModelResult<TReq, TRsp> BuildResponse<TReq, TRsp>(bool success, string errorMsg, TReq req, TRsp rsp)
        {
            return new ModelResult<TReq, TRsp>
            {
                Success = success,
                ErrorMessage = errorMsg,
                Data = new ModelData<TReq, TRsp>
                {
                    Req = req,
                    Rsp = rsp
                }
            };
        }
    }
}
