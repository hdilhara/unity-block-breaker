using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingeltonExample : MonoBehaviour
{
    private void Awake()
    {
        int noOfInstances = FindObjectsOfType<SingeltonExample>().Length;
        if (noOfInstances > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
