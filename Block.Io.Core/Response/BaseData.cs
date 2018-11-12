using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public abstract class BaseData {
        [JsonProperty("network")]
        public string Network { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
    }
}
