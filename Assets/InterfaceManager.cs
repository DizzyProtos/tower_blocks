using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public Text scoreText;
    public Text finalScoreText;
    public Text levelNumberText;
    public GameObject GameOverMenu;
    public string mainMenuScenePath;
    public string victoryScenePath;
    private string finalScoreMessage;

    public void Start()
    {
        GameOverMenu.SetActive(false);
        finalScoreMessage = finalScoreText.text;
        levelNumberText.text = GlobalVariables.currentLevel.ToString();
        UpdateScore();
    }
    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        finalScoreText.text = finalScoreMessage + " " + GlobalVariables.score.ToString();
    }
    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScenePath);
    }
    public void UpdateScore()
    {
        scoreText.text = GlobalVariables.score.ToString() + "/" + GlobalVariables.levelGoal.ToString();
    }
    public void showVictory()
    {
        SceneManager.LoadScene(victoryScenePath);
    }
    public void showTotalVictory()
    {
        GlobalVariables.isGameWon = true;
        SceneManager.LoadScene(victoryScenePath);
    }
}
