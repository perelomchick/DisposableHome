using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Game
{
    public class CoroutineRunner : MonoBehaviour
    {
        public IEnumerator RunCoroutine(IEnumerator eumerator)
        {
            var coroutine = StartCoroutine(eumerator);
            yield return coroutine;
        }
    }
}