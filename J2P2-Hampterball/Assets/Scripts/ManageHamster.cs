using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ManageHamster : MonoBehaviour
{
    //Placed on the head of hampster
    int index;

    [SerializeField] Rigidbody[] bodypartsRb;
    Transform[] bodyparts;
    [SerializeField] public List<Vector3> bodypartTransform;
    [SerializeField] public List<quaternion> bodypartRotation;

    [SerializeField] float distance;
    //[serializefield] Transform hamsterlocation;
    Vector3 insideball;

    // Start is called before the first frame update
    void Start()
    {

        index = 0;
        bodyparts = GetComponentsInChildren<Transform>();
        bodypartsRb = GetComponentsInChildren<Rigidbody>();
        insideball = new Vector3(0.0f, -0.0015f, 0.0f);
        transform.position = insideball;

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

        distance = Vector3.Distance(transform.position, insideball);
        Debug.Log(distance);

        if (distance >= 3)
        {


            foreach (Transform t in bodyparts)
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
            index = 0;
            foreach (Rigidbody rb in bodypartsRb)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
            }
        }
    }
}
