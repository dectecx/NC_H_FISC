using NC_H_FISC.Backend.Models;
using NC_H_FISC.Backend.Service.Interface;

namespace NC_H_FISC.Backend.Service
{
    public class MockFiscService : IFiscService
    {
        public ModelResult<FiscStatusModelReq, FiscStatusModelRsp> QueryOpc(FiscStatusModelReq req)
        {
            return new ModelResult<FiscStatusModelReq, FiscStatusModelRsp>
            {
                Success = true,
                ErrorMessage = null,
                Data = new ModelData<FiscStatusModelReq, FiscStatusModelRsp>
                {
                    Req = new FiscStatusModelReq
                    {
                        txnType = "0200",
                        txnCode = "3201",
                        txnDateTime = "20220428120000",
                        txnStan = "0000001",
                        returnCode = "0000",
                        bankCode = "987"
                    },
                    Rsp = new FiscStatusModelRsp
                    {
                        txnType = "0210",
                        txnCode = "3201",
                        txnDateTime = "20220428120000",
                        txnStan = "0000001",
                        returnCode = "0001",
                        bankCode = "987",
                        fiscStatus = "1",
                        bankStatus = "1",
                        appStatus = "1"
                    }
                }
            };
        }
    }
}
