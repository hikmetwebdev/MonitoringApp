using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using MonitoringApp.Loaders;
using MonitoringApp.Models;

namespace MonitoringApp.Services
{
    public class FileMonitorService
    {
        private readonly Timer _timer;
        private readonly string _directoryPath;
        private readonly List<IFileLoader> _fileLoaders;
        private readonly Action<IEnumerable<Data>> _onNewDataLoaded;

        public FileMonitorService(string directoryPath, double interval, List<IFileLoader> fileLoaders, Action<IEnumerable<Data>> onNewDataLoaded)
        {
            _directoryPath = directoryPath;
            _fileLoaders = fileLoaders;
            _onNewDataLoaded = onNewDataLoaded;
            _timer = new Timer(interval);
            _timer.Elapsed += OnElapsed;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void OnElapsed(object sender, ElapsedEventArgs e)
        {
            var files = Directory.GetFiles(_directoryPath).Where(file => IsSupportedFile(file)).ToList();
            foreach (var file in files)
            {
                foreach (var loader in _fileLoaders)
                {
                    var data = loader.LoadData(file);
                    _onNewDataLoaded(data);
                }
            }
        }

        private bool IsSupportedFile(string filePath)
        {
            var supportedExtensions = new[] { ".csv", ".txt", ".xml" };
            return supportedExtensions.Contains(Path.GetExtension(filePath).ToLower());
        }
    }
}
