namespace NC_H_FISC.Backend.Models
{
    public class OpcModelReq
    {
        public string bankCode { get; set; }
    }

    public class OpcModelRsp
    {
        public string bankCode { get; set; }
        public string fiscStatus { get; set; }
        public string bankStatus { get; set; }
        public string appStatus { get; set; }
    }
}
