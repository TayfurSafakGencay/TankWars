using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.EndStage
{
  public class EndStageView : EventView
  {
    [HideInInspector]
    public bool StageActivated;
    
    public GameObject Enemy;

    public GameObject Boss;

    public List<Transform> SpawnPoints;

    public Transform EnemyPool;
  }
}