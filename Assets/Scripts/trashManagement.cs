using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashManagement : MonoBehaviour
{
    // Start is called before the first frame update
    

    void Start()
    {

    }
    //Make a log of the collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObj = collider.gameObject;
        Debug.Log("Triggered with: " + otherObj);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
