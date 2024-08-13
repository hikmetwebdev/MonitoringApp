using MonitoringApp.Loaders;
using MonitoringApp.Models;
using MonitoringApp.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace MonitoringApp
{

  
    public partial class Form1 : Form
    {
        private List<IFileLoader> _fileLoaders;
        private FileMonitorService _fileMonitorService;


        public Form1()
        {
            InitializeComponent();
            InitializeFileLoaders();
            InitializeFileMonitorService();

        }


        private void InitializeFileMonitorService()
        {
            var directoryPath = @"C:\Your\Input\Directory\Path";
            var interval = 5000.0; 
            var fileLoaders = new List<IFileLoader>
            {
                new CsvFileLoader(),
                new TxtFileLoader(),
                new XmlFileLoader()
            };

            _fileMonitorService = new FileMonitorService(directoryPath, interval, fileLoaders, OnNewDataLoaded);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _fileMonitorService.Start();
            btnUploadFile.Enabled = false;
            Console.WriteLine("Monitoring service started.");
        }

        private void OnNewDataLoaded(IEnumerable<Data> tradeData)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<IEnumerable<Data>>(OnNewDataLoaded), tradeData);
            }
            else
            {
                foreach (var data in tradeData)
                {
                    dtgMonitoring.Rows.Add(data.Date, data.Open, data.High, data.Low, data.Close, data.Volume);
                }
            }
        }
        private void InitializeFileLoaders()
        {
            _fileLoaders = new List<IFileLoader>
            {
                new CsvFileLoader(),
                new TxtFileLoader(),
                new XmlFileLoader()
            };
        }


        private void LoadFile(string filePath)
        {
            Console.WriteLine($"Attempting to load file: {filePath}");
            var fileExtension = Path.GetExtension(filePath).ToLower();
            IFileLoader loader = _fileLoaders.Find(l =>
                fileExtension == ".csv" && l is CsvFileLoader ||
                fileExtension == ".txt" && l is TxtFileLoader ||
                fileExtension == ".xml" && l is XmlFileLoader);

            if (loader != null)
            {
                var data = loader.LoadData(filePath);
                DisplayData(data);
                Console.WriteLine("File loaded and data displayed.");
            }
            else
            {
                MessageBox.Show("Unsupported file format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Unsupported file format.");
            }
        }

        private void DisplayData(IEnumerable<Data> tradeData)
        {
            dtgMonitoring.Rows.Clear();
            foreach (var data in tradeData)
            {
                dtgMonitoring.Rows.Add(data.Date, data.Open, data.High, data.Low, data.Close, data.Volume);
            }
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (.csv, *.txt, *.xml)|.csv;.txt;.xml";
                openFileDialog.InitialDirectory = @"C:\";
                openFileDialog.Title = "Select a file to upload";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    LoadFile(filePath);
                }
            }
        }
    }
}
