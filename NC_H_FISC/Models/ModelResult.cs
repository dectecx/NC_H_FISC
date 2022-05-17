namespace NC_H_FISC.Models
{
    public class ModelResult<TReq, TRsp>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public ModelData<TReq, TRsp> Data { get; set; }
    }

    public class ModelData<TReq, TRsp>
    {
        public TReq Req { get; set; }
        public TRsp Rsp { get; set; }
    }
}
