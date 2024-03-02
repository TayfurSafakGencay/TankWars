using System.Collections.Generic;
using Contexts.Main.View.Tank.Bullet;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.Tank.Shooting
{
  public class ShootingView : EventView
  {
    public Transform Muzzle;

    public GameObject Bullet;

    public Transform BulletsParent;
    
    public int BulletCount = 20;
    
    [HideInInspector]
    public List<GameObject> BulletPool;

    [HideInInspector]
    public int Queue;

    protected override void Start()
    {
      Transform muzzleTransform = Muzzle.transform;

      for (int i = 0; i < BulletCount; i++)
      {
        GameObject bulletObject = Instantiate(Bullet, muzzleTransform.position, muzzleTransform.rotation, BulletsParent);
        bulletObject.SetActive(false);
        bulletObject.GetComponent<BulletBehaviour>().SetMuzzle(Muzzle);
        BulletPool.Add(bulletObject);
      }
    }
  }
}