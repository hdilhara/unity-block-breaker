using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // Unity Units
    [SerializeField] float screenWidthInUnityWorldUnits = 21.222f;
    [SerializeField] float minX = 1.42f;
    [SerializeField] float maxX = 19.91f;

    float posX,posY;
    bool autoPlay;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        autoPlay = FindObjectOfType<GameSession>().isAutoPlayEnabled();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
      /*  float paddleXposition = (Input.mousePosition.x / Screen.width) * screenWidthInUnityWorldUnits;
        paddleXposition = Mathf.Clamp(paddleXposition, minX, maxX);
        padlePosition = new Vector2(paddleXposition, transform.position.y);*/
       this.transform.position = new Vector2(Mathf.Clamp(getPadelXposition(), minX, maxX), posY); ;
    }
    private float getPadelXposition()
    {
        if (!autoPlay)
        {
            Vector2 padlePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return padlePosition.x;
        }
        else
        {
            return ball.transform.position.x;
        }
    }

}
