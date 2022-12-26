using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScene : MonoBehaviour
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
                PlayAgain();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitGame();
            }
        }

        public void PlayAgain()
        {
            Data.SetLevel(0);
            Data.SetScore(0);
            Data.SetLives(3);
            Data.SetCZombies(5);
            SceneManager.LoadScene("GameplayScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    
}
