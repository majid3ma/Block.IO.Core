using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class ExchangePriceData : BaseData {
        [JsonProperty("prices")]
        public List<PriceData> Proces { get; set; }
    }
    public class PriceData {
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("price_base")]
        public string PriceBase { get; set; }
        [JsonProperty("exchange")]
        public string Exchange { get; set; }
        [JsonProperty("time")]
        public long Time { get; set; }
        public DateTime GetTime() {
            var originTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return originTime.AddSeconds(Time);
        }
    }
}
