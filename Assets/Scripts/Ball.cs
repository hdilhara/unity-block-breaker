using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // initial values
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip PaddleHitAudio;
    [Range(1,100)][SerializeField] int speed = 35;

    //states
    Vector2 initialPadelBallGapVector2;
    bool gameHasStarted = false;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        initialPadelBallGapVector2 = transform.position - paddle1.transform.position;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if (!gameHasStarted)
            stickBallToPaddle();
       if (Input.GetMouseButtonDown(0) && !gameHasStarted)
            releaseTheBall();

    }

    private void stickBallToPaddle()
    {
        Vector2 padelPostionVector2 = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = padelPostionVector2 + initialPadelBallGapVector2;
    }

    private void releaseTheBall()
    {
        float speedCom = (speed / 2);
        GetComponent<Rigidbody2D>().velocity = new Vector2(speedCom, speedCom);
        gameHasStarted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //play sound 
        if(gameHasStarted && collision.gameObject.name.Equals("Paddle"))
        {
            audioSource.clip = PaddleHitAudio ;
            audioSource.PlayOneShot(PaddleHitAudio);
        }
    }


}
