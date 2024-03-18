using System.Collections.Generic;
using Contexts.Main.View.Obstacle.Obstacle.ObstacleFactoryManager;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Contexts.Main.View.Obstacle.Obstacle.ObstacleTypes
{
  public class HeptagonObstacle : MonoBehaviour, IObstacle
  {
    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private Material materialPrefab;

    [SerializeField]
    private TextMeshProUGUI _countText;

    [SerializeField]
    private Transform _countTextObject;
    
    private List<Color> colorSet;

    private ObstacleFactoryManagerMediator obstacleFactoryManagerMediator;

    private int floorCount;

    private int _health;

    private Vector3 objectPosition;

        public void Initialize()
    {
      objectPosition = transform.position;
      objectPosition.y = 0.5f;

      obstacleFactoryManagerMediator = transform.parent.parent.GetComponent<ObstacleFactoryManagerMediator>();
      colorSet = obstacleFactoryManagerMediator.GetColorSet();

      floorCount = Random.Range(5, 10);
      _health = floorCount;
      Vector3 position = new(0, 0, 0);
      Quaternion rotation = new(0, 0, 0, 0);

      for (int i = 0; i < floorCount; i++)
      {
        Material newMaterial = CreateMaterial(i);
        GameObject instantiate = Instantiate(obstacle, position, rotation, transform);
        instantiate.transform.localPosition = position;
        instantiate.GetComponent<MeshRenderer>().material = newMaterial;
        position.y++;
        rotation.eulerAngles += new Vector3(0, 5, 0);

        if (i != floorCount - 1) continue;

        _countTextObject.parent = instantiate.transform;
        _countTextObject.localPosition = new Vector3(1f, -4.4f, 1f);
      }

      _countText.text = floorCount.ToString();
      _countTextObject.parent = transform;

      StartAnimation();
    }

    private Material CreateMaterial(int index)
    {
      Material material = new(materialPrefab);
      Color color = colorSet[index];

      // material.SetColor("_EmissiveColor", color * 0.5f);
      material.color = color;

      return material;
    }

    public void OnHitProjectile(Vector3 position)
    {
      _health--;
      _countText.text = _health.ToString();

      HitAnimation();

      if (_health > 0)
      {
        obstacleFactoryManagerMediator.OnHitObstacle(position);
        return;
      }

      obstacleFactoryManagerMediator.ObstacleDestroyed(floorCount, objectPosition);
      gameObject.SetActive(false);
    }

    private void StartAnimation()
    {
      transform.DOScale(1.2f, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
        transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InBack));
    }

    private void HitAnimation()
    {
      Transform objectTransform = transform;

      objectTransform.position -= new Vector3(0, 1, 0);

      objectTransform.DOScaleX(1.2f, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
        objectTransform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InBack));
      objectTransform.DOScaleZ(1.2f, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
        objectTransform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InBack));
      objectTransform.DORotate(objectTransform.eulerAngles + new Vector3(0f, 10, 0f), 0.1f);
      _countTextObject.transform.localRotation = Quaternion.Inverse(transform.rotation);
    }
  }
}