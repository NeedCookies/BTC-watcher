using NBitcoin;
using NBitcoinTest.Entities;
using Newtonsoft.Json.Linq;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.Text;
using NBitcoinTest.Services;
using NBitcoinTest.DataAccess;

namespace NBitcoinTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var blockChainService = new BlockChainInfo();
            var csvDataBase = new CsvDataBase();

            var lastBlockData = await blockChainService.GetLastBlockAsync();
            csvDataBase.WriteBlockDataToFile(lastBlockData);
        }
    }
}
