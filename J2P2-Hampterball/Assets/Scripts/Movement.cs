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
        var moveVertical = Mathf.Clamp(Input.acceleration.y + 0.7f, -0.4f, 0.3f);
        print(moveVertical);
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.AddForce(movement * speed * 6);
    }

    public static explicit operator GameObject(Movement v)
    {
        throw new NotImplementedException();
    }
}