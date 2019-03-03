using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown("1"))
        {
            transform.localScale = new Vector3(Random.Range(0.2f, 10.0f), 1, Random.Range(0.2f, 10.0f));
            
        }

        if (Input.GetKeyDown("2"))
        {
            transform.localScale = new Vector3(Random.Range(-0.2f, -10.0f), -1, Random.Range(-0.2f, -10.0f));
        }
    }
}
