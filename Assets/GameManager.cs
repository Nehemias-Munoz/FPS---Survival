using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private GameObject ammoPrefab;
    private GameObject[] ammoSpawnPoints;
    public int gunAmmo;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ammoSpawnPoints = GameObject.FindGameObjectsWithTag("DP");
        GenerateAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = gunAmmo.ToString();
    }

    void GenerateAmmo()
    {
        for (int i = 0; i < ammoSpawnPoints.Length; i++)
        {
            Instantiate(ammoPrefab, ammoSpawnPoints[i].transform);
        }
    }
}
