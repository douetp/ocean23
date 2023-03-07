using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerTrash : MonoBehaviour
{
   public int maxTrash = 50;
   public int currentTrash;
   public TrashBar trashBar;

    void Start()
    {
        currentTrash = 0;
        trashBar.setTrash(currentTrash);
        trashBar.setMaxTrash(maxTrash);
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj);
        Destroy(otherObj);
        currentTrash+=10;
        trashBar.setTrash(currentTrash);
    }
}
