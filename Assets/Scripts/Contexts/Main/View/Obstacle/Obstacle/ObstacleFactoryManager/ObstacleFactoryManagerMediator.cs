using System.Collections.Generic;
using Contexts.Main.Enum;
using Contexts.Main.Model;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.Obstacle.ObstacleFactoryManager
{
  public class ObstacleFactoryManagerMediator : EventMediator
  {
    [Inject]
    public ObstacleFactoryManagerView view { get; set; }
    
    [Inject]
    public IMainModel mainModel { get; set; }

    public override void OnRegister()
    {
    }

    public List<Color> GetColorSet()
    {
      return mainModel.ColorList[Random.Range(0, 3)];
    }

    public void ObstacleDestroyed(int floorCount)
    {
      mainModel.AddCoin(floorCount); 
      
      dispatcher.Dispatch(MainEvent.ObstacleDestroyed);
    }

    public override void OnRemove()
    {
    }
  }
}