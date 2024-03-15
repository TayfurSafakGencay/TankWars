using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Contexts.Main.View.Obstacle.ObstacleCreator
{
  public class ObstacleCreatorMediator : EventMediator
  {
    [Inject]
    public ObstacleCreatorView view { get; set; }

    public override void OnRegister()
    {
    }

    private void Start()
    {
      StartCoroutine(WaitStart());
    }

    private void CreateObstacle()
    {
      Vector3 randomPosition = new(Random.Range((int)(-view.SpawnArea.x / 5), (int)(view.SpawnArea.x / 5)), 0f,
        Random.Range((int)(-view.SpawnArea.z / 5), (int)(view.SpawnArea.z / 5)));
      randomPosition *= 5;
      randomPosition.y = 0.5f;

      string key = randomPosition.x + "-" + randomPosition.z;
      
      if (view.CoordinateOfObstacles.Contains(key))
      {
        CreateObstacle();
        return;
      }
      
      view.CoordinateOfObstacles.Add(key);
      
      int obstacleType = Random.Range(0, view.Factories.Count);
      view.Factories[obstacleType].CreateObstacle(randomPosition);
    }

    private IEnumerator WaitStart()
    {
      yield return new WaitForSeconds(0.25f);
      
      int obstacleCount = Random.Range(45, 75);

      for (int i = 0; i < obstacleCount; i++)
      {
        CreateObstacle();
      }
    }

    public override void OnRemove()
    {
    }
  }
}