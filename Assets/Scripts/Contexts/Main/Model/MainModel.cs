using System.Collections.Generic;
using Modules.ObstacleColorPalette;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Contexts.Main.Model
{
  public class MainModel : IMainModel
  {
    public Dictionary<int, List<Color>> ColorList { get; set; }

    private int _coin { get; set; }

    private int _stage { get; set; }

    [PostConstruct]
    private void OnPostConstruct()
    {
      ColorList = new Dictionary<int, List<Color>>();
      _stage = 0;
    }
    
    public void StartGame()
    {
      ColorList = new Dictionary<int, List<Color>>();
      
      Addressables.LoadAssetAsync<ObstacleColor>("ObstacleColor").Completed += FillColorList;
    }

    public void AddCoin(int coin)
    {
      _coin += coin;
    }

    public int GetCoin()
    {
      return _coin;
    }

    public void NextStage()
    {
      _stage++;
    }

    public int GetStage()
    {
      return _stage;
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