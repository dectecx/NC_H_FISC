using System.Text.Json.Serialization;

namespace NC_H_FISC.Models
{
    public class DeleteModelReq
    {
        [JsonIgnore]
        public string bankCode { get; set; }
    }
    public class DeleteModelRsp
    {
    }
}
