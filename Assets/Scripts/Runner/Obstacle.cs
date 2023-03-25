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
    }


    public class Obstacle : MonoBehaviour, IObstacle
    {
        [SerializeField] private ObstacleType obstacleType;

        public ObstacleType ObstacleType => obstacleType;
    }
}