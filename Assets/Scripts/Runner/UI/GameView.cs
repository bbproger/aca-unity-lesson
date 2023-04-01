using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace.Runner.UI
{
    public class GameView : AbstractView
    {
        [SerializeField] private Button closeButton;

        public UnityEvent OnClose { get; } = new UnityEvent();

        public override void Init()
        {
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            closeButton.onClick.AddListener(OnCloseButtonClick);
        }


        protected override void OnDisable()
        {
            base.OnDisable();
            closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            OnClose?.Invoke();
        }
    }
}