using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoose : MonoBehaviour
{
    bool isLevelComplete = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isLevelComplete)
        {
            Invoke("loadGameOverScene", 1);
        }
    }

    private void loadGameOverScene()
    {
        GameSession session = FindObjectOfType<GameSession>();
        Level level = FindObjectOfType<Level>();
        session.currentLevelBuildIndex = level.levelBuildIndex;
        session.currentScore = level.getCurrentScore();
        FindObjectOfType<SceneLoader>().loadGameOverScene();
    }

    public void levelComplete()
    {
        isLevelComplete = true;
    }

}
