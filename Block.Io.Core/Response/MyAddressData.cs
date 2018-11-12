using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class MyAddressData : BaseData {
        [JsonProperty("addresses")]
        public AddressWithBalanceData[] Addresses { get; set; }
        [JsonProperty("page")]
        public int Page { get; set; }
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
    }
  
}
