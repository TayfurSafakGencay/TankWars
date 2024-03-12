﻿using System.Collections.Generic;
using Contexts.Main.View.Obstacle.Obstacle.ObstacleFactoryManager;
using DG.Tweening;
using UnityEngine;

namespace Contexts.Main.View.Obstacle.Obstacle.ObstacleTypes
{
  public class OctagonObstacle : MonoBehaviour, IObstacle
  {
    [SerializeField]
    private GameObject octagonObstacle;
    
    [SerializeField]
    private Material materialPrefab;

    private List<Color> colorSet;

    private ObstacleFactoryManagerMediator obstacleFactoryManagerMediator;
    
    private int floorCount;

    private int hitCount;
    
    public void Initialize()
    {
      obstacleFactoryManagerMediator = transform.parent.parent.GetComponent<ObstacleFactoryManagerMediator>();
      colorSet = obstacleFactoryManagerMediator.GetColorSet();
      
      floorCount = Random.Range(5, 10);
      Vector3 position = new(0, 0, 0);
      Quaternion rotation = new(0, 0, 0, 0);
      
      for (int i = 0; i < floorCount; i++)
      {
        Material newMaterial = CreateMaterial(i);
        GameObject octagonObstacleInstantiate = Instantiate(octagonObstacle, position, rotation, transform);
        octagonObstacleInstantiate.transform.localPosition = position;
        octagonObstacleInstantiate.GetComponent<MeshRenderer>().material = newMaterial;
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
    
    public void OnHitProjectile()
    {
      hitCount++;

      transform.position -= new Vector3(0, 1, 0);
      
      transform.DOScaleX(1.15f, 0.2f).SetEase(Ease.OutBack).OnComplete(() => 
        transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InBack));
      transform.DOScaleZ(1.15f, 0.2f).SetEase(Ease.OutBack).OnComplete(() => 
        transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InBack));

      if (hitCount < floorCount) return;
      
      obstacleFactoryManagerMediator.ObstacleDestroyed(floorCount);
      gameObject.SetActive(false);
    }
  }
}