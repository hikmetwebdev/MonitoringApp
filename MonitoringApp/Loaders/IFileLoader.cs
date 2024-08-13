using MonitoringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringApp.Loaders
{
    public interface IFileLoader
    {
        IEnumerable<Data> LoadData(string filePath);

    }
}
