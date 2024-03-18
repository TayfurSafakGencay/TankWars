using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;

namespace Contexts.Main.View.Panel
{
  public class MainScreenPanelView : EventView
  {
    public TextMeshProUGUI CoinText;

    public TextMeshProUGUI FPSText;

    [HideInInspector]
    public float fps;
  }
}