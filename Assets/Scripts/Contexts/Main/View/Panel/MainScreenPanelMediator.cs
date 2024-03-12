using Contexts.Main.Enum;
using Contexts.Main.Model;
using strange.extensions.mediation.impl;

namespace Contexts.Main.View.Panel
{
  public class MainScreenPanelMediator : EventMediator
  {
    [Inject]
    public MainScreenPanelView view { get; set; }

    [Inject]
    public IMainModel mainModel { get; set; }

    public override void OnRegister()
    {
      dispatcher.AddListener(MainEvent.ObstacleDestroyed, OnObstacleDestroyed);
    }

    private void OnObstacleDestroyed()
    {
      view.CoinText.text = mainModel.GetCoin().ToString();
    }


    public override void OnRemove()
    {
      dispatcher.RemoveListener(MainEvent.ObstacleDestroyed, OnObstacleDestroyed);
    }
  }
}