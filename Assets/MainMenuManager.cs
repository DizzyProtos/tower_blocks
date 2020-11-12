using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string startScenePath = "GameScene";
    public void StartGame()
    {
        SceneManager.LoadScene(startScenePath);
    }
    public void NewGame()
    {
        GlobalVariables.currentLevel = 1;
        SceneManager.LoadScene(startScenePath);
    }
}
