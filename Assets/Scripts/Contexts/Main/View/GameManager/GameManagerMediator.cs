using System;
using Contexts.Main.Enum;
using Contexts.Main.Model;
using Contexts.Main.Vo;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Contexts.Main.View.GameManager
{
  public class GameManagerMediator : EventMediator
  {
    [Inject]
    public GameManagerView view { get; set; }
    
    [Inject]
    public IMainModel mainModel { get; set; }
    
    public override void OnRegister()
    {
      dispatcher.AddListener(MainEvent.GetBulletPool, OnGetBulletPool);
      
      Init();
    }

    private void Init()
    {
      mainModel.StartGame();
      
      CreateObjectFromAddressable(AddressableKey.Player);
    }

    private void CreateObjectFromAddressable(string addressableKey)
    {
      Addressables.InstantiateAsync(addressableKey).Completed += handle =>
      {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
          GameObject instance = handle.Result;
          instance.transform.parent = transform.parent;
          view.SetPlayer(instance.transform);
        }
        else
        {
          Debug.LogError($"Object could not be created! Key: {addressableKey}");
        }
      };
    }

    private void OnGetBulletPool()
    {
      ShootVo shootVo = new()
      {
        BulletPool = view.BulletPool,
        ParticlePoolManagerBehaviour = view.ParticlePoolManagerBehaviour
      };
      dispatcher.Dispatch(MainEvent.ReturnBulletPool, shootVo);
    }

    public override void OnRemove()
    {
      dispatcher.RemoveListener(MainEvent.GetBulletPool, OnGetBulletPool);
    }
  }
}