using System;
using Code.Tools;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Game
{
    public class NetworkConnectionTest : MonoBehaviour
    {
        private async void Start()
        {
            await using (var net = new NetworkConnection())
            {
                Debug.unityLogger.Log("NetworkConnectionTest.Start");
            }
        }
    }
}