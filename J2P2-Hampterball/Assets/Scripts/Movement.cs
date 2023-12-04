using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    float speed = 2;
    public Rigidbody rb;
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        var moveHorizontal = Input.acceleration.x;
        var moveVertical = Input.acceleration.y;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed * 3);
    }

    public static explicit operator GameObject(Movement v)
    {
        throw new NotImplementedException();
    }
}