using Block.Io.Core.Exceptions;
using Block.Io.Core.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace Block.Io.Core {
    public class BlockIO : IBlockIO {
        private string apiKey { get; set; }
        private string Url = "https://block.io/api/v2/";
        public BlockIO(string apikey) {
            apiKey = apikey;
        }
        private T apiCall<T>(string method, NameValueCollection parameter = null) {
            WebClient webClient = new WebClient();
            if (parameter == null)
                parameter = new NameValueCollection();
            parameter.Add("api_key", apiKey);
            var jsonContent = webClient.DownloadString($"{Url}{method}/?{parameter.ToString()}");
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonContent);
            return result;
        }

        public Address GetNewAddressWithRandomLabel() {
            return apiCall<Address>(Method.GetNewAddress);
        }

        public Address GetNewAddressWithGivenLabel(string label) {
            var parameter = new NameValueCollection();
            parameter.Add("label", label);
            return apiCall<Address>(Method.GetNewAddress, parameter);
        }
        public Address GetAddressWithAddressType(string addressType) {
            var parameter = new NameValueCollection();
            parameter.Add("address_type", addressType);
            return apiCall<Address>(Method.GetNewAddress, parameter);
        }

        public Balance GetBalance() {
            return apiCall<Balance>(Method.GetBalance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns>List of Addresses With Balance</returns>
        public AddressWithBalance GerMyAresses(int page = 1) {
            var parameter = new NameValueCollection();
            parameter.Add("page", page.ToString());
            return apiCall<AddressWithBalance>(Method.GetMyAddresses, parameter);
        }

        public AddressBalance GetAddressBalanceWithAddress(params string[] addresses) {
            var parameter = new NameValueCollection();
            parameter.Add("addresses", string.Join(",", addresses));
            return apiCall<AddressBalance>(Method.GetAddressBalance, parameter);
        }

        public AddressBalance GetAddressBalanceWithLabels(params string[] labels) {
            var parameter = new NameValueCollection();
            parameter.Add("labels", string.Join(",", labels));
            return apiCall<AddressBalance>(Method.GetAddressBalance, parameter);
        }

        public LabelAddress GetAddressByLabel(string label) {
            var parameter = new NameValueCollection();
            parameter.Add("label", label);
            return apiCall<LabelAddress>(Method.GetAddressBalance, parameter);
        }
        public Withdraw Withdraw(Dictionary<string, double> addressAmount, string pin) {
            if (addressAmount.Count > 2500)
                throw new MaximumInputException("you can't Withdraw and send amounts to more than 2500 addresses");
            var parameter = new NameValueCollection();
            parameter.Add("amounts", string.Join(",", addressAmount.Values));
            parameter.Add("to_addresses", string.Join(",", addressAmount.Keys));
            parameter.Add("pin", pin);
            return apiCall<Withdraw>(Method.Withdraw, parameter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transferAddress">from address,to address,amount</param>
        /// <param name="pin"></param>
        /// <returns></returns>
        public Withdraw WithdrawFromAddresses(List<Tuple<string, string, double>> transferAddress, string pin) {
            if (transferAddress.Count > 2500)
                throw new MaximumInputException("you can't Withdraw and send amounts to more than 2500 addresses");
            var parameter = new NameValueCollection();
            parameter.Add("from_addresses", string.Join(",", transferAddress.Select(m => m.Item1)));
            parameter.Add("to_addresses", string.Join(",", transferAddress.Select(m => m.Item2)));
            parameter.Add("amounts", string.Join(",", transferAddress.Select(m => m.Item3)));
            parameter.Add("pin", pin);
            return apiCall<Withdraw>(Method.WithdrawFromAddresses, parameter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transferLabels">from label,to label, amount</param>
        /// <param name="pin"></param>
        public Withdraw WithdrawFromLabel(List<Tuple<string, string, double>> transferLabels, string pin) {
            if (transferLabels.Count > 2500)
                throw new MaximumInputException("you can't Withdraw and send amounts to more than 2500 addresses");
            var parameter = new NameValueCollection();
            parameter.Add("from_labels", string.Join(",", transferLabels.Select(m => m.Item1)));
            parameter.Add("to_labels", string.Join(",", transferLabels.Select(m => m.Item2)));
            parameter.Add("amounts", string.Join(",", transferLabels.Select(m => m.Item3)));
            parameter.Add("pin", pin);
            return apiCall<Withdraw>(Method.WithdrawFromAddresses, parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transferLabels">from label,to address, amount</param>
        /// <param name="pin"></param>
        public Withdraw WithdrawFromLabelToAddress(List<Tuple<string, string, double>> transferLabels, string pin) {
            if (transferLabels.Count > 2500)
                throw new MaximumInputException("you can't Withdraw and send amounts to more than 2500 addresses");
            var parameter = new NameValueCollection();
            parameter.Add("from_labels", string.Join(",", transferLabels.Select(m => m.Item1)));
            parameter.Add("to_addresses", string.Join(",", transferLabels.Select(m => m.Item2)));
            parameter.Add("amounts", string.Join(",", transferLabels.Select(m => m.Item3)));
            parameter.Add("pin", pin);
            return apiCall<Withdraw>(Method.WithdrawFromAddresses, parameter);
        }

        public NetworkFee GetNetworkFeeEstimate(Dictionary<string, double> addressAmount) {
            if (addressAmount.Count > 2500)
                throw new MaximumInputException("you can't Withdraw and send amounts to more than 2500 addresses");
            var parameter = new NameValueCollection();
            parameter.Add("amounts", string.Join(",", addressAmount.Values));
            parameter.Add("to_addresses", string.Join(",", addressAmount.Keys));
            return apiCall<NetworkFee>(Method.GetNetworkFeeEstimate, parameter);
        }

        public ArchiveAddress SetArchiveAddresses(List<string> addresses) {
            var parameter = new NameValueCollection();
            parameter.Add("addresses", string.Join(",", addresses));
            return apiCall<ArchiveAddress>(Method.ArchiveAddresses, parameter);
        }

        public ArchiveAddress SetUnArchiveAddresses(List<string> addresses) {
            var parameter = new NameValueCollection();
            parameter.Add("addresses", string.Join(",", addresses));
            return apiCall<ArchiveAddress>(Method.UnarchiveAddress, parameter);
        }

        public ArchiveAddress GetMyArchivedAddresses() {
            return apiCall<ArchiveAddress>(Method.GetMyAddresses);
        }

        public Price GetCurrentPrice(string currency = null) {
            if (string.IsNullOrEmpty(currency))
                return apiCall<Price>(Method.GetCurrentPrice);
            var parameter = new NameValueCollection();
            parameter.Add("price_base", currency);
            return apiCall<Price>(Method.GetCurrentPrice, parameter);
        }

        public GreenTransaction GetGreenTransaction(List<string> transactionIds) {
            var parameter = new NameValueCollection();
            parameter.Add("transaction_ids", string.Join(",", transactionIds));
            return apiCall<GreenTransaction>(Method.IsGreenTransaction, parameter);
        }

        public SentTransaction GetSendTransaction() {
            return getTransaction<SentTransaction>();
        }

        public ReceivedTransaction GetReceivedTransaction() {
            return getTransaction<ReceivedTransaction>("received");
        }

        public SentTransaction GetSendTransaction(List<string> addresses) {
            return getTransaction<SentTransaction>(addresses: addresses);
        }

        public ReceivedTransaction GetReceivedTransaction(List<string> addresses) {
            return getTransaction<ReceivedTransaction>("received", addresses: addresses);
        }

        public SentTransaction GetSendTransaction(string beforeTx, List<string> addresses) {
            return getTransaction<SentTransaction>(beforeTx: beforeTx, addresses: addresses);
        }

        public ReceivedTransaction GetReceivedTransaction(string beforeTx, List<string> addresses) {
            return getTransaction<ReceivedTransaction>("received", beforeTx: beforeTx, addresses: addresses);
        }

        public SentTransaction GetSendTransactionBeforeTxId(string beforeTx) {
            return getTransaction<SentTransaction>(beforeTx: beforeTx);
        }

        public ReceivedTransaction GetReceivedTransactionBeforeTxId(string beforeTx) {
            return getTransaction<ReceivedTransaction>("received", beforeTx: beforeTx);
        }

        public SentTransaction GetSendTransactionWithUserId(List<int> user_ids) {
            return getTransaction<SentTransaction>(user_ids: user_ids);
        }

        public ReceivedTransaction GetReceivedTransactionWithUserId(List<int> user_ids) {
            return getTransaction<ReceivedTransaction>("received", user_ids: user_ids);
        }

        public SentTransaction GetSendTransactionWithLabels(List<string> labels) {
            return getTransaction<SentTransaction>(labels: labels);
        }

        public ReceivedTransaction GetReceivedTransactionWithLabels(List<string> labels) {
            return getTransaction<ReceivedTransaction>("received", labels: labels);
        }

        public RawTransaction GetRawTransaction(string txtId) {
            var parameter = new NameValueCollection();
            parameter.Add("txid", txtId);
            return apiCall<RawTransaction>(Method.GetRawTransaction, parameter);
        }

        private T getTransaction<T>(string type = "sent", string beforeTx = null, List<string> addresses = null, List<int> user_ids = null, List<string> labels = null) {
            var parameter = new NameValueCollection();
            parameter.Add("type", type);
            if (!string.IsNullOrEmpty(beforeTx))
                parameter.Add("before_tx", beforeTx);
            if (addresses != null && addresses.Count > 0)
                parameter.Add("addresses", string.Join(",", addresses));
            if (user_ids != null && user_ids.Count > 0)
                parameter.Add("user_ids", string.Join(",", user_ids));
            if (labels != null && labels.Count > 0)
                parameter.Add("labels", string.Join(",", labels));
            return apiCall<T>(Method.GetTransactions, parameter);
        }
    }
    public class Method {
        public const string GetNewAddress = "get_new_address";
        public const string GetBalance = "get_balance";
        public const string GetMyAddresses = "get_my_addresses";
        public const string GetAddressBalance = "get_address_balance";
        public const string GetAddressBylabel = "get_address_by_label";
        public const string Withdraw = "withdraw";
        public const string WithdrawFromAddresses = "withdraw_from_addresses";
        public const string WithdrawFromLabels = "withdraw_from_labels";
        public const string GetNetworkFeeEstimate = "get_network_fee_estimate";
        public const string ArchiveAddresses = "archive_addresses";
        public const string UnarchiveAddress = "unarchive_address";
        public const string GetMyArchivedAddresses = "get_my_archived_addresses";
        public const string GetCurrentPrice = "get_current_price";
        public const string IsGreenTransaction = "is_green_transaction";
        public const string GetTransactions = "get_transactions";
        public const string GetRawTransaction = "get_raw_transaction";
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