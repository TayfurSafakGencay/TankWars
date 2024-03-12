using Contexts.Main.Enum;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.CameraFollow
{
  public class CameraFollowMediator : EventMediator
  {
    [Inject]
    public CameraFollowView view { get; set; }

    public override void OnRegister()
    {
      dispatcher.AddListener(MainEvent.PlayerCreated, OnPlayerCreated);
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
      
      dispatcher.Dispatch(MainEvent.CameraSet, gameObject.GetComponent<Camera>());
    }

    public override void OnRemove()
    {
      dispatcher.RemoveListener(MainEvent.PlayerCreated, OnPlayerCreated);
    }
  }
}