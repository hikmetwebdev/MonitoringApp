using MonitoringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonitoringApp.Loaders
{
    public class XmlFileLoader : IFileLoader
    {
        public IEnumerable<Data> LoadData(string filePath)
        {
            var tradeDataList = new List<Data>();
            var xDocument = XDocument.Load(filePath);

            foreach (var element in xDocument.Descendants("Trade"))
            {
                var tradeData = new Data
                {
                    Date = DateTime.Parse(element.Element("Date")?.Value),
                    Open = decimal.Parse(element.Element("Open")?.Value),
                    High = decimal.Parse(element.Element("High")?.Value),
                    Low = decimal.Parse(element.Element("Low")?.Value),
                    Close = decimal.Parse(element.Element("Close")?.Value),
                    Volume = long.Parse(element.Element("Volume")?.Value)
                };

                tradeDataList.Add(tradeData);
            }

            return tradeDataList;
        }
    }
}
