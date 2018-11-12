using Block.Io.Core.Exceptions;
using Block.Io.Core.Response;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Block.Io.Core
{
    public class BlockIO : IBlockIO
    {
        private string apiKey { get; set; }
        private string Url = "https://block.io/api/v2/";
        public BlockIO(string apikey)
        {
            apiKey = apikey;
        }

        public async Task<Address> GetNewAddressWithRandomLabelAsync() => await apiCallAsync<Address>(MethodName.GetNewAddress);

        public async Task<Address> GetNewAddressWithGivenLabelAsync(string label)
        {
            var parameter = new NameValueCollection();
            parameter.Add("label", label);
            return await apiCallAsync<Address>(MethodName.GetNewAddress, parameter);
        }
        public async Task<Address> GetAddressWithAddressTypeAsync(string addressType)
        {
            var parameter = new NameValueCollection();
            parameter.Add("address_type", addressType);
            return await apiCallAsync<Address>(MethodName.GetNewAddress, parameter);
        }

        public async Task<Balance> GetBalanceAsync() => await apiCallAsync<Balance>(MethodName.GetBalance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns>List of Addresses With Balance</returns>
        public async Task<AddressWithBalance> GetMyAressesAsync(int page = 1)
        {
            var parameter = new NameValueCollection();
            parameter.Add("page", page.ToString());
            return await apiCallAsync<AddressWithBalance>(MethodName.GetMyAddresses, parameter);
        }

        public async Task<AddressBalance> GetAddressBalanceWithAddressAsync(params string[] addresses)
        {
            var parameter = new NameValueCollection();
            parameter.Add("addresses", string.Join(",", addresses));
            return await apiCallAsync<AddressBalance>(MethodName.GetAddressBalance, parameter);
        }

        public async Task<AddressBalance> GetAddressBalanceWithLabelsAsync(params string[] labels)
        {
            var parameter = new NameValueCollection();
            parameter.Add("labels", string.Join(",", labels));
            return await apiCallAsync<AddressBalance>(MethodName.GetAddressBalance, parameter);
        }

        public async Task<LabelAddress> GetAddressByLabelAsync(string label)
        {
            var parameter = new NameValueCollection();
            parameter.Add("label", label);
            return await apiCallAsync<LabelAddress>(MethodName.GetAddressBalance, parameter);
        }
        public async Task<Withdraw> WithdrawAsync(Dictionary<string, double> addressAmount, string pin)
        {
            if (addressAmount.Count > 2500)
                throw new MaximumInputException("you can't Withdraw and send amounts to more than 2500 addresses");
            var parameter = new NameValueCollection();
            parameter.Add("amounts", string.Join(",", addressAmount.Values));
            parameter.Add("to_addresses", string.Join(",", addressAmount.Keys));
            parameter.Add("pin", pin);
            return await apiCallAsync<Withdraw>(MethodName.Withdraw, parameter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transferAddress">from address,to address,amount</param>
        /// <param name="pin"></param>
        /// <returns></returns>
        public async Task<Withdraw> WithdrawFromAddressesAsync(IEnumerable<Tuple<string, string, double>> transferAddress, string pin)
        {
            if (transferAddress.Count() > 2500)
                throw new MaximumInputException("you can't Withdraw and send amounts to more than 2500 addresses");
            var parameter = new NameValueCollection();
            parameter.Add("from_addresses", string.Join(",", transferAddress.Select(m => m.Item1)));
            parameter.Add("to_addresses", string.Join(",", transferAddress.Select(m => m.Item2)));
            parameter.Add("amounts", string.Join(",", transferAddress.Select(m => m.Item3)));
            parameter.Add("pin", pin);
            return await apiCallAsync<Withdraw>(MethodName.WithdrawFromAddresses, parameter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transferLabels">from label,to label, amount</param>
        /// <param name="pin"></param>
        public async Task<Withdraw> WithdrawFromLabelAsync(IEnumerable<Tuple<string, string, double>> transferLabels, string pin)
        {
            if (transferLabels.Count() > 2500)
                throw new MaximumInputException("you can't Withdraw and send amounts to more than 2500 addresses");
            var parameter = new NameValueCollection();
            parameter.Add("from_labels", string.Join(",", transferLabels.Select(m => m.Item1)));
            parameter.Add("to_labels", string.Join(",", transferLabels.Select(m => m.Item2)));
            parameter.Add("amounts", string.Join(",", transferLabels.Select(m => m.Item3)));
            parameter.Add("pin", pin);
            return await apiCallAsync<Withdraw>(MethodName.WithdrawFromAddresses, parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transferLabels">from label,to address, amount</param>
        /// <param name="pin"></param>
        public async Task<Withdraw> WithdrawFromLabelToAddressAsync(IEnumerable<Tuple<string, string, double>> transferLabels, string pin)
        {
            if (transferLabels.Count() > 2500)
                throw new MaximumInputException("you can't Withdraw and send amounts to more than 2500 addresses");
            var parameter = new NameValueCollection();
            parameter.Add("from_labels", string.Join(",", transferLabels.Select(m => m.Item1)));
            parameter.Add("to_addresses", string.Join(",", transferLabels.Select(m => m.Item2)));
            parameter.Add("amounts", string.Join(",", transferLabels.Select(m => m.Item3)));
            parameter.Add("pin", pin);
            return await apiCallAsync<Withdraw>(MethodName.WithdrawFromAddresses, parameter);
        }

        public async Task<NetworkFee> GetNetworkFeeEstimateAsync(Dictionary<string, double> addressAmount)
        {
            if (addressAmount.Count > 2500)
                throw new MaximumInputException("you can't Withdraw and send amounts to more than 2500 addresses");
            var parameter = new NameValueCollection();
            parameter.Add("amounts", string.Join(",", addressAmount.Values));
            parameter.Add("to_addresses", string.Join(",", addressAmount.Keys));
            return await apiCallAsync<NetworkFee>(MethodName.GetNetworkFeeEstimate, parameter);
        }

        public async Task<ArchiveAddress> SetArchiveAddressesAsync(IEnumerable<string> addresses)
        {
            var parameter = new NameValueCollection();
            parameter.Add("addresses", string.Join(",", addresses));
            return await apiCallAsync<ArchiveAddress>(MethodName.ArchiveAddresses, parameter);
        }

        public async Task<ArchiveAddress> SetUnArchiveAddressesAsync(IEnumerable<string> addresses)
        {
            var parameter = new NameValueCollection();
            parameter.Add("addresses", string.Join(",", addresses));
            return await apiCallAsync<ArchiveAddress>(MethodName.UnarchiveAddress, parameter);
        }

        public async Task<ArchiveAddress> GetMyArchivedAddressesAsync() => await apiCallAsync<ArchiveAddress>(MethodName.GetMyAddresses);

        public async Task<Price> GetCurrentPriceAsync(string currency = null)
        {
            if (string.IsNullOrEmpty(currency))
                return await apiCallAsync<Price>(MethodName.GetCurrentPrice);
            var parameter = new NameValueCollection();
            parameter.Add("price_base", currency);
            return await apiCallAsync<Price>(MethodName.GetCurrentPrice, parameter);
        }

        public async Task<GreenTransaction> GetGreenTransactionAsync(IEnumerable<string> transactionIds)
        {
            var parameter = new NameValueCollection();
            if (transactionIds == null || transactionIds.Count() < 1)
                throw new InitializationException();
            parameter.Add("transaction_ids", string.Join(",", transactionIds));
            return await apiCallAsync<GreenTransaction>(MethodName.IsGreenTransaction, parameter);
        }

        public async Task<SentTransaction> GetSendTransactionAsync() => await getTransactionAsync<SentTransaction>();

        public async Task<ReceivedTransaction> GetReceivedTransactionAsync() => await getTransactionAsync<ReceivedTransaction>("received");

        public async Task<SentTransaction> GetSendTransactionAsync(IEnumerable<string> addresses) => await getTransactionAsync<SentTransaction>(addresses: addresses);

        public async Task<ReceivedTransaction> GetReceivedTransactionAsync(IEnumerable<string> addresses) => await getTransactionAsync<ReceivedTransaction>("received", addresses: addresses);

        public async Task<SentTransaction> GetSendTransactionAsync(string beforeTx, IEnumerable<string> addresses) => await getTransactionAsync<SentTransaction>(beforeTx: beforeTx, addresses: addresses);

        public async Task<ReceivedTransaction> GetReceivedTransactionAsync(string beforeTx, IEnumerable<string> addresses) => await getTransactionAsync<ReceivedTransaction>("received", beforeTx: beforeTx, addresses: addresses);

        public async Task<SentTransaction> GetSendTransactionBeforeTxIdAsync(string beforeTx) => await getTransactionAsync<SentTransaction>(beforeTx: beforeTx);

        public async Task<ReceivedTransaction> GetReceivedTransactionBeforeTxIdAsync(string beforeTx) => await getTransactionAsync<ReceivedTransaction>("received", beforeTx: beforeTx);

        public async Task<SentTransaction> GetSendTransactionWithUserIdAsync(IEnumerable<int> user_ids) => await getTransactionAsync<SentTransaction>(user_ids: user_ids);

        public async Task<ReceivedTransaction> GetReceivedTransactionWithUserIdAsync(IEnumerable<int> user_ids) => await getTransactionAsync<ReceivedTransaction>("received", user_ids: user_ids);

        public async Task<SentTransaction> GetSendTransactionWithLabelsAsync(IEnumerable<string> labels) => await getTransactionAsync<SentTransaction>(labels: labels);

        public async Task<ReceivedTransaction> GetReceivedTransactionWithLabelsAsync(IEnumerable<string> labels) => await getTransactionAsync<ReceivedTransaction>("received", labels: labels);

        public async Task<RawTransaction> GetRawTransactionAsync(string txtId)
        {
            var parameter = new NameValueCollection();
            parameter.Add("txid", txtId);
            return await apiCallAsync<RawTransaction>(MethodName.GetRawTransaction, parameter);
        }

        #region Private Methods
        private async Task<T> getTransactionAsync<T>(string type = "sent", string beforeTx = null, IEnumerable<string> addresses = null, IEnumerable<int> user_ids = null, IEnumerable<string> labels = null)
        {
            var parameter = new NameValueCollection();
            parameter.Add("type", type);
            if (!string.IsNullOrEmpty(beforeTx))
                parameter.Add("before_tx", beforeTx);
            if (addresses != null && addresses.Count() > 0)
                parameter.Add("addresses", string.Join(",", addresses));
            if (user_ids != null && user_ids.Count() > 0)
                parameter.Add("user_ids", string.Join(",", user_ids));
            if (labels != null && labels.Count() > 0)
                parameter.Add("labels", string.Join(",", labels));
            return await apiCallAsync<T>(MethodName.GetTransactions, parameter);
        }
        private async Task<T> apiCallAsync<T>(string method, NameValueCollection parameter = null)
        {
            try
            {
                WebClient webClient = new WebClient();
                string apiCallUrl = getApiUrl(method, parameter);
                var jsonContent = await webClient.DownloadStringTaskAsync(apiCallUrl);
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonContent);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string getApiUrl(string method, NameValueCollection parameter)
        {
            if (parameter == null)
                parameter = new NameValueCollection();
            
            parameter.Add("api_key", apiKey);
            var querystrings = string.Join("&", parameter.AllKeys.Select(p => $"{p}={parameter[p]}"));
            var apiCallUrl = $"{Url}{method}/?{querystrings}";
            return apiCallUrl;
        }
        #endregion
    }
}
