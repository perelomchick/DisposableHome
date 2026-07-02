using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Code.Tools
{
    public class FileLogger : IDisposable, IAsyncDisposable
    {
        private const string LOGGER_NAME = "FileLogger";
        private readonly StreamWriter _writer;

        public FileLogger(string folderPath)
        {
            Directory.CreateDirectory(folderPath);

            var fileName = $"{LOGGER_NAME}({GetTime()}).txt";
            var fullPath = Path.Combine(folderPath, fileName);
            Debug.Log(fullPath);
            
            _writer = new StreamWriter(fullPath, append: false);
        }

        public void Log(string message)
        {
            _writer.WriteLine($"[{GetTime()}] - " + message);
        }

        public void Dispose()
        {
            _writer?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (_writer != null) await _writer.DisposeAsync();
        }
        
        private string GetTime() =>  DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
        
        ~FileLogger()
        {
            _writer?.Dispose();
        }
    }
}

