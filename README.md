# Block.IO.Core
Block.IO Library for .net core 

#Sample Get Balance Code
IBlockIO blockIO = new BlockIO("input_API_Key");
var balance = await blockIO.GetBalanceAsync();
Console.WriteLine(balance.Data.AvailableBalance);
