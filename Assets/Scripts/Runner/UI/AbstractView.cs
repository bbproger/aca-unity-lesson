using UnityEngine;

namespace DefaultNamespace.Runner.UI
{
    public abstract class AbstractView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        public abstract void Init();

        protected virtual void OnEnable()
        {
        }

        protected virtual void OnDisable()
        {
        }
    }
}