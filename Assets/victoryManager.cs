using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class victoryManager : MonoBehaviour
{
    public Text victoryText;
    public GameObject nextLevelButton;
    public string gameScenePath;
    public string mainMenuScenePath;
    public string levelBeatenMessage = "Level is Done!";
    public string gameBeatenMessage = "Game is Beaten!";

    public void Start()
    {
        if (GlobalVariables.isGameWon)
        {
            nextLevelButton.SetActive(false);
            victoryText.text = gameBeatenMessage;
        }
        else
        {
            victoryText.text = levelBeatenMessage;
        }
    }
    public void nextLevel()
    {
        GlobalVariables.currentLevel += 1;
        SceneManager.LoadScene(gameScenePath);
    }
    public void toMainMenu()
    {
        SceneManager.LoadScene(mainMenuScenePath);
    }
}

