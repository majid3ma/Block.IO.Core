using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class AddressData:BaseData {
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
