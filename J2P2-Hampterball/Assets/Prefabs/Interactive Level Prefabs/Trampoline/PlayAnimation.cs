using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayAnimation : MonoBehaviour
{
    private Animator animator;
    public bool pressedE;

    private Movement playerMovement;
    private float bounceHeight = 200;
 

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = FindObjectOfType<Movement>(); // Gets PlayerMovent script \\
    }

    // Checks if the playes is collided with the collider of the bouncepad
    void OnTriggerStay(Collider collision)
    {
        // (THEN) If the playes is collided with the collider of the bouncepad AND the animation is not playing
        if (collision.CompareTag("Player") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
        {
            animator.SetTrigger("E"); // Starts the animation \\
            pressedE = true;
        }
        if (pressedE == true)
        {
            playerMovement.rb.AddForce(transform.up * bounceHeight); // adds force to the player in the playerMovement script to the ridgitbody \\
        }
        // If the animation is playing reset the animation (name: "Armature|ArmatureAction")
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
        {
            animator.ResetTrigger("E"); // Resets animation trigget, so that it doesn't play animation twice \\
        }
    }
    // If you leave the trampoline collision it plays the contents
    private void OnTriggerExit(Collider collision)
    {
        // Checks if the playes is collided with the collider of the bouncepad or not
        if (collision.CompareTag("Player"))
        {
            pressedE = false; 
        }
    }
}
