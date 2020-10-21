using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField] Text gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        int score = FindObjectOfType<GameSession>().currentScore;
        gameOverText.text = score.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
