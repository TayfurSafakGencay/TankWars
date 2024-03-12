using System.Collections.Generic;
using Modules.ObstacleColorPalette;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Contexts.Main.Model
{
  public class MainModel : IMainModel
  {
    private int Coin { get; set; }
    public Dictionary<int, List<Color>> ColorList { get; set; }

    [PostConstruct]
    private void OnPostConstruct()
    {
      ColorList = new Dictionary<int, List<Color>>();
    }
    
    public void StartGame()
    {
      ColorList = new Dictionary<int, List<Color>>();
      
      Addressables.LoadAssetAsync<ObstacleColor>("ObstacleColor").Completed += FillColorList;
    }

    public void AddCoin(int coin)
    {
      Coin += coin;
    }

    public int GetCoin()
    {
      return Coin;
    }
    
    public void FillColorList(AsyncOperationHandle<ObstacleColor> handle)
    {
      if (handle.Status == AsyncOperationStatus.Succeeded)
      {
        ObstacleColor obstacleColor = handle.Result;
        ColorList.Add(0, obstacleColor.firstColorPalette);
        ColorList.Add(1, obstacleColor.secondColorPalette);
        ColorList.Add(2, obstacleColor.thirdColorPalette);
        ColorList.Add(3, obstacleColor.fourthColorPalette);
      }
      else
      {
        Debug.LogError("Failed to load the ObstacleColor.");
      }
    }
  }
}