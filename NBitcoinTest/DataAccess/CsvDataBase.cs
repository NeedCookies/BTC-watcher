using CsvHelper;
using NBitcoinTest.Entities;

namespace NBitcoinTest.DataAccess
{
    public class CsvDataBase
    {
        private readonly CsvConfigurstions csvConfig;

        public CsvDataBase()
        {
            csvConfig = new CsvConfigurstions();
        }

        public void WriteBlockDataToFile(BlockData blockData)
        {
            using (var stream = File.Open("block_data.csv", FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, csvConfig.GetConfiguration()))
            {
                csv.Context.RegisterClassMap<BlockDataMap>();
                csv.WriteRecord(blockData);
                csv.NextRecord(); // Go to next line
            }
        }
    }
}
