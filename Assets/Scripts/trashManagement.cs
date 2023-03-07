using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashManagement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector2 currentFlowDir;
        public Vector2 CurrentFlowDir
        {
            get
            {
                return currentFlowDir;
            }
            set
            {
                currentFlowDir = value;
            }
        }

        private float currentFlowForce;
        public float CurrentFlowForce
        {
            get
            {
                return currentFlowForce;
            }
            set
            {
                currentFlowForce = value;
            }
        }
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

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObj = collider.gameObject;
        Debug.Log("Triggered with: " + otherObj);
    }


    public void updateEnterCurrent() {
        this.CurrentFlowDir.set(Vector2 (0,8));
        this.CurrentFlowForce.set(1.5f);
    }


    public void updateExitCurrent() {
        this.CurrentFlowDir.set(Vector2 (0,0));
        this.CurrentFlowForce.set(0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
