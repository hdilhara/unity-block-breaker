using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    float gameSpeed;
    int level;
    public int levelScore=0;

    [SerializeField] int scorePerBlock=5;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.FindObjectOfType<Level>().getLevelNumber();
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed = Time.timeScale;
    }

    public void plusLevelScore()
    {
        levelScore += scorePerBlock; 
    }

    public void countLevelScore()
    {
        levelScore += scorePerBlock;
    }
    public int getLevelScore()
    {
        return levelScore;
    }

    

}
