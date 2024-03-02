using strange.extensions.mediation.impl;
using UnityEngine;

namespace Contexts.Main.View.Tank.Controller
{
  public class TankControllerMediator : EventMediator
  {
    [Inject]
    public TankControllerView view { get; set; }

    public override void OnRegister()
    {
    }

    private void Update()
    {
      if (view.Camera)
      {
        HandleInput();
      }

      if (!view.Rb) return;
      HandleMovement();
      HandleTurret();
      HandleReticle();
    }

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawSphere(view.ReticlePosition, 0.5f);
    }

    protected virtual void HandleInput()
    {
      Ray screenRay = view.Camera.ScreenPointToRay(Input.mousePosition);

      if (!Physics.Raycast(screenRay, out RaycastHit hit)) return;
      
      view.ReticlePosition = hit.point;
      view.ReticleNormal = hit.normal;

      view.ForwardInput = Input.GetAxis("Vertical");
      view.RotationInput = Input.GetAxis("Horizontal");
    }

    protected virtual void HandleTurret()
    {
      if (!view.TurretTransform)
        return;

      Vector3 turretLookDirection = view.ReticlePosition - view.TurretTransform.position;
      turretLookDirection.y = 0;
      
      view.TurretTransform.rotation = Quaternion.LookRotation(turretLookDirection);
    }
    protected virtual void HandleReticle()
    {
      if (!view.ReticleTransform)
        return;
      
      view.ReticleTransform.position = view.ReticlePosition;
    }

    protected virtual void HandleMovement()
    {
      Transform transformObject = transform;
      Vector3 wantedPosition = transformObject.position + transformObject.forward * view.ForwardInput * view.Speed * Time.deltaTime;
      view.Rb.MovePosition(wantedPosition);
      
      Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * (view.RotationalSpeed * view.RotationInput * Time.deltaTime));
      view.Rb.MoveRotation(wantedRotation);
      
    }
    
    public override void OnRemove()
    {
    }
  }
}