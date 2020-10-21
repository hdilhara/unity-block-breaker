using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    [SerializeField] int gameLevelCount;

    public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex >= gameLevelCount)
            SceneManager.LoadScene(currentSceneIndex + 1);
        else
            loadStartingScene();
    }

    public void tryAgain()
    {
        int index = FindObjectOfType<GameSession>().currentLevelBuildIndex;
        SceneManager.LoadScene(index);//sceneBuiltNumber);
    }

    public void loadStartingScene()
    {
        //session clear
        Destroy(FindObjectOfType<GameSession>());
        SceneManager.LoadScene(0);
    }

    public void quitGAme()
    {
        Application.Quit();
    }

    public void loadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

}
