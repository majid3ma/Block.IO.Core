using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class AmountTransferData {
        [JsonProperty("recipient")]
        public string Recipient { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}
