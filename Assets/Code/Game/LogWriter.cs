using System;
using Code.Tools;
using UnityEngine;

namespace Code.Game
{
    public class LogWriter : MonoBehaviour
    {
        [SerializeField] private string _logFolderPath;
        
        private readonly string _pathToResources = Application.dataPath + "/Resources/";
        
        private void Start()
        {
            LogMassageTryCatch("Game Started");
        }

        private void LogMassageUsing(string massage)
        {
            using (var logger = new FileLogger(_pathToResources + _logFolderPath))
            {
                logger.Log(massage);
            }
        }

        private void LogMassageTryCatch(string massage)
        {
            FileLogger logger = null;
            
            try
            {
                logger = new FileLogger(_pathToResources + _logFolderPath);
                logger.Log(massage);
            }
            catch (Exception e)
            {
                Console.WriteLine("Logger Error - " + e);
                throw;
            }
            finally
            {
                logger?.Dispose();
            }
        }
    }
}