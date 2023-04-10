using UnityEngine;

namespace DefaultNamespace.Runner
{
    public enum ObstacleType
    {
        Trash,
        Table
    }

    public interface IObstacle : IEntity
    {
        ObstacleType ObstacleType { get; }
        void SetObstacleState(bool state);
    }


    public class Obstacle : MonoBehaviour, IObstacle
    {
        [SerializeField] private ObstacleType obstacleType;
        [SerializeField] private Collider collider;

        public ObstacleType ObstacleType => obstacleType;

        public void SetObstacleState(bool state)
        {
            collider.enabled = state;
        }
    }
}