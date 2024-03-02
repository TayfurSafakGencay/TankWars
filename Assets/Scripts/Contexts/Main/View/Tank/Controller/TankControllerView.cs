using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.Tank.Controller
{
  [RequireComponent(typeof(Rigidbody))]
  public class TankControllerView : EventView
  {
    public float Speed = 15;

    public float RotationalSpeed;
    
    [Header("Input Properties")]
    public UnityEngine.Camera Camera;

    [HideInInspector]
    public Vector3 ReticlePosition;

    [HideInInspector]
    public Vector3 ReticleNormal;

    [HideInInspector]
    public float ForwardInput;

    [HideInInspector]
    public float RotationInput;
    
    [HideInInspector]
    public Rigidbody Rb;

    public Transform ReticleTransform;

    public Transform TurretTransform;

    protected override void Start()
    {
      Rb = gameObject.GetComponent<Rigidbody>();
    }

    public void WheelAnimation()
    {
      // Dot
    }
  }
}