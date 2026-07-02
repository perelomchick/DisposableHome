using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Game
{
    public class AnimationTest : MonoBehaviour, IPointerClickHandler 
    {
        [SerializeField] private Animator _animation;
        private readonly CoroutineRunner _coroutineRunner = new CoroutineRunner();

        public void OnPointerClick(PointerEventData eventData)
        {
            using (var animationHandler = new AnimationHandler(_animation,_coroutineRunner))
            {
                Debug.Log("Animation Started");
            }
            Debug.Log("Animation Ended");
        }
    }
}