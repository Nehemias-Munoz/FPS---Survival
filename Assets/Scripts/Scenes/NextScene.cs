using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        // levelText.text = GameManager.Instance.level.ToString();
        livesText.text = Data.GetLives().ToString();
        scoreText.text = Data.GetScore().ToString();
        levelText.text = Data.GetLevel().ToString();
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void ChangeScene()
    {
        Data.SetLevel(Data.GetLevel()+1);
        Data.SetCZombies(Data.GetCzombies() + 5);
        SceneManager.LoadScene("GameplayScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
