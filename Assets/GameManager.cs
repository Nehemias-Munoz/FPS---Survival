using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private GameObject medPrefab;
    private GameObject[] ammoSpawnPoints;
    private GameObject[] spawnPoints;
    public int gunAmmo;
    public int playerLives;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ammoSpawnPoints = GameObject.FindGameObjectsWithTag("DP");
        spawnPoints = GameObject.FindGameObjectsWithTag("SP");
        GenerateAmmo();
        GenerateMed();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = gunAmmo.ToString();
        livesText.text = playerLives.ToString();
        
    }

    void GenerateAmmo()
    {
        for (int i = 0; i < ammoSpawnPoints.Length; i++)
        {
            Instantiate(ammoPrefab, ammoSpawnPoints[i].transform);
        }
    }

    void GenerateMed()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(ammoPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].transform);
        }
    }
}
