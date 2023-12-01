using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayAnimation : MonoBehaviour
{
    private Animator animator;
    public bool pressedE;

    private Movement playerMovement; // Gets PlayerMovent script
    private float bounceHeight = 200;
 

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = FindObjectOfType<Movement>();
    }

    // Checks if the playes is collided with the collider of the bouncepad
    void OnTriggerStay(Collider collision)
    {
        // (THEN) If the playes is collided with the collider of the bouncepad
        if (collision.CompareTag("Player") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
        {
            animator.SetTrigger("E");
            pressedE = true;
        }
        if (pressedE == true)
        {
            playerMovement.rb.AddForce(transform.up * bounceHeight);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
        {
            animator.ResetTrigger("E");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        // Checks if the playes is NOT collided with the collider of the bouncepad
        if (collision.CompareTag("Player"))
        {
            pressedE = false;
        }
    }
}
