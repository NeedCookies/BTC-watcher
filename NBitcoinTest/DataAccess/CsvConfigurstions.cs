using CsvHelper.Configuration;
using System.Globalization;

namespace NBitcoinTest.DataAccess
{
    public class CsvConfigurstions
    {
        public CsvConfigurstions()
        {
        }

        public CsvConfiguration GetConfiguration()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ","
            };

            return config;
        }
    }
}
