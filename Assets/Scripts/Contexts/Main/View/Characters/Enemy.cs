using System;
using System.Collections;
using Contexts.Main.Enum;
using Contexts.Main.Vo;
using UnityEngine;
using UnityEngine.AI;

namespace Contexts.Main.View.Characters
{
  public class Enemy : Character
  {
    [SerializeField]
    private NavMeshAgent NavMeshAgent;
    
    private Transform _playerTransform;

    private Player _player;

    private MeshRenderer _meshRenderer;
    
    private readonly Color _normalColor = Color.blue;

    private void Start()
    {
      NavMeshAgent.speed = CharacterVo.MovingSpeed;

      _playerTransform = GameManager.GameManagerView.Player;
      _player = _playerTransform.GetComponent<Player>();
      _meshRenderer = transform.GetComponent<MeshRenderer>();

      _meshRenderer.material.color = _normalColor;
    }

    public void SetStatsForCurrentStage(int stage)
    {
      CharacterVo characterVo = new()
      {
        Health = stage * 40,
        MovingSpeed = 5,
        AttackDamage = 10,
      };
      
      Initialize(characterVo);
    }

    private void Update()
    {
      NavMeshAgent.destination = _playerTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag(Tag.Projectile.ToString()))
      {
        TakeDamage(_player.CharacterVo.AttackDamage);
      }
    }

    private void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.CompareTag(Tag.Player.ToString()))
      {
        DoDamage();
      }
    }

    private const float _takeDamageChangeColor = 0.2f;

    private readonly Color _damageColor = Color.red;
    public override void TakeDamage(int damage)
    {
      base.TakeDamage(damage);

      if (Death)
        return;

      _meshRenderer.material.color = _damageColor;
      StartCoroutine(WaitChangeMaterialColor(_takeDamageChangeColor, _normalColor));
    }

    private const float _deathSetActive = 0.2f;
    
    private readonly Color _deadColor = Color.gray;

    protected override void Dead()
    {
      base.Dead();

      _meshRenderer.material.color = _deadColor;
      StartCoroutine(WaitDead(_deathSetActive));
    }

    private void DoDamage()
    {
      _player.TakeDamage(CharacterVo.AttackDamage);
      
      gameObject.SetActive(false);
    }
    
    private IEnumerator WaitDead(float time)
    {
      yield return new WaitForSeconds(time);
      gameObject.SetActive(false);
    }
    
    private IEnumerator WaitChangeMaterialColor(float time, Color color)
    {
      yield return new WaitForSeconds(time);
      _meshRenderer.material.color = color;
    }
  }
}