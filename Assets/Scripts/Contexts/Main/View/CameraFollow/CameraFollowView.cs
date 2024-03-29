﻿using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.CameraFollow
{
  public class CameraFollowView : EventView
  {
    [HideInInspector]
    public Transform Player;

    public Vector3 Offset;

    [HideInInspector]
    public bool StartFollow;
  }
}