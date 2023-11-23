using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float movementSpeed = 40000;
    public Transform orientation;
    private float horizontalInput;
    private float verticalInput;
    private float jumpDelay = 1f;
    private float lastTimeJumped;
    private Vector3 movementDirection;
    private void Start()
    {
        rb.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        lastTimeJumped = Time.time + jumpDelay;
    }
    private void Update()
    {
        MyInput();
        Jump();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void Movement()
    {
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(movementDirection * movementSpeed * 10f, ForceMode.Force);
    }
    private void Jump()
    {
        Debug.Log(Time.time);
        Debug.Log(lastTimeJumped + jumpDelay);
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > (lastTimeJumped + jumpDelay))
        {
            //Debug.Log("spring!!!");
            rb.AddForce(new Vector3(0, 250, 0));
            lastTimeJumped = Time.time;
        }
    }
}
