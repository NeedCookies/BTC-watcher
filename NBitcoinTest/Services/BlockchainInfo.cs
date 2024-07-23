using NBitcoinTest.Entities;
using Newtonsoft.Json.Linq;

namespace NBitcoinTest.Services
{
    public class BlockChainInfo
    {

        public async Task<BlockChain> GetBlockChainInfoAsync()
        {
            using (var client = new HttpClient())
            {
                // Запрос информации о блокчейне Bitcoin Mainnet
                var blockchainResponse = await client.GetAsync("https://api.blockcypher.com/v1/btc/main");
                blockchainResponse.EnsureSuccessStatusCode();
                var blockchainContent = await blockchainResponse.Content.ReadAsStringAsync();
                var blockchainJson = JObject.Parse(blockchainContent);

                if (blockchainJson == null)
                    throw new ApplicationException("Blockchain data is empty");

                var blockChainInfo = new BlockChain
                {
                    Height = int.Parse(blockchainJson["height"].ToString()),
                    Hash = blockchainJson["hash"].ToString(),
                    Time = DateTime.Parse(blockchainJson["time"].ToString()),
                    LastForkHash = blockchainJson["last_fork_hash"].ToString()
                };

                return blockChainInfo;
            }
        }

        public async Task<BlockData> GetBlockDataAsync(string blockHash)
        {
            if (string.IsNullOrEmpty(blockHash))
            {
                throw new ApplicationException("block hash is null");
            }

            using (var client = new HttpClient())
            {
                var blockResponse = await client.GetAsync($"https://api.blockcypher.com/v1/btc/main/blocks/{blockHash}");
                blockResponse.EnsureSuccessStatusCode();
                var blockContent = await blockResponse.Content.ReadAsStringAsync();
                var blockJson = JObject.Parse(blockContent);

                if (blockJson == null)
                    throw new ApplicationException("Block data is empty");

                var blockData = new BlockData
                {
                    Hash = blockJson["hash"].ToString(),
                    Height = int.Parse(blockJson["height"].ToString()),
                    Total = long.Parse(blockJson["total"].ToString()),
                    Fees = long.Parse(blockJson["fees"].ToString()),
                    Size = int.Parse(blockJson["size"].ToString()),
                    Time = DateTime.Parse(blockJson["time"].ToString()),
                    Nonce = long.Parse(blockJson["nonce"].ToString()),
                    N_Tx = int.Parse(blockJson["n_tx"].ToString()),
                    TxIds = string.Join(" | ", blockJson["txids"].ToObject<string[]>())
                };

                return blockData;
            }
        }

        public async Task<BlockData> GetLastBlockAsync()
        {
            var blockchainInfo = await GetBlockChainInfoAsync();
            var lasBlockHash = blockchainInfo.LastForkHash;

            var lastBlockData = await GetBlockDataAsync(lasBlockHash);
            return lastBlockData;
        }
    }
}
