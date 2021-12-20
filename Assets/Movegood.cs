using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movegood : MonoBehaviour
{
    bool right;
    void Start()
    {
        right = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (right)
           this.transform.Translate(Vector3.right * 1f * Time.deltaTime, Space.World);
        else
        { 
            this.transform.Translate(Vector3.left * 1f * Time.deltaTime, Space.World);
        }
        if (transform.position.x < -1.75)
            right = true;
        if (transform.position.x > 1.75)
            right = false;
    }
}
