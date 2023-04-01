using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace.Runner.UI
{
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }

    public class SettingsView : AbstractView
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Slider soundSlider;
        [SerializeField] private ToggleGroup toggleGroup;
        [SerializeField] private Toggle easyToggle;
        [SerializeField] private Toggle mediumToggle;
        [SerializeField] private Toggle hardToggle;
        public UnityEvent OnBack { get; } = new UnityEvent();

        public override void Init()
        {
            ApplyDifficultyLevelToUI();
            ApplySoundToUI();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            backButton.onClick.AddListener(OnBackButtonClick);
            easyToggle.onValueChanged.AddListener(OnToggleValueChanged);
            mediumToggle.onValueChanged.AddListener(OnToggleValueChanged);
            hardToggle.onValueChanged.AddListener(OnToggleValueChanged);
            soundSlider.onValueChanged.AddListener(OnSoundSliderValueChanged);
        }


        protected override void OnDisable()
        {
            base.OnDisable();
            backButton.onClick.RemoveListener(OnBackButtonClick);
            easyToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
            mediumToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
            hardToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
            soundSlider.onValueChanged.RemoveListener(OnSoundSliderValueChanged);
        }

        private void OnSoundSliderValueChanged(float value)
        {
            Store.Sound.Value = (int)value;
        }

        private void OnToggleValueChanged(bool state)
        {
            if (!state)
            {
                return;
            }

            if (toggleGroup.GetFirstActiveToggle() == easyToggle)
            {
                SetDifficultyLevel(DifficultyLevel.Easy);
            }
            else if (toggleGroup.GetFirstActiveToggle() == mediumToggle)
            {
                SetDifficultyLevel(DifficultyLevel.Medium);
            }
            else if (toggleGroup.GetFirstActiveToggle() == hardToggle)
            {
                SetDifficultyLevel(DifficultyLevel.Hard);
            }
        }

        private void SetDifficultyLevel(DifficultyLevel difficultyLevel)
        {
            Store.DifficultyLevel.Value = difficultyLevel;
        }

        private void ApplyDifficultyLevelToUI()
        {
            switch (Store.DifficultyLevel.Value)
            {
                case DifficultyLevel.Easy:
                    easyToggle.SetIsOnWithoutNotify(true);
                    break;
                case DifficultyLevel.Medium:
                    mediumToggle.SetIsOnWithoutNotify(true);
                    break;
                case DifficultyLevel.Hard:
                    hardToggle.SetIsOnWithoutNotify(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ApplySoundToUI()
        {
            soundSlider.SetValueWithoutNotify(Store.Sound.Value);
        }

        private void OnBackButtonClick()
        {
            OnBack?.Invoke();
        }
    }
}