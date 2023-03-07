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
        trashBar.setMaxTrash(maxTrash);
                trashBar.setTrash(currentTrash);

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObj = collision.gameObject;
        if (otherObj.tag == "Trash")
        {
            Destroy(otherObj);
            currentTrash+=10;
            trashBar.setTrash(currentTrash);
        }else if(otherObj.tag == "Vaisseau"){
            //Launch cinematic
            
        }
    }
}
