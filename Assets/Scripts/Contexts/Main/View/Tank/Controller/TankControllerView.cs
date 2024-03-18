using Contexts.Main.View.Characters;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.Tank.Controller
{
  [RequireComponent(typeof(Rigidbody))]
  public class TankControllerView : EventView
  {
    [HideInInspector]
    public float Speed = 15;

    public float RotationalSpeed;
    
    [Header("Input Properties")]
    public Camera Camera;

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
    
    public LayerMask layerMask;

    protected override void Start()
    {
      base.Start();
      
      Rb = gameObject.GetComponent<Rigidbody>();
      Speed = gameObject.GetComponent<Player>().CharacterVo.MovingSpeed;
    }
  }
}