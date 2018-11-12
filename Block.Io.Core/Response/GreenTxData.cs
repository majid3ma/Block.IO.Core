using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response
{
    public class GreenTxData : BaseData {
        [JsonProperty("txid")]
        public string TxId { get; set; }
    }
}
