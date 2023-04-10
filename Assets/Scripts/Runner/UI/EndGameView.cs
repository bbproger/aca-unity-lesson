using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace.Runner.UI
{
    public class EndGameView : AbstractView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI bestScoreText;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button returnButton;

        public UnityEvent OnContinue { get; } = new UnityEvent();
        public UnityEvent OnReturn { get; } = new UnityEvent();

        public override void Init()
        {
            SetBestScore();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            continueButton.onClick.AddListener(OnContinueButtonClicked);
            returnButton.onClick.AddListener(OnReturnButtonClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            continueButton.onClick.RemoveListener(OnContinueButtonClicked);
            returnButton.onClick.RemoveListener(OnReturnButtonClicked);
        }


        private void OnContinueButtonClicked()
        {
            OnContinue?.Invoke();
        }

        private void OnReturnButtonClicked()
        {
            OnReturn?.Invoke();
        }

        public void SetCurrentScore(int score)
        {
            scoreText.text = $"{score:D8}";
        }

        private void SetBestScore()
        {
            bestScoreText.text = $"{Store.BestScore.Value:D8}";
        }
    }
}