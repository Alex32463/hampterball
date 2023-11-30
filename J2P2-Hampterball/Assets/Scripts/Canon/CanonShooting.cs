using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonShooting : MonoBehaviour
{

    [SerializeField] Vector3 ballDirection;

    Animator canon;
    CanonInrange canonInrange;
    GameObject canonEntrance;
    GameObject destination;

    [SerializeField] ParticleSystem fuseParticles;
    [SerializeField] ParticleSystem smokeParticles;


    GameObject hamsterBall;
    Rigidbody hamsterBallRb;
    // Start is called before the first frame update
    void Start()
    {
        //Script CanonInrange
        canonInrange = FindObjectOfType<CanonInrange>();

        //Canon Animation
        canon = GetComponent<Animator>();

        //Canon Entrance
        canonEntrance = GameObject.FindWithTag("EntranceCanon");

        //HamsterBall
        hamsterBall = GameObject.FindWithTag("HamsterBall");
          
        //HamsterBall Rigidbody
        hamsterBallRb = hamsterBall.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canonInrange.inRange == true)
        {
            
            hamsterBall.transform.position = canonEntrance.transform.position;
            hamsterBallRb.freezeRotation = true;
            hamsterBall.transform.eulerAngles = new Vector3 (0.0f, 0.0f, 0.0f);
            canonInrange.inRange = false;
            canon.SetTrigger("E");
            fuseParticles.Play();

            StartCoroutine(Shooting());
        }       
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Force");
        smokeParticles.Play();
        hamsterBallRb.AddForce(ballDirection);
    }
}
