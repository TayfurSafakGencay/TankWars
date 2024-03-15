using Contexts.Main.Enum;
using Contexts.Main.View.Tank.Controller;
using UnityEngine;
using Animation = Contexts.Main.Enum.Animation;

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
        Animator.SetFloat(Animation.Speed, TankControllerView.ForwardInput);
      }
      else
      {
        Animator.SetTrigger(Animation.WheelStop);
      }
    }
  }
}