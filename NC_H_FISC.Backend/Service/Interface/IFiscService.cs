using NC_H_FISC.Backend.Models;

namespace NC_H_FISC.Backend.Service.Interface
{
    public interface IFiscService
    {
        public ModelResult<FiscStatusModelReq, FiscStatusModelRsp> QueryOpc(FiscStatusModelReq req);
    }
}
