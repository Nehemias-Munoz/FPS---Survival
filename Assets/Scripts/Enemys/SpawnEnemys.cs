using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    private GameObject[] spawnPoints;
    [SerializeField] private int numberOfEnemies;

    private void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SP");
    }

    private void Start()
    {
        StartCoroutine(GenerateNewEnemy());
    }


    IEnumerator GenerateNewEnemy()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemiesPrefab[0], GetRandomPoint());
            yield return new WaitForSeconds(Random.Range(1, 10));
        }
    }
    
    Transform GetRandomPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
    }
}
