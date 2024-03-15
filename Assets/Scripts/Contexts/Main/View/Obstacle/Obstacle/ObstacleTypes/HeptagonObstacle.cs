using System.Collections.Generic;
using Contexts.Main.View.Obstacle.Obstacle.ObstacleFactoryManager;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Contexts.Main.View.Obstacle.Obstacle.ObstacleTypes
{
  public class HeptagonObstacle : MonoBehaviour, IObstacle
  {
    [SerializeField]
    private GameObject heptagonObstacle;

    [SerializeField]
    private Material materialPrefab;

    private List<Color> colorSet;

    private ObstacleFactoryManagerMediator obstacleFactoryManagerMediator;
    
    private int floorCount;

    private int hitCount;
    
    private Vector3 objectPosition;
    
    public void Initialize()
    {
      objectPosition = transform.position;
      objectPosition.y = 0.5f;
      
      obstacleFactoryManagerMediator = transform.parent.parent.GetComponent<ObstacleFactoryManagerMediator>();
      colorSet = obstacleFactoryManagerMediator.GetColorSet();
      
      floorCount = Random.Range(5, 10);
      Vector3 position = new(0, 0, 0);
      Quaternion rotation = new(0, 0, 0, 0);

      for (int i = 0; i < floorCount; i++)
      {
        Material newMaterial = CreateMaterial(i);
        GameObject heptagonObstacleInstantiate = Instantiate(heptagonObstacle, position, rotation, transform);
        heptagonObstacleInstantiate.transform.localPosition = position;
        heptagonObstacleInstantiate.GetComponent<MeshRenderer>().material = newMaterial;
        position.y++;
        rotation.eulerAngles += new Vector3(0, 5, 0);
      }
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
      hitCount++;
      
      transform.position -= new Vector3(0, 1, 0);
      
      transform.DOScaleX(1.15f, 0.2f).SetEase(Ease.OutBack).OnComplete(() => 
        transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InBack));
      transform.DOScaleZ(1.15f, 0.2f).SetEase(Ease.OutBack).OnComplete(() => 
        transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InBack));

      if (hitCount < floorCount)
      {
        obstacleFactoryManagerMediator.OnHitObstacle(position);
        return;
      }
      
      obstacleFactoryManagerMediator.ObstacleDestroyed(floorCount, objectPosition);
      gameObject.SetActive(false);
    }
  }
}