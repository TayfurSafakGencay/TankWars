using Contexts.Main.View.Camera.CameraFollow;
using Contexts.Main.View.CameraFollow;
using Contexts.Main.View.Tank.Controller;
using Contexts.Main.View.Tank.Shooting;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Contexts.Main.Config
{
  public class MainContext : MVCSContext
  {
    public MainContext(MonoBehaviour view) : base(view)
    {
    }

    public MainContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }

    protected override void mapBindings()
    {
      base.mapBindings();

      mediationBinder.Bind<TankControllerView>().To<TankControllerMediator>();
      mediationBinder.Bind<CameraFollowView>().To<CameraFollowMediator>();
      mediationBinder.Bind<ShootingView>().To<ShootingMediator>();
    }
  }
}