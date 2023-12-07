using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ManageHamster : MonoBehaviour
{
    //Placed on the head of hampster
    int index;

    [SerializeField] Rigidbody[] bodypartsRb;
    [SerializeField] Transform[] bodyparts;
    [SerializeField] public List<Vector3> bodypartTransform;
    [SerializeField] public List<quaternion> bodypartRotation;

    [SerializeField] float distance;
    //[serializefield] Transform hamsterlocation;
    [SerializeField] Transform insideball;

    // Start is called before the first frame update
    void Start()
    {

        index = 0;

        foreach (Transform t in bodyparts)
        {
            bodypartTransform.Add(t.localPosition);
        }

        foreach (Transform t in bodyparts)
        {
            bodypartRotation.Add(t.localRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform t in bodyparts)
        {
            distance = Vector3.Distance(t.position, insideball.position);
            Debug.Log(distance);
        }


        Debug.Log(insideball.position);

        if (distance >= 3)
        {

            transform.position = insideball.position;
            
            foreach (Transform t in bodyparts)
            {
                {
                    foreach (Rigidbody rb in bodypartsRb)
                    {
                        rb.useGravity = false;
                        rb.isKinematic = true;

                    }
                    t.localPosition = bodypartTransform[index];
                    t.localRotation = bodypartRotation[index];
                    index++;
                }
            }
            index = 0;
            foreach (Rigidbody rb in bodypartsRb)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }
        }
    }
}
