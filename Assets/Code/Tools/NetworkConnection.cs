using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Code.Tools
{
    public class NetworkConnection : IAsyncDisposable
    { 
        public NetworkConnection()
        {
            Debug.Log("Connection opened.");
        }

        public async ValueTask DisposeAsync()
        {
            await Task.Delay(1000);
            Debug.Log("Connection closed async.");
            GC.SuppressFinalize(this);
        }

        ~NetworkConnection()
        {
            DisposeAsync().AsTask().Wait();
        }

    }
}