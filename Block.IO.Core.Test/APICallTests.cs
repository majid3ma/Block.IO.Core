using Block.Io.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Block.IO.Core.Test
{
    public class MethodCallTests
    {
        IBlockIO blockIO = new BlockIO("input_API_Key");

        [Fact]
        public async Task CallAPI_GerMyAressesAsyncTests()
        {
            var getMyAddreses = await blockIO.GetMyAressesAsync();
            Assert.Equal("success", getMyAddreses.Status);
        }
        [Fact]
        public async Task CallAPI_GetAddressBalanceWithAddressAsyncTests()
        {
            var result = await blockIO.GetMyAressesAsync();
            Assert.Equal("success", result.Status);
        }
        [Fact]
        public async Task CallAPI_GetAddressBalanceWithLabelsAsyncTests()
        {
            var result = await blockIO.GetAddressBalanceWithLabelsAsync();
            Assert.Equal("success", result.Status);
        }
        [Theory]
        [InlineData("witness_v0")]
        public async Task CallAPI_GetAddressWithAddressTypeAsyncTests(string addressType)
        {
            var result = await blockIO.GetAddressWithAddressTypeAsync(addressType);
            Assert.Equal("success", result.Status);
        }
        [Fact]
        public async Task CallAPI_GetBalanceAsyncTests()
        {
            var actual = await blockIO.GetBalanceAsync();
            Assert.Equal("success", actual.Status);
        }
        [Theory]
        [InlineData("USD")]
        [InlineData(null)]
        async Task CallAPI_GetCurrentPriceAsyncTests(string currency)
        {
            var actual = await blockIO.GetCurrentPriceAsync(currency);
            Assert.Equal("success", actual.Status);
        }

        [Fact]
        public async Task CallAPI_GetMyArchivedAddressesAsyncTests()
        {
            var actual = await blockIO.GetMyArchivedAddressesAsync();
            Assert.Equal("success", actual.Status);
        }

        [Theory]
        [InlineData("testlabel19")]
        public async Task CallAPI_GetNewAddressWithGivenLabelAsyncAsyncTests(string label)
        {
            var actual = await blockIO.GetNewAddressWithGivenLabelAsync(label);
            Assert.Equal("success", actual.Status);

            var actualSetArchive = await blockIO.SetArchiveAddressesAsync(new List<string> { actual.Data.Address });
            Assert.Equal("success", actualSetArchive.Status);

            var actualSetUnArchive = await blockIO.SetUnArchiveAddressesAsync(new List<string> { actual.Data.Address });
            Assert.Equal("success", actualSetUnArchive.Status);

            var actualAddress = await blockIO.GetAddressByLabelAsync(label);
            Assert.Equal("success", actualAddress.Status);

            var actualRecieved = await blockIO.GetReceivedTransactionWithLabelsAsync(new List<string> { label });
            Assert.Equal("success", actualRecieved.Status);

            var actualSend = await blockIO.GetSendTransactionWithLabelsAsync(new List<string> { label });
            Assert.Equal("success", actualRecieved.Status);

            var actualGetReceiveTransactionWithUserId = await blockIO.GetReceivedTransactionWithUserIdAsync(new List<int> { actual.Data.UserId });
            Assert.Equal("success", actualGetReceiveTransactionWithUserId.Status);

            var actualGetSendTransactionWithUserId = await blockIO.GetSendTransactionWithUserIdAsync(new List<int> { actual.Data.UserId });

            Assert.Equal("success", actualGetSendTransactionWithUserId.Status);
        }
        [Fact]
        public async Task CallAPI_GetNewAddressWithRandomLabelAsyncTests()
        {
            var actual = await blockIO.GetNewAddressWithRandomLabelAsync();
            Assert.Equal("success", actual.Status);
        }

        [Fact]
        public async Task CallAPI_GetReceivedTransactionAsyncAsyncTests()
        {
            var actual = await blockIO.GetReceivedTransactionAsync();
            Assert.Equal("success", actual.Status);
        }

        [Fact]
        public async Task CallAPI_GetSendTransactionAsyncAsyncTests()
        {
            var actual = await blockIO.GetSendTransactionAsync();
            Assert.Equal("success", actual.Status);
        }

        [Fact]
        async Task CallAPI_GetReceivedTransactionBeforeTxIdAsyncAsyncTests()
        {
            var actual = await blockIO.GetReceivedTransactionBeforeTxIdAsync(string.Empty);
            Assert.Equal("success", actual.Status);
        }


        [Fact]
        public async Task CallAPI_GetSendTransactionBeforeTxIdAsyncAsyncTests()
        {
            var actual = await blockIO.GetSendTransactionBeforeTxIdAsync(string.Empty);
            Assert.Equal("success", actual.Status);
        }
    }
}
