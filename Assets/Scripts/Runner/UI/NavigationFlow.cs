using UnityEngine;

namespace DefaultNamespace.Runner.UI
{
    public class NavigationFlow : MonoBehaviour
    {
        [SerializeField] private ViewService viewService;
        [SerializeField] private GameplayAggregator gameplayAggregator;

        private AbstractView _currentView;

        private void Start()
        {
            Run();
        }

        private void OnEnable()
        {
            gameplayAggregator.OnDistanceChanged.AddListener(OnDistanceChanged);
            gameplayAggregator.OnGameEnd.AddListener(OnGameEnd);
        }

        private void OnDisable()
        {
            gameplayAggregator.OnDistanceChanged.RemoveListener(OnDistanceChanged);
            gameplayAggregator.OnGameEnd.RemoveListener(OnGameEnd);
        }

        private void Run()
        {
            ShowHomeView();
        }

        private void ShowHomeView()
        {
            gameplayAggregator.ResetGame();
            HomeView homeView = ShowView<HomeView>();
            homeView.OnPlay.AddListener(() =>
            {
                gameplayAggregator.Init();
                ShowGameView();
            });
            homeView.OnSettings.AddListener(ShowSettingsView);
            homeView.OnAbout.AddListener(ShowAboutView);
            homeView.Init();
        }

        private void ShowGameView()
        {
            GameView gameView = ShowView<GameView>();
            gameView.OnClose.AddListener(() =>
            {
                gameplayAggregator.SetComponentActiveState(false);
                ShowHomeView();
            });
            gameView.Init();
            gameplayAggregator.SetComponentActiveState(true);
        }

        private void OnDistanceChanged(int distance)
        {
            if (_currentView is not GameView gameView)
            {
                return;
            }

            gameView.SetDistanceText(distance);
        }

        private void OnGameEnd(int distance)
        {
            ShowEndGameView(distance);
        }

        private void ShowSettingsView()
        {
            SettingsView settingsView = ShowView<SettingsView>();
            settingsView.OnBack.AddListener(ShowHomeView);
            settingsView.Init();
        }

        private void ShowEndGameView(int distance)
        {
            EndGameView endGameView = ShowView<EndGameView>();
            endGameView.SetCurrentScore(distance);
            endGameView.OnReturn.AddListener(ShowHomeView);
            endGameView.OnContinue.AddListener(ShowGameView);
            endGameView.Init();
        }

        private void ShowAboutView()
        {
        }

        private TView ShowView<TView>() where TView : AbstractView
        {
            CloseCurrentView();
            TView view = viewService.LoadView<TView>();
            _currentView = view;
            return view;
        }

        private void CloseCurrentView()
        {
            if (_currentView == null)
            {
                return;
            }

            Destroy(_currentView.gameObject);
        }
    }
}