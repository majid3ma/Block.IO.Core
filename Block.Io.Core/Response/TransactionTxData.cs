using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public abstract class TransactionTxData {
        [JsonProperty("txid")]
        public string TxId { get; set; }
        [JsonProperty("from_green_address")]
        public bool FromGreenAddress { get; set; }
        [JsonProperty("time")]
        public long Time { get; set; }
        [JsonProperty("senders")]
        public string[] Senders { get; set; }
        [JsonProperty("confidence")]
        public double? Confidence { get; set; }
        [JsonProperty("propagated_by_nodes")]
        public double? PropagatedByNodes { get; set; }
    }
}
