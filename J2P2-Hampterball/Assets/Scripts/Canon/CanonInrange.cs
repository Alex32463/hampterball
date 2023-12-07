using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonInrange : MonoBehaviour
{

    public bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Checks if the current collision Is with an object with the tag "Player"
        if(collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }
      
}
