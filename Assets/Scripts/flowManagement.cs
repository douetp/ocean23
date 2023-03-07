using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowManagement : MonoBehaviour
{
   public Rigidbody2D rb;

    void Start()
    {
        
    }
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObj = collider.gameObject;
        Debug.Log("Triggered with: " + otherObj);
        rb = otherObj.GetComponent<Rigidbody2D>();
        Vector3 vel = rb.velocity;
        rb.velocity = vel.normalized * 1.5f;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        GameObject otherObj = collider.gameObject;
        Debug.Log("Triggered with: " + otherObj);
        rb = otherObj.GetComponent<Rigidbody2D>();
        Vector3 vel = rb.velocity;
        rb.velocity = vel.normalized * 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
    }

}
