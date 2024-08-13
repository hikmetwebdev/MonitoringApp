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
    public class TxtFileLoader : IFileLoader
    {
        public IEnumerable<Data> LoadData(string filePath)
        {
            return File.ReadAllLines(filePath)
                       .Select(ParseLine)
                       .Where(data => data != null)
                       .ToList();
        }

        private Data ParseLine(string line)
        {
            var columns = line.Split('\t');

            try
            {
                return new Data
                {
                    Date = DateTime.ParseExact(columns[0], "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Open = decimal.Parse(columns[1]),
                    High = decimal.Parse(columns[2]),
                    Low = decimal.Parse(columns[3]),
                    Close = decimal.Parse(columns[4]),
                    Volume = long.Parse(columns[5])
                };
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Date format error in line: {line}. Error: {ex.Message}");
                return null;
            }
        }


    }
}
