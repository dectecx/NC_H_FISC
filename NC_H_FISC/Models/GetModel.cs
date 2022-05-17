using System.Text.Json.Serialization;

namespace NC_H_FISC.Models
{
    public class GetModelReq
    {
        [JsonIgnore]
        public string bankCode { get; set; }
    }

    public class GetModelRsp
    {
        public string bankCode { get; set; }
        public string bankName { get; set; }
        public string telZone { get; set; }
        public string telNo { get; set; }
    }
}
