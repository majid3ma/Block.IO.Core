using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response
{
    public class WithdrawData:BaseData
    {
        [JsonProperty("txid")]
        public string Txid { get; set; }
        [JsonProperty("amount_withdrawn")]
        public double AmountWithdrawn { get; set; }
        [JsonProperty("amount_sent")]
        public double AmountSent { get; set; }
        [JsonProperty("network_fee")]
        public double NetworkFee { get; set; }
        [JsonProperty("blockio_fee")]
        public double BlockIoFee { get; set; }
    }
}
//{
//  "status" : "success",
//  "data" : {
//    "network" : "BTC",
//    "txid" : "198af56de5c756312adaaffd036b460561bc716bd1461e12bb9d2d5b6bc71d74",
//    "amount_withdrawn" : "0.00010952",
//    "amount_sent" : "0.00007000",
//    "network_fee" : "0.00003952",
//    "blockio_fee" : "0.00000000"
//  }
//}