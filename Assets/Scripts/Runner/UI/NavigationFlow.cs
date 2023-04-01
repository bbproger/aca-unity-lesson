using System;
using UnityEngine;

namespace DefaultNamespace.Runner.UI
{
    public class NavigationFlow : MonoBehaviour
    {
        [SerializeField] private ViewService viewService;

        private AbstractView _currentView;

        private void Start()
        {
            Run();
        }

        public void Run()
        {
            ShowHomeView();
        }

        private void ShowHomeView()
        {
            HomeView homeView = ShowView<HomeView>();
            homeView.OnPlay.AddListener(ShowGameView);
            homeView.OnSettings.AddListener(ShowSettingsView);
            homeView.OnAbout.AddListener(ShowAboutView);
            homeView.Init();
        }

        private void ShowGameView()
        {
            GameView gameView = ShowView<GameView>();
            gameView.OnClose.AddListener(ShowHomeView);
            gameView.Init();
        }

        private void ShowSettingsView()
        {
            SettingsView settingsView = ShowView<SettingsView>();
            settingsView.OnBack.AddListener(ShowHomeView);
            settingsView.Init();
        }

        private void ShowEndGameView()
        {
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