using UnityEngine;

namespace DefaultNamespace.Runner
{
    public class IntEntry : StoreEntry<int>
    {
        private readonly string _storeKey;

        public IntEntry(string storeKey)
        {
            _storeKey = storeKey;
        }

        protected override void SetValue(int value)
        {
            PlayerPrefs.SetInt(_storeKey, value);
        }

        protected override int GetValue()
        {
            return PlayerPrefs.GetInt(_storeKey, 0);
        }

        protected override bool HasValue(int value)
        {
            return value != 0;
        }

        protected override bool IsSame(int value, int current)
        {
            return value == current;
        }
    }
}