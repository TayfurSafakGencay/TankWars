using System.Collections.Generic;
using Contexts.Main.View.Obstacle.Obstacle;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.ObstacleCreator
{
  public class ObstacleCreatorView : EventView
  {
    public Vector3 SpawnArea = new(50, 0, 100);

    public List<ObstacleFactory> Factories;

    [HideInInspector]
    public List<string> CoordinateOfObstacles; 
  }
}