using Contexts.Main.View.Obstacle.Obstacle.ObstacleTypes;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.Obstacle.Factories
{
  public class OctagonObstacleFactory : ObstacleFactory
  {
    [SerializeField]
    private OctagonObstacle octagonObstacle;

    [SerializeField]
    private Transform ObstaclePool;
    
    public override IObstacle CreateObstacle(Vector3 position)
    {
      GameObject octagonInstance = Instantiate(octagonObstacle.gameObject, position, Quaternion.identity, ObstaclePool);
      OctagonObstacle newOctagon = octagonInstance.GetComponent<OctagonObstacle>();
      
      newOctagon.Initialize();

      return newOctagon;
    }
  }
}