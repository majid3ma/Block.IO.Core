using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class ArchiveAddressData : BaseData {
        [JsonProperty("addresses")]
        public List<ArchiveData> Addresses { get; set; }
    }

}
