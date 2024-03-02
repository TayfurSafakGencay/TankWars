using Contexts.Main.View.CameraFollow;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.Camera.CameraFollow
{
  public class CameraFollowMediator : EventMediator
  {
    [Inject]
    public CameraFollowView view { get; set; }

    public override void OnRegister()
    {
    }

    private void Update()
    {
      if (!view.StartFollow)
        return;
      
      Vector3 targetPosition = view.Player.position + view.Offset;
      transform.position = targetPosition;
    }

    private void OnPlayerCreated(IEvent payload)
    {
      GameObject player = (GameObject)payload.data;

      view.Player = player.transform;
      view.Offset = transform.position - view.Player.position;
      view.StartFollow = true;
    }

    public override void OnRemove()
    {
    }

    
  }
}