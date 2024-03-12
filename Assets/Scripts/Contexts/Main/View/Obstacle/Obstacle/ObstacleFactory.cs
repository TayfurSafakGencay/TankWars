using UnityEngine;

namespace Contexts.Main.View.Obstacle.Obstacle
{
  public abstract class ObstacleFactory : MonoBehaviour
  {
    public abstract IObstacle CreateObstacle(Vector3 position);
  }
}