using UnityEngine;

namespace DefaultNamespace.Runner.UI
{
    public class ViewService : MonoBehaviour
    {
        private const string VIEW_PATH = "Prefabs/UI/View";
        [SerializeField] private RectTransform viewContainer;

        public TView LoadView<TView>() where TView : AbstractView
        {
            string viewName = typeof(TView).Name;
            TView viewPrefab = Resources.Load<TView>($"{VIEW_PATH}/{viewName}");
            return Object.Instantiate(viewPrefab, viewContainer);
        }
    }
}