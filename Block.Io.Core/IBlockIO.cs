using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Block.Io.Core.Response;

namespace Block.Io.Core
{
    public interface IBlockIO
    {
        Task<AddressBalance> GetAddressBalanceWithAddressAsync(params string[] addresses);
        Task<AddressBalance> GetAddressBalanceWithLabelsAsync(params string[] labels);
        Task<LabelAddress> GetAddressByLabelAsync(string label);
        Task<Address> GetAddressWithAddressTypeAsync(string addressType);
        Task<Balance> GetBalanceAsync();
        Task<Price> GetCurrentPriceAsync(string currency = null);
        Task<GreenTransaction> GetGreenTransactionAsync(IEnumerable<string> transactionIds);
        Task<ArchiveAddress> GetMyArchivedAddressesAsync();
        Task<AddressWithBalance> GetMyAressesAsync(int page = 1);
        Task<NetworkFee> GetNetworkFeeEstimateAsync(Dictionary<string, double> addressAmount);
        Task<Address> GetNewAddressWithGivenLabelAsync(string label);
        Task<Address> GetNewAddressWithRandomLabelAsync();
        Task<RawTransaction> GetRawTransactionAsync(string txtId);
        Task<ReceivedTransaction> GetReceivedTransactionAsync();
        Task<ReceivedTransaction> GetReceivedTransactionAsync(IEnumerable<string> addresses);
        Task<ReceivedTransaction> GetReceivedTransactionAsync(string beforeTx, IEnumerable<string> addresses);
        Task<ReceivedTransaction> GetReceivedTransactionBeforeTxIdAsync(string beforeTx);
        Task<ReceivedTransaction> GetReceivedTransactionWithLabelsAsync(IEnumerable<string> labels);
        Task<ReceivedTransaction> GetReceivedTransactionWithUserIdAsync(IEnumerable<int> user_ids);
        Task<SentTransaction> GetSendTransactionAsync();
        Task<SentTransaction> GetSendTransactionAsync(IEnumerable<string> addresses);
        Task<SentTransaction> GetSendTransactionAsync(string beforeTx, IEnumerable<string> addresses);
        Task<SentTransaction> GetSendTransactionBeforeTxIdAsync(string beforeTx);
        Task<SentTransaction> GetSendTransactionWithLabelsAsync(IEnumerable<string> labels);
        Task<SentTransaction> GetSendTransactionWithUserIdAsync(IEnumerable<int> user_ids);
        Task<ArchiveAddress> SetArchiveAddressesAsync(IEnumerable<string> addresses);
        Task<ArchiveAddress> SetUnArchiveAddressesAsync(IEnumerable<string> addresses);
        Task<Withdraw> WithdrawAsync(Dictionary<string, double> addressAmount, string pin);
        Task<Withdraw> WithdrawFromAddressesAsync(IEnumerable<Tuple<string, string, double>> transferAddress, string pin);
        Task<Withdraw> WithdrawFromLabelAsync(IEnumerable<Tuple<string, string, double>> transferLabels, string pin);
        Task<Withdraw> WithdrawFromLabelToAddressAsync(IEnumerable<Tuple<string, string, double>> transferLabels, string pin);
    }
}