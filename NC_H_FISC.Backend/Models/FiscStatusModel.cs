namespace NC_H_FISC.Backend.Models
{
    public class FiscStatusModelReq
    {
        public string txnType { get; set; }
        public string txnCode { get; set; }
        public string txnDateTime { get; set; }
        public string txnStan { get; set; }
        public string returnCode { get; set; }
        public string bankCode { get; set; }
    }

    public class FiscStatusModelRsp
    {
        public string txnType { get; set; }
        public string txnCode { get; set; }
        public string txnDateTime { get; set; }
        public string txnStan { get; set; }
        public string returnCode { get; set; }
        public string bankCode { get; set; }
        public string fiscStatus { get; set; }
        public string bankStatus { get; set; }
        public string appStatus { get; set; }
    }
}
