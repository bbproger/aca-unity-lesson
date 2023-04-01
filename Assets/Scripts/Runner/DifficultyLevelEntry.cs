using DefaultNamespace.Runner.UI;
using UnityEngine;

namespace DefaultNamespace.Runner
{
    public class DifficultyLevelEntry : StoreEntry<DifficultyLevel?>
    {
        private readonly string _storeKey;

        public DifficultyLevelEntry(string storeKey)
        {
            _storeKey = storeKey;
        }

        protected override void SetValue(DifficultyLevel? value)
        {
            if (value == null)
            {
                return;
            }

            PlayerPrefs.SetInt(_storeKey, (int)value.Value);
        }

        protected override DifficultyLevel? GetValue()
        {
            return (DifficultyLevel)PlayerPrefs.GetInt(_storeKey, 0);
        }

        protected override bool HasValue(DifficultyLevel? value)
        {
            return value != null;
        }

        protected override bool IsSame(DifficultyLevel? value, DifficultyLevel? current)
        {
            if (value == null || current == null)
            {
                return false;
            }
            

            return value.Value == current.Value;
        }
    }
}