using Contexts.Main.View.Obstacle.Obstacle.ObstacleTypes;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.Obstacle.Factories
{
  public class PentagonObstacleFactory : ObstacleFactory
  {
    [SerializeField]
    private PentagonObstacle pentagonObstacle;

    [SerializeField]
    private Transform ObstaclePool;
    
    public override IObstacle CreateObstacle(Vector3 position)
    {
      GameObject pentagonInstance = Instantiate(pentagonObstacle.gameObject, position, Quaternion.identity, ObstaclePool);
      PentagonObstacle newPentagon = pentagonInstance.GetComponent<PentagonObstacle>();
      
      newPentagon.Initialize();

      return newPentagon;
    }
  }
}