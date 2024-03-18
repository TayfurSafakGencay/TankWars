using Contexts.Main.Vo;

namespace Contexts.Main.View.Characters
{
  public class Player : Character
  {
    private void Awake()
    {
      CharacterVo characterVo = new()
      {
        Health = 100,
        MovingSpeed = 50,
        AttackDamage = 20,
      };
      
      Initialize(characterVo);
    }

    public override void TakeDamage(int damage)
    {
      base.TakeDamage(damage);
    }
  }
}