using Contexts.Main.Enum;
using Contexts.Main.Model;
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
    }

    private void Start()
    {
      Init();
    }

    private void Init()
    {
      mainModel.StartGame();
      
      CreateObjectFromAddressable(AddressableKey.ObstacleFactory);
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
        }
        else
        {
          Debug.LogError($"Object could not be created! Key: {addressableKey}");
        }
      };
    }

    private void OnGetBulletPool()
    {
      dispatcher.Dispatch(MainEvent.ReturnBulletPool, view.BulletPool);
    }

    public override void OnRemove()
    {
      dispatcher.RemoveListener(MainEvent.GetBulletPool, OnGetBulletPool);
    }
  }
}