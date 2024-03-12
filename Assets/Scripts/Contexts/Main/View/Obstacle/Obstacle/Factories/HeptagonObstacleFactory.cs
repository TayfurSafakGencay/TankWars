using Contexts.Main.View.Obstacle.Obstacle.ObstacleTypes;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.Obstacle.Factories
{
  public class HeptagonObstacleFactory : ObstacleFactory
  {
    [SerializeField]
    private HeptagonObstacle heptagonObstacle;

    [SerializeField]
    private Transform ObstaclePool;
    
    public override IObstacle CreateObstacle(Vector3 position)
    {
      GameObject heptagonInstance = Instantiate(heptagonObstacle.gameObject, position, Quaternion.identity, ObstaclePool);
      HeptagonObstacle newHeptagon = heptagonInstance.GetComponent<HeptagonObstacle>();
      
      newHeptagon.Initialize();

      return newHeptagon;
    }
  }
}