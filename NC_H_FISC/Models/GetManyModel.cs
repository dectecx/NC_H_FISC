using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NC_H_FISC.Models
{
    public class GetManyModelReq
    {
        [JsonIgnore]
        public string bankCode { get; set; }
        [JsonIgnore]
        public string telZone { get; set; }
    }

    public class GetManyModelRsp
    {
        public List<GetManyModelData> data { get; set; }
    }

    public class GetManyModelData
    {
        public string bankCode { get; set; }
        public string bankName { get; set; }
        public string telZone { get; set; }
        public string telNo { get; set; }
    }
}
