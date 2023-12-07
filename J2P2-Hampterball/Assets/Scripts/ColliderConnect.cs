using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderConnect : MonoBehaviour
{
    [SerializeField] private Collider collider;
    // Update is called once per frame
    void FixedUpdate()
    {
        //The collider position is the same as the hamsterball to prevent the collider affecting the direction of the hamsterball
        collider.transform.position = transform.position;
        //The collider rotation is the same as the hamsterball to prevent the collider affecting the direction of the hamsterball
        collider.transform.rotation = transform.rotation;
    }
}
