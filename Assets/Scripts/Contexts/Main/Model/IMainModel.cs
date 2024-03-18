using System.Collections.Generic;
using UnityEngine;

namespace Contexts.Main.Model
{
  public interface IMainModel
  {
    Dictionary<int, List<Color>> ColorList { get; set; }

    void StartGame();

    void AddCoin(int coin);

    int GetCoin();

    void NextStage();
    
    int GetStage();
  }
}