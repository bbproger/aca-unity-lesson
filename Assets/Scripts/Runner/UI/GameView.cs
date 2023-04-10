using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace.Runner.UI
{
    public class GameView : AbstractView
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private TextMeshProUGUI distanceText;

        public UnityEvent OnClose { get; } = new UnityEvent();

        public override void Init()
        {
            SetDistanceText(0);
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

        public void SetDistanceText(int distance)
        {
            distanceText.text = distance.ToString("D8");
        }

        private void OnCloseButtonClick()
        {
            OnClose?.Invoke();
        }
    }
}