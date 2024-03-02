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
    }

    private void Update()
    {
      if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
      
      view.BulletPool[view.Queue].SetActive(true);
      view.Queue++;
      
      if (view.Queue != 20) return;
      view.Queue = 0;
    }

    public override void OnRemove()
    {
    }
  }
}