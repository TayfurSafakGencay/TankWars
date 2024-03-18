using System;
using Contexts.Main.Enum;
using Contexts.Main.Model;
using strange.extensions.mediation.impl;
using UnityEngine;

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

    private void Start()
    {
      InvokeRepeating(nameof(GetFPS), 1, 1);
    }

    private void OnObstacleDestroyed()
    {
      view.CoinText.text = mainModel.GetCoin().ToString();
    }

    private void GetFPS()
    {
      view.fps = (int)(1f / Time.unscaledDeltaTime);
      view.FPSText.text = "FPS: " + view.fps;
    }


    public override void OnRemove()
    {
      dispatcher.RemoveListener(MainEvent.ObstacleDestroyed, OnObstacleDestroyed);
    }
  }
}