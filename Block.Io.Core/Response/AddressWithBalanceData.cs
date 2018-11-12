using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response
{
    public class AddressWithBalanceData:BaseData {
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("pending_received_balance")]
        public double PendingReceivedBalance { get; set; }
        [JsonProperty("available_balance")]
        public double AvailableBalance { get; set; }
        [JsonProperty("is_segwit")]
        public bool IsSegwit { get; set; }
    }
}
