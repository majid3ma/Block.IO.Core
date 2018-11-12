using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class AddressBalanceData : BaseData {
        [JsonProperty("available_balance")]
        public double AvailableBalance { get; set; }
        [JsonProperty("pending_received_balance")]
        public double PendingReceivedBalance { get; set; }
        [JsonProperty("balances")]
        public List<AddressWithBalanceData> Balances { get; set; }
    }
}
