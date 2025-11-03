using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;
    private bool isGameOver = false;
    private bool isGameWin = false;

    void Start()
    {
        UpdateScoreUI();
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
    }


    public void AddScore(int points)
    {
        if (!isGameOver && !isGameWin){
            score += points;
            UpdateScoreUI();
        }
        
    }
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            score = 0;
            Time.timeScale = 0f;
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
            Debug.Log("Game Over! Final Score: " + score);
        }
    }
    public void GameWin()
    {
        if (!isGameWin)
        {
            isGameWin = true;
            Time.timeScale = 0f;
            if (gameWinPanel != null)
            {
                gameWinPanel.SetActive(true);
            }
        }
    }

    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScoreUI();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void loadMainMenu()
    {
        isGameOver = false;
        isGameOver = false;
        score = 0;
        UpdateScoreUI();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }

}
