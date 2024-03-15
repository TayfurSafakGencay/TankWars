using System.Collections.Generic;
using Contexts.Main.View.Particle;
using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Serialization;

namespace Contexts.Main.View.Tank.Shooting
{
  public class ShootingView : EventView
  {
    public Transform Muzzle;
    
    public GameObject Bullet;
    
    [HideInInspector]
    public Transform BulletsParent;
    
    public Transform MuzzleCannon;
    
    public int BulletCount = 80;
    
    [HideInInspector]
    public List<GameObject> BulletPool;
    
    [HideInInspector]
    public int Queue;
    
    // [HideInInspector]
    public float ShootTime = 0f;
    
    [HideInInspector]
    public float RemainTimeToShoot;

    [HideInInspector]
    public ParticlePoolManagerBehaviour ParticlePoolManagerBehaviour;

    protected override void Start()
    {
      base.Start();
      RemainTimeToShoot = ShootTime;
    }

    public void ShootAnimation()
    {
      MuzzleCannon.DOScaleX(1.5f, 0.5f).OnComplete(() => { MuzzleCannon.DOScaleX(1f, 0.5f); });
      
      MuzzleCannon.DOScaleY(1.5f, 0.5f).OnComplete(() => { MuzzleCannon.DOScaleY(1f, 0.5f); });
    }
  }
}