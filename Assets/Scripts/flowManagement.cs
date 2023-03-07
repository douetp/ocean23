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
        rb = otherObj.GetComponent<Rigidbody2D>();
        
        Debug.Log("Velocity ++" + rb.velocity);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        GameObject otherObj = collider.gameObject;
        rb = otherObj.GetComponent<Rigidbody2D>();
        Vector2 vel = rb.velocity;
        rb.velocity = vel.normalized * 0.2f;
        Debug.Log("Velocity --" + rb.velocity);
    }
    // Update is called once per frame
    void Update()
    {
    }

}
