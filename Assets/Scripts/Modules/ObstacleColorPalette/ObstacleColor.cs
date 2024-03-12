using System.Collections.Generic;
using UnityEngine;

namespace Modules.ObstacleColorPalette
{
  [CreateAssetMenu(fileName = "ObstacleColor", menuName = "Obstacle Color")]
  public class ObstacleColor : ScriptableObject
  {
    public List<Color> firstColorPalette;
    
    public List<Color> secondColorPalette;
    
    public List<Color> thirdColorPalette;
    
    public List<Color> fourthColorPalette;
  }
}