using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class ReceivedTransactionData : TransactionTxData {
        [JsonProperty("amounts_received")]
        public List<AmountTransferData> AmountsReceived { get; set; }
    }
}
