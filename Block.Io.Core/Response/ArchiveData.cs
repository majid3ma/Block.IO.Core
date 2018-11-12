using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class ArchiveData {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("archived")]
        public bool Archived { get; set; }
    }
}
