using System;
using System.Collections;
using UnityEngine;

namespace Code.Game
{
    public class AnimationHandler : IDisposable
    {
        private readonly int _isAnimating = Animator.StringToHash("isAnimating");
        private readonly CoroutineRunner _coroutineRunner;
        private readonly Animator _animator;
        
        public AnimationHandler(Animator animator,CoroutineRunner coroutineRunner)
        {
            _animator = animator;
            _coroutineRunner = coroutineRunner;
            _animator.SetBool("isAnimating", true);
            Debug.Log("SetBool true, current value: " + _animator.GetBool(_isAnimating));
        }

        public void Dispose()
        {
            _coroutineRunner.RunCoroutine(StopAnimation());
        }

        private IEnumerator StopAnimation()
        {
            yield return null;
            _animator.SetBool("isAnimating", false);
            Debug.Log("SetBool false, current value: " + _animator.GetBool(_isAnimating));
            GC.SuppressFinalize(this);
        }

        ~AnimationHandler()
        {
            Dispose();
        }
    }
}