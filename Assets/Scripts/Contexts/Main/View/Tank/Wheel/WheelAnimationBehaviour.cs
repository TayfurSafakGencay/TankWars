using Contexts.Main.Enum;
using Contexts.Main.View.Tank.Controller;
using UnityEngine;

namespace Contexts.Main.View.Tank.Wheel
{
  public class WheelAnimationBehaviour : MonoBehaviour
  {
    public TankControllerView TankControllerView;

    private Animator Animator;

    private void Start()
    {
      Animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
      if (TankControllerView.ForwardInput > 0)
      {
        Animator.SetFloat(Animations.Speed, TankControllerView.ForwardInput);
      }
      else
      {
        Animator.SetTrigger(Animations.WheelStop);
      }
    }
  }
}