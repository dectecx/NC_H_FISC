namespace NC_H_FISC.Models
{
    public class ModelResult<TReq, TRsp>
    {
        public TReq Req { get; set; }
        public TRsp Rsp { get; set; }
    }
}
