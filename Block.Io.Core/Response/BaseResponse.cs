using System;
using System.Collections.Generic;
using System.Text;

namespace Block.Io.Core.Response {
    public abstract class BaseResponse<T> where T : class {
        public string Status { get; set; }
        public virtual T Data { get; set; }
    }
    public class Address : BaseResponse<AddressData> { }
    public class Balance : BaseResponse<BalanceData> { }
    public class AddressWithBalance : BaseResponse<MyAddressData> { }
    public class AddressBalance : BaseResponse<AddressBalanceData> { }
    public class LabelAddress : BaseResponse<AddressWithBalanceData> { }
    public class Withdraw : BaseResponse<WithdrawData> { }
    public class NetworkFee : BaseResponse<NetworkFeeData> { }
    public class ArchiveAddress : BaseResponse<ArchiveAddressData> { }
    public class Price : BaseResponse<ExchangePriceData> { }
    public class GreenTransaction : BaseResponse<GreenTransactionData> { }
    public class ReceivedTransaction : BaseResponse<TransactionData<ReceivedTransactionData>> { }
    public class SentTransaction : BaseResponse<TransactionData<SentTransactionData>> { }
    public class RawTransaction : BaseResponse<RawTransactionData> { }
}
