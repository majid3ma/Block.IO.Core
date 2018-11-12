using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class NetworkFeeData : BaseData {
        [JsonProperty("estimated_network_fee")]
        public double EstimatedNetworkFee { get; set; }
    }
}
