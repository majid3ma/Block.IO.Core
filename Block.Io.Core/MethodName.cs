using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core
{
    public class MethodName
    {
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
