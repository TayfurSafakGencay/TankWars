using Contexts.Main.Model;
using Contexts.Main.View.CameraFollow;
using Contexts.Main.View.GameManager;
using Contexts.Main.View.Obstacle.Obstacle.ObstacleFactoryManager;
using Contexts.Main.View.Obstacle.ObstacleCreator;
using Contexts.Main.View.Panel;
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

      injectionBinder.Bind<IMainModel>().To<MainModel>().ToSingleton();
      
      mediationBinder.Bind<TankControllerView>().To<TankControllerMediator>();
      mediationBinder.Bind<GameManagerView>().To<GameManagerMediator>();
      mediationBinder.Bind<CameraFollowView>().To<CameraFollowMediator>();
      mediationBinder.Bind<ObstacleCreatorView>().To<ObstacleCreatorMediator>();
      mediationBinder.Bind<ObstacleFactoryManagerView>().To<ObstacleFactoryManagerMediator>();
      mediationBinder.Bind<ShootingView>().To<ShootingMediator>();

      mediationBinder.Bind<MainScreenPanelView>().To<MainScreenPanelMediator>();
    }
  }
}