using Contexts.Main.View.Particle;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.GameManager
{
  public class GameManagerView : EventView
  {
    public Transform BulletPool;

    public ParticlePoolManagerBehaviour ParticlePoolManagerBehaviour;

    public static Transform Player;

    public void SetPlayer(Transform player)
    {
      Player = player;
    }
  }
}