﻿using UnityEngine;

namespace Contexts.Main.View.Obstacle.Obstacle
{
  public interface IObstacle
  {
    void Initialize();
    
    void OnHitProjectile(Vector3 position);
  }
}