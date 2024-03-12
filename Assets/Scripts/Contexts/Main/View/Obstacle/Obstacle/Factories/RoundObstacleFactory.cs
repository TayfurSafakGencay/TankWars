using Contexts.Main.View.Obstacle.Obstacle.ObstacleTypes;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.Obstacle.Factories
{
  public class RoundObstacleFactory : ObstacleFactory
  {
    [SerializeField]
    private RoundObstacle roundObstacle;

    [SerializeField]
    private Transform ObstaclePool;
    
    public override IObstacle CreateObstacle(Vector3 position)
    {
      GameObject roundInstance = Instantiate(roundObstacle.gameObject, position, Quaternion.identity, ObstaclePool);
      RoundObstacle newRound = roundInstance.GetComponent<RoundObstacle>();
      
      newRound.Initialize();

      return newRound;
    }
  }
}