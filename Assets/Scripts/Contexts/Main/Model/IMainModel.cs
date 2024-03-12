using System.Collections.Generic;
using UnityEngine;

namespace Contexts.Main.Model
{
  public interface IMainModel
  {
    void StartGame();

    void AddCoin(int coin);

    int GetCoin();

    Dictionary<int, List<Color>> ColorList { get; set; }
  }
}