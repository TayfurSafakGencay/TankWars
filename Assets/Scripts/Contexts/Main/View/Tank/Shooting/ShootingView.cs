using System.Collections.Generic;
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
    
    public int BulletCount = 40;
    
    [HideInInspector]
    public List<GameObject> BulletPool;
    
    [HideInInspector]
    public int Queue;
    
    [HideInInspector]
    public float ShootTime = 0.7f;
    
    [HideInInspector]
    public float RemainTimeToShoot;

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