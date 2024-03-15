using System;
using Contexts.Main.Enum;
using Contexts.Main.View.Tank.Bullet;
using Contexts.Main.Vo;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.Tank.Shooting
{
  public class ShootingMediator : EventMediator
  {
    [Inject]
    public ShootingView view { get; set; }

    public override void OnRegister()
    {
      dispatcher.AddListener(MainEvent.ReturnBulletPool, OnReturnBulletPool);
    }

    private void Start()
    {
      dispatcher.Dispatch(MainEvent.GetBulletPool);
    }

    private void OnReturnBulletPool(IEvent payload)
    {
      if (view.BulletsParent)
        return;
      
      ShootVo shootVo = (ShootVo)payload.data;

      view.BulletsParent = shootVo.BulletPool;
      view.ParticlePoolManagerBehaviour = shootVo.ParticlePoolManagerBehaviour;
      
      Transform muzzleTransform = view.Muzzle.transform;
      
      for (int i = 0; i < view.BulletCount; i++)
      {
        GameObject bulletObject = Instantiate(view.Bullet, muzzleTransform.position, muzzleTransform.rotation, view.BulletsParent);
        bulletObject.SetActive(false);
        bulletObject.GetComponent<BulletBehaviour>().SetMuzzle(view.Muzzle);
        view.BulletPool.Add(bulletObject);
      }
    }

    private void Update()
    {
      if (!view.BulletsParent)
        return;
      
      view.RemainTimeToShoot -= Time.deltaTime;
      
      if (!Input.GetKey(KeyCode.Mouse0)) return;
      
      if (view.RemainTimeToShoot >= 0) return;
      
      view.RemainTimeToShoot = view.ShootTime;
      view.BulletPool[view.Queue].SetActive(true);
      view.Queue++;
      view.ShootAnimation();
      view.ParticlePoolManagerBehaviour.PlayParticleEffect(view.Muzzle.position, VFX.Shooting);
      
      if (view.Queue != view.BulletCount) return;
      view.Queue = 0;
    }

    public override void OnRemove()
    {
      dispatcher.RemoveListener(MainEvent.ReturnBulletPool, OnReturnBulletPool);
    }
  }
}