using UnityEngine;

namespace Contexts.Main.View.Particle.ParticleSoundBehaviour
{
  [RequireComponent(typeof(AudioSource))]
  public class ParticleSoundBehaviour : MonoBehaviour
  {
    private AudioSource _audioSource;

    private void Awake()
    {
      _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
      _audioSource.Play();
    }

    private void OnDisable()
    {
      _audioSource.Stop();
    }
  }
}