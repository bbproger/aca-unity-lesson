using System;
using UnityEngine;

namespace DefaultNamespace.Runner
{
    public class GameplayAggregator : MonoBehaviour
    {
        [SerializeField] private RoadSpawner roadSpawner;
        [SerializeField] private MobileInput input;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerCollision playerCollision;


        private void OnEnable()
        {
            playerCollision.OnCollisionObstacle += OnPlayerCollisionObstacle;
        }

        private void OnDisable()
        {
            playerCollision.OnCollisionObstacle -= OnPlayerCollisionObstacle;
        }

        [ContextMenu("Play")]
        public void Init()
        {
            roadSpawner.Init();
            SetComponentActiveState(true);
        }

        private void Update()
        {
            roadSpawner.UpdateFrame();
            input.UpdateFrame();
        }

        private void SetComponentActiveState(bool state)
        {
            input.SetInteractableState(state);
            playerMovement.SetBlockState(state);
            roadSpawner.SetCanSpawnState(state);
        }

        private void OnPlayerCollisionObstacle(IObstacle obstacle)
        {
            SetComponentActiveState(false);
        }
    }
}