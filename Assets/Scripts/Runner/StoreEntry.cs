namespace DefaultNamespace.Runner
{
    public abstract class StoreEntry<T>
    {
        private T _value;

        public T Value
        {
            get => !HasValue(_value) ? GetValue() : _value;
            set
            {
                if (IsSame(value, _value))
                {
                    return;
                }

                _value = value;
                SetValue(value);
            }
        }

        protected abstract void SetValue(T value);
        protected abstract T GetValue();
        protected abstract bool HasValue(T value);
        protected abstract bool IsSame(T value, T current);

        public override string ToString()
        {
            return Value?.ToString();
        }
    }
}