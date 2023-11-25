using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{
    [SerializeField] Transform ball;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ball.transform.position = transform.position;
        ball.transform.rotation = transform.rotation;
    }
}
