using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    //make this serizalize for debugging purposes...
    [SerializeField]int levelNumber;
    [SerializeField]public int levelBuildIndex;
    [SerializeField]int blockCount = 0;
    [SerializeField] TextMeshProUGUI scorePanel;

    GameStatus gameStatus;

    void Start()
    {
        gameStatus = GameObject.FindObjectOfType<GameStatus>();
        displayLevelScore();
    }

    public void countAsBlock()
    {
        blockCount++;
    }

    public void removedBlock()
    {
        blockCount--;
        gameStatus.countLevelScore();
        displayLevelScore();
        if (blockCount <= 0)
        {
            FindObjectOfType<GameLoose>().levelComplete();
            Invoke("levelComplete", 2);
        }
    }

    private void levelComplete()
    {
        GameObject.FindObjectOfType<SceneLoader>().loadNextScene();
    }

    public int getLevelNumber()
    {
        return levelNumber;
    }

    private void displayLevelScore()
    {
        scorePanel.text = gameStatus.getLevelScore().ToString();
    }

    public int getCurrentScore()
    {
       return  gameStatus.levelScore;
    }
}
