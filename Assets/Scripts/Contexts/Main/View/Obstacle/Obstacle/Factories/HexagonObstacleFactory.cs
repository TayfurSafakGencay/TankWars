using Contexts.Main.View.Obstacle.Obstacle.ObstacleTypes;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.Obstacle.Factories
{
  public class HexagonObstacleFactory : ObstacleFactory
  {
    [SerializeField]
    private HexagonObstacle hexagonObstacle;

    [SerializeField]
    private Transform ObstaclePool;
    
    public override IObstacle CreateObstacle(Vector3 position)
    {
      GameObject hexagonInstance = Instantiate(hexagonObstacle.gameObject, position, Quaternion.identity, ObstaclePool);
      HexagonObstacle hewHexagon = hexagonInstance.GetComponent<HexagonObstacle>();
      
      hewHexagon.Initialize();

      return hewHexagon;
    }
  }
}