using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.Runner
{
    public class GameplayAggregator : MonoBehaviour
    {
        [SerializeField] private RoadSpawner roadSpawner;
        [SerializeField] private MobileInput input;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerCollision playerCollision;

        public UnityEvent<int> OnDistanceChanged { get; } = new UnityEvent<int>();
        public UnityEvent<int> OnGameEnd { get; } = new UnityEvent<int>();

        private bool _isRunning;
        

        private void OnEnable()
        {
            playerCollision.OnCollisionObstacle += OnPlayerCollisionObstacle;
        }

        private void OnDisable()
        {
            playerCollision.OnCollisionObstacle -= OnPlayerCollisionObstacle;
        }

        public void Init()
        {
            roadSpawner.Init();
        }

        public void ResetGame()
        {
            roadSpawner.ResetSpawner();
            playerMovement.ResetPlayer();
        }
        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            roadSpawner.UpdateFrame();
            input.UpdateFrame();
            OnDistanceChanged?.Invoke(Mathf.Max(0, Mathf.RoundToInt(playerMovement.transform.position.z)));
        }

        public void SetComponentActiveState(bool state)
        {
            _isRunning = state;
            input.SetInteractableState(state);
            playerMovement.SetBlockState(state);
            roadSpawner.SetCanSpawnState(state);
        }

        private void OnPlayerCollisionObstacle(IObstacle obstacle)
        {
            SetComponentActiveState(false);
            int distance = Mathf.Max(0, Mathf.RoundToInt(playerMovement.transform.position.z));
            Store.BestScore.Value = distance;
            OnGameEnd?.Invoke(distance);
        }
    }
}