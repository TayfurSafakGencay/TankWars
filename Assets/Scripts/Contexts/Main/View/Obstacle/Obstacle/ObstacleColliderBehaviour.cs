using System;
using Contexts.Main.Enum;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.Obstacle
{
  public class ObstacleColliderBehaviour : MonoBehaviour
  {
    private IObstacle IObstacle;

    private void Awake()
    {
      IObstacle = transform.parent.GetComponent<IObstacle>();
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag(Tag.Projectile.ToString()))
      {
        IObstacle.OnHitProjectile(other.gameObject.transform.position);
      }
    }
  }
}