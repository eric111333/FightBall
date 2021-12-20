using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]GameObject ball;
    [SerializeField]GameObject door;
    [SerializeField] GameObject ballone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InstantiateBall()
    {
        Instantiate(ballone, door.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Ball")
            ball.transform.position = door.transform.position;
        if (collision.tag == "Ballone")
            Destroy(collision);
    }
}
