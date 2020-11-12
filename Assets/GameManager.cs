using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lockOrder = 5;

    public float movementSpeed = 0.1f;
    public float movementMagnitude = 1.0f;
    public float heightMagnitude = 1.0f;

    public List<int> levelGoalsList = new List<int>() { 5, 10, 15 };

    private BlocksGenerator blocksGenerator;
    private GameObject mainCamera;
    private InterfaceManager interfaceManager;
    private float upStep;

    public void Start()
    {
        if (GlobalVariables.currentLevel - 1 >= levelGoalsList.Count)
        {
            interfaceManager.showTotalVictory();
        }
        GlobalVariables.levelGoal = levelGoalsList[GlobalVariables.currentLevel - 1];

        blocksGenerator = GameObject.FindGameObjectWithTag("generator").GetComponent<BlocksGenerator>();
        interfaceManager = GameObject.FindGameObjectWithTag("ui").GetComponent<InterfaceManager>();
        mainCamera = Camera.main.gameObject;

        float blockSize = blocksGenerator.blocks[0].transform.localScale.y;
        upStep = blockSize;
         
        blocksGenerator.gameObject.SetActive(true);
        blocksGenerator.StartGame();
    }

    private void RaiseUp()
    {
        blocksGenerator.transform.position += Vector3.up * upStep;
        blocksGenerator.y0 += upStep;
        mainCamera.transform.position += Vector3.up * upStep;
    }

    public void OnBlockFall()
    {
        GlobalVariables.score += 1;
        interfaceManager.UpdateScore();
        if (GlobalVariables.score >= GlobalVariables.levelGoal)
        {
            blocksGenerator.gameObject.SetActive(false);
            interfaceManager.showVictory();
        }
        blocksGenerator.NextBlock();
        RaiseUp();
    }

    public void OnTowerFall()
    {
        int previousLevel = GlobalVariables.currentLevel - 2;
        if (previousLevel < 0)
        {
            GlobalVariables.score = 0;
        }
        else
        {
            GlobalVariables.score = levelGoalsList[previousLevel];
        }
        blocksGenerator.gameObject.SetActive(false);
        interfaceManager.GameOver();
    }
}
