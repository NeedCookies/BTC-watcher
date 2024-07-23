using CsvHelper.Configuration;

namespace NBitcoinTest.Entities
{
    public class BlockData
    {
        public string Hash { get; set; }
        public int Height { get; set; }
        public long Total { get; set; }
        public long Fees { get; set; }
        public int Size { get; set; }
        public DateTime Time { get; set; }
        public long Nonce { get; set; }
        public int N_Tx { get; set; }
        public string TxIds { get; set; }
    }

    class BlockDataMap : ClassMap<BlockData>
    {
        public BlockDataMap()
        {
            Map(m => m.Hash).Name("Hash");
            Map(m => m.Height).Name("Height");
            Map(m => m.Total).Name("Total");
            Map(m => m.Fees).Name("Fees");
            Map(m => m.Size).Name("Size");
            Map(m => m.Time).Name("Time");
            Map(m => m.Nonce).Name("Nonce");
            Map(m => m.N_Tx).Name("N_Tx");
            Map(m => m.TxIds).Name("TxIds").TypeConverterOption.Format(" | ");
        }
    }
}
