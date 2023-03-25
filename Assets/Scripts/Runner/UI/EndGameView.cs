using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Runner.UI
{
    public class EndGameView : AbstractView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI bestScoreText;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button returnButton;

        public override void Init()
        {
            SetBestScore();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            restartButton.onClick.AddListener(OnRestartButtonClicked);
            returnButton.onClick.AddListener(OnReturnButtonClicked);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            restartButton.onClick.RemoveListener(OnRestartButtonClicked);
            returnButton.onClick.RemoveListener(OnReturnButtonClicked);
        }


        private void OnRestartButtonClicked()
        {
        }

        private void OnReturnButtonClicked()
        {
        }

        public void SetCurrentScore(int score)
        {
            scoreText.text = $"{score:D8}";
        }

        private void SetBestScore()
        {
            bestScoreText.text = $"{Store.BestScore:D8}";
        }
    }
}