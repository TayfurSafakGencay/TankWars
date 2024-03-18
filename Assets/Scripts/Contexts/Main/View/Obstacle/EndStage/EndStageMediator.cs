using System.Collections;
using Contexts.Main.Enum;
using Contexts.Main.Model;
using Contexts.Main.View.Characters;
using Contexts.Main.Vo;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.EndStage
{
  public class EndStageMediator : EventMediator
  {
    [Inject]
    public EndStageView view { get; set; }
    
    [Inject]
    public IMainModel mainModel { get; set; }

    public override void OnRegister()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
      if (!other.gameObject.CompareTag(Tag.Player.ToString()))
        return;
      
      OnStageActivated();
    }

    private void OnStageActivated()
    {
      if (view.StageActivated)
        return;

      view.StageActivated = true;
      mainModel.NextStage();
      int stage = mainModel.GetStage();

      int enemyCount = 10 + 10 * stage;
      StartCoroutine(CallEnemies(enemyCount, stage));
    }

    private IEnumerator CallEnemies(int enemyCount, int stage)
    {
      for (int i = 0; i < enemyCount; i++)
      {
        int spawnPoint = Random.Range(0, view.SpawnPoints.Count);
        
        GameObject instantiate = Instantiate(view.Enemy, view.SpawnPoints[spawnPoint].position, Quaternion.identity, view.EnemyPool);
        Enemy enemy = instantiate.GetComponent<Enemy>();
        enemy.SetStatsForCurrentStage(stage);
        
        yield return new WaitForSeconds(0.25f);
      }
    }
    
    public override void OnRemove()
    {
    }
  }
}