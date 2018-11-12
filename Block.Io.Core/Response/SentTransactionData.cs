using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class SentTransactionData : TransactionTxData {
        [JsonProperty("amounts_sent")]
        public List<AmountTransferData> AmountSent { get; set; }
        [JsonProperty("total_amount_sent")]
        public double TotalAmountSent { get; set; }
    }
}
