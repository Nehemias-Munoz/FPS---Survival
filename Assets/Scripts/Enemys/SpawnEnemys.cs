using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    private GameObject[] spawnPoints;
    [SerializeField] private Transform poolParent;
    [SerializeField] private int poolSizeMin = 10;
    [SerializeField] private int poolSizeMax = 20;
    private List<GameObject> pool;
    private int currentEnemyIndex;

    private void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SP");
        pool = new List<GameObject>(poolSizeMin);
        PopullatePool(poolSizeMin);
        currentEnemyIndex = 0;
        StartCoroutine(GenerateNewEnemy(poolSizeMin));

    }

    private void PopullatePool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            var enemy = Instantiate(enemiesPrefab[0], GetRandomPoint());
            enemy.SetActive(false);
            pool.Add(enemy);
        }
    }


    IEnumerator GenerateNewEnemy(int size)
    {
        for (int i = 0; i < size; i++)
        {
            var enemy = pool[currentEnemyIndex];
            currentEnemyIndex = currentEnemyIndex + 1 >= pool.Count ? 0 : currentEnemyIndex++;
            enemy.SetActive(true);
            yield return new WaitForSeconds(Random.Range(1, 10));
        }
    }
    
    Transform GetRandomPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
    }
}
