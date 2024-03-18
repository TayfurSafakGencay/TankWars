using System.Collections;
using Contexts.Main.Model;
using strange.extensions.mediation.impl;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Contexts.Main.View.Obstacle.ObstacleCreator
{
  public class ObstacleCreatorMediator : EventMediator
  {
    [Inject]
    public ObstacleCreatorView view { get; set; }
    
    [Inject]
    public IMainModel mainModel { get; set; }

    public override void OnRegister()
    {
    }

    private void Start()
    {
      StartCoroutine(WaitStart());
    }
    
    private IEnumerator WaitStart()
    {
      yield return new WaitForSeconds(0.25f);
      
      int obstacleCount = Random.Range(10, 15);

      for (int i = 0; i < obstacleCount; i++)
      {
        CreateObstacle();
        yield return new WaitForSeconds(0.1f);
      }
      
      StageEndCreator();
    }

    private void CreateObstacle()
    {
      view.CoordinateOfObstacles.Clear();
      
      Vector3 randomPosition = new(Random.Range(-view.Width, view.Width + 1), 0f,
        Random.Range(3, 28));
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

    private void StageEndCreator()
    {
      int stage = mainModel.GetStage();
      int zPos = (stage + 1) * 200;

      Instantiate(view.EndStage, new Vector3(0, 0, zPos), Quaternion.identity, transform.root);
    }

    public override void OnRemove()
    {
    }
  }
}