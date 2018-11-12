using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class GreenTransactionData : BaseData {
        [JsonProperty("green_txs")]
        public List<GreenTxData> GreenTXs { get; set; }
    }

}
