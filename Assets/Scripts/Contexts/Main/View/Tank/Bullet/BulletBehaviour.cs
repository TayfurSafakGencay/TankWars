using System.Collections;
using UnityEngine;

namespace Contexts.Main.View.Tank.Bullet
{
  public class BulletBehaviour : MonoBehaviour
  {
    public Rigidbody Rigidbody;

    public TrailRenderer TrailRenderer;

    public int BulletSpeed;

    private Transform MuzzlePosition;

    public void SetMuzzle(Transform muzzle)
    {
      MuzzlePosition = muzzle;
    }

    private void OnEnable()
    {
      if (!MuzzlePosition)
        return;
      
      gameObject.transform.position = MuzzlePosition.position;
      
      Vector3 forward = MuzzlePosition.forward;
      Quaternion world = Quaternion.LookRotation(-forward);
      transform.localRotation = world;
      
      Rigidbody.velocity = forward * BulletSpeed;

      StartCoroutine(WaitBulletRange());
    }

    private void OnDisable()
    {
      Rigidbody.velocity = Vector3.zero;
      TrailRenderer.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.layer == 7)
        return;
      // if (other.gameObject.CompareTag(Tags.Projectile.ToString()))
      //   return;
      Rigidbody.velocity = Vector3.zero;
      gameObject.SetActive(false);
    }

    private IEnumerator WaitBulletRange()
    {
      yield return new WaitForSeconds(3f);
      gameObject.SetActive(false);
    }
  }
}