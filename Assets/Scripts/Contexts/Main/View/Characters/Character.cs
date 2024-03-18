using Contexts.Main.Vo;
using UnityEngine;

namespace Contexts.Main.View.Characters
{
  public abstract class Character : MonoBehaviour
  {
    public CharacterVo CharacterVo { get; protected set; }

    protected bool Death { get; set; }

    public void Initialize(CharacterVo vo)
    {
      CharacterVo = vo;
    }

    public virtual void TakeDamage(int damage)
    {
      CharacterVo.Health -= damage;
      
      if (CharacterVo.Health > 0 || Death) return;
      
      Dead();
    }

    protected virtual void Dead()
    {
      Death = true;
    }
  }
}