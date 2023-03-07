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

        otherObj.updateEnterCurrent();

        otherObj.GetComponent<Rigidbody>().AddForce(otherObj.CurrentFlowDirection * otherObj.CurrentFlowForce);

        
        Debug.Log("Velocity ++" + rb.velocity);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        GameObject otherObj = collider.gameObject;
        
        otherObj.updateExitCurrent();
        otherObj.GetComponent<Rigidbody>().AddForce(otherObj.CurrentFlowDirection * otherObj.CurrentFlowForce);
        

        Debug.Log("Velocity --" + rb.velocity);
    }
    // Update is called once per frame
    void Update()
    {
    }

}
