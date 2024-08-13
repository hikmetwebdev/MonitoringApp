using MonitoringApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringApp.Loaders
{
    public class CsvFileLoader : IFileLoader
    {
        public IEnumerable<Data> LoadData(string filePath)
        {
            var tradeDataList = new List<Data>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var columns = line.Split(',');

                var tradeData = new Data
                {
                    Date = DateTime.ParseExact(columns[0], "yyyy-M-d", CultureInfo.InvariantCulture),
                    Open = decimal.Parse(columns[1]),
                    High = decimal.Parse(columns[2]),
                    Low = decimal.Parse(columns[3]),
                    Close = decimal.Parse(columns[4]),
                    Volume = long.Parse(columns[5])
                };

                tradeDataList.Add(tradeData);
            }

            return tradeDataList;
        }
    }
}
