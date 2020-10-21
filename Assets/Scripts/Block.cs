using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip blockHitAudio;
    [SerializeField] GameObject particalVFX;
    [SerializeField] int hitCountForBreak = 0;
    [SerializeField] Sprite[] damageSprites;

    Level level;
    [SerializeField] int hitCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (tag == "breakable")
        {
            level = GameObject.FindObjectOfType<Level>();
            level.countAsBlock();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            playSoundEfect();
            if (tag == "breakable")
            {
                if (hitCountForBreak <= hitCount + 1)
                {
                    destroryBlock();
                }
                else
                {
                    renderNextDamageSprite(hitCount);
                    hitCount++;
                }
            }

        }
    }

    private void renderNextDamageSprite(int spriteIndex){
        if(damageSprites[spriteIndex] != null )
             GetComponent<SpriteRenderer>().sprite = damageSprites[hitCount];
    }

    private void destroryBlock()
    {
        level.removedBlock();
        Destroy(Instantiate(particalVFX, transform.position, transform.rotation),2);
        Destroy(gameObject);
    }

    private void playSoundEfect()
    {
        AudioSource.PlayClipAtPoint(blockHitAudio, Camera.main.transform.position);
    }
}
