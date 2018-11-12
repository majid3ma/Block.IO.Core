using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class BalanceData {
        [JsonProperty("available_balance")]
        public double AvailableBalance { get; set; }
        [JsonProperty("pending_received_balance")]
        public double PendinvPendingReceivedBalance { get; set; }
    }
}
