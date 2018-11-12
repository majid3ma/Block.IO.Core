using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class TransactionData<T> : BaseData where T : TransactionTxData {
        [JsonProperty("txs")]
        public List<T> TXS { get; set; }
    }

}


