using System;
using Contexts.Main.Enum;
using UnityEngine;

namespace Contexts.Main.Vo
{
  [Serializable]
  public class ParticleEffectVo
  {
    public VFX Name;

    public ParticleSystem ParticleSystem;

    public int Count;
  }
}