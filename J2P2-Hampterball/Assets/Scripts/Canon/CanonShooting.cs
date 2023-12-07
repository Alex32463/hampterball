using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShooting : MonoBehaviour
{
    [SerializeField] Vector3 ballDirection;

    Animator canon;
    CanonInrange canonInrange;
    [SerializeField] Transform canonEntrance;
    GameObject destination;

    [SerializeField] ParticleSystem fuseParticles;
    [SerializeField] ParticleSystem smokeParticles;

    GameObject hamsterBall;
    Rigidbody hamsterBallRb;
    // Start is called before the first frame update
    void Start()
    {
        //Script CanonInrange
        canonInrange = gameObject.GetComponent<CanonInrange>();

        //Canon Animation
        canon = gameObject.GetComponent<Animator>();

        //HamsterBall
        hamsterBall = GameObject.FindWithTag("Player");
          
        //HamsterBall Rigidbody
        hamsterBallRb = hamsterBall.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the CanonInrange Script returns the inRange variable true 
        if (canonInrange.inRange == true)
        {  
            //hamsterballs position is set equal to the canons entrance so the shooting animation can play out
            hamsterBall.transform.position = canonEntrance.transform.position;
            //the rotation gets frozen to prevent complications during addforce method
            hamsterBallRb.freezeRotation = true;
            hamsterBall.transform.eulerAngles = new Vector3 (0.0f, 0.0f, 0.0f);
            //The inRange variable gets reset so the script can run again if needed 
            canonInrange.inRange = false;
            //animation gets played
            canon.SetTrigger("E");
            //fuseParticles get played 
            fuseParticles.Play();

            //starts the coroutine of 3 seconds
            StartCoroutine(Shooting());
        }  
    }

    IEnumerator Shooting()
    {
        //sets a timer for 3 seconds until the script to play 
        yield return new WaitForSeconds(3);
        //SmokeParticles play after the hamsterball gets shot
        smokeParticles.Play();
        //Addforce shoots the ball out of the canon
        hamsterBallRb.AddForce(ballDirection);
        hamsterBallRb.freezeRotation = false;
    }
}
