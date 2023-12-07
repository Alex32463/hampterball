using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ManageHamster : MonoBehaviour
{
    //Placed on the head of hampster
    int index;

    //list for the Rigidbodies of all the bodyparts
    [SerializeField] Rigidbody[] bodypartsRb;
    //List for the transforms of all the bodyparts
    [SerializeField] Transform[] bodyparts;

    //list for all the saved locations of the bodyparts
    [SerializeField] public List<Vector3> bodypartTransform;

    //list for all the saved rotations of the bodyparts
    [SerializeField] public List<quaternion> bodypartRotation;

    //distance between the bodyparts and insideball.position
    [SerializeField] float distance;


    //[serializefield] Transform hamsterlocation;
    [SerializeField] Transform insideball;

    // Start is called before the first frame update
    void Start()
    {

        index = 0;

        //Saves the location of all the Bodyparts so the can be re-assigned in case of the hampster falling out of the ball
        foreach (Transform t in bodyparts)
        {
            bodypartTransform.Add(t.localPosition);
        }

        //Saves the Rotation of all the Bodyparts so the can be re-assigned in case of the hampster falling out of the ball
        foreach (Transform t in bodyparts)
        {
            bodypartRotation.Add(t.localRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //checks the distance between every bodypart and the middle and saves it in distance
        foreach (Transform t in bodyparts)
        {
            distance = Vector3.Distance(t.position, insideball.position);
        }


        //if the distance between insideball.position is greater or equal to 3
        if (distance >= 3)
        {
            //hamster object gets placed inside the ball again
            transform.position = insideball.position;

            foreach (Transform t in bodyparts)
            {
                {
                    foreach (Rigidbody rb in bodypartsRb)
                    {
                        //Turns of gravity so the hampster ball doesn't immediatly fly out of the ball again when transported / teleported to the middle.
                        rb.useGravity = false;
                        rb.isKinematic = true;

                    }
                    //resets the position of every bodypart with the saved values in the bodypartsTransform List
                    t.localPosition = bodypartTransform[index];
                    //resets the position of every bodypart with the saved values in the bodypartsRotations List
                    t.localRotation = bodypartRotation[index];
                    //increases the index
                    index++;
                }
            }
            index = 0;
            foreach (Rigidbody rb in bodypartsRb)
            {
                //resets the gravity and kinematic to their default values so the ragdoll works as intended again
                rb.useGravity = true;
                rb.isKinematic = false;
            }
        }
    }
}
