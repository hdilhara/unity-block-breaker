using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] bool autoPlay = false;

    public int currentLevelBuildIndex;
    public int currentScore;
  

    private void Awake()
    {
        int noOfObjects = FindObjectsOfType<GameSession>().Length;
        if(noOfObjects > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool isAutoPlayEnabled()
    {
        return autoPlay;
    }
    
}
