using System;
using System.Collections.Generic;
using Block.Io.Core.Response;

namespace Block.Io.Core {
    public interface IBlockIO {
        AddressWithBalance GerMyAresses(int page = 1);
        AddressBalance GetAddressBalanceWithAddress(params string[] addresses);
        AddressBalance GetAddressBalanceWithLabels(params string[] labels);
        LabelAddress GetAddressByLabel(string label);
        Address GetAddressWithAddressType(string addressType);
        Balance GetBalance();
        Price GetCurrentPrice(string currency = null);
        GreenTransaction GetGreenTransaction(List<string> transactionIds);
        ArchiveAddress GetMyArchivedAddresses();
        NetworkFee GetNetworkFeeEstimate(Dictionary<string, double> addressAmount);
        Address GetNewAddressWithGivenLabel(string label);
        Address GetNewAddressWithRandomLabel();
        RawTransaction GetRawTransaction(string txtId);
        ReceivedTransaction GetReceivedTransaction();
        ReceivedTransaction GetReceivedTransaction(List<string> addresses);
        ReceivedTransaction GetReceivedTransaction(string beforeTx, List<string> addresses);
        ReceivedTransaction GetReceivedTransactionBeforeTxId(string beforeTx);
        ReceivedTransaction GetReceivedTransactionWithLabels(List<string> labels);
        ReceivedTransaction GetReceivedTransactionWithUserId(List<int> user_ids);
        SentTransaction GetSendTransaction();
        SentTransaction GetSendTransaction(List<string> addresses);
        SentTransaction GetSendTransaction(string beforeTx, List<string> addresses);
        SentTransaction GetSendTransactionBeforeTxId(string beforeTx);
        SentTransaction GetSendTransactionWithLabels(List<string> labels);
        SentTransaction GetSendTransactionWithUserId(List<int> user_ids);
        ArchiveAddress SetArchiveAddresses(List<string> addresses);
        ArchiveAddress SetUnArchiveAddresses(List<string> addresses);
        Withdraw Withdraw(Dictionary<string, double> addressAmount, string pin);
        Withdraw WithdrawFromAddresses(List<Tuple<string, string, double>> transferAddress, string pin);
        Withdraw WithdrawFromLabel(List<Tuple<string, string, double>> transferLabels, string pin);
        Withdraw WithdrawFromLabelToAddress(List<Tuple<string, string, double>> transferLabels, string pin);
    }
}