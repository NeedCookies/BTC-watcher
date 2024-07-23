namespace NBitcoinTest.Entities
{
    public class BlockChain
    {
        public int Height { get; set; }
        public string Hash { get; set; }
        public DateTime Time { get; set; }
        public string LastForkHash { get; set; }
    }
}
