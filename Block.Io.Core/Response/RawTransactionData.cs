using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public class RawTransactionData : BaseData {
        [JsonProperty("txid")]
        public string TxId { get; set; }
        [JsonProperty("blockhash")]
        public string Blockhash { get; set; }
        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }
        [JsonProperty("time")]
        public long Time { get; set; }
        [JsonProperty("inputs")]
        public List<RawTransactionInputData> Inputs { get; set; }
        [JsonProperty("outputs")]
        public List<RawTransactionInputData> Outputs { get; set; }
        [JsonProperty("tx_hex")]
        public string TXHex { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("vsize")]
        public int VSize { get; set; }
        [JsonProperty("version")]
        public int Version { get; set; }
        [JsonProperty("locktime")]
        public int LockTime { get; set; }
    }

    public class RawTransactionInputData {
        [JsonProperty("input_no")]
        public int InputNo { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("script")]
        public string Script { get; set; }
        [JsonProperty("withness")]
        public string[] Withness { get; set; }
        [JsonProperty("from_output")]
        public RawTransactionFromOutputData FromOutput { get; set; }


    }
    public class RawTransactionFromOutputData {
        [JsonProperty("txid")]
        public string TxId { get; set; }
        [JsonProperty("output_no")]
        public int OutputNo { get; set; }
    }
    public class RawTransactionOutputData {
        [JsonProperty("output_no")]
        public int OutputNo { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("script")]
        public string Script { get; set; }

    }

}