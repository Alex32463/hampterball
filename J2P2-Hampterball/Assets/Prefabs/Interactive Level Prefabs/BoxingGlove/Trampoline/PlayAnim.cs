using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayAnim : MonoBehaviour
{
    private Animator animator;
    public bool pressedE;

    [SerializeField] public Movement playerMovement; // Gets PlayerMovent script.
    [SerializeField] private float bounceHeight;
 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Checks if the player is collided with the collider of the bouncepad.
    void OnTriggerStay(Collider collision)
    {
        // (THEN) If the playes is collided with the collider of the bouncepad.
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("E");
            pressedE = true;
        }
        // If pressed is true it adds force so the player shoots up with the bouncepad.
        if (pressedE == true)
        {
            playerMovement.rb.AddForce(transform.up * bounceHeight);
        }
        // Checks if the animation is playing. if it does reset the trigger called "E".
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
        {
            pressedE = false;
            animator.ResetTrigger("E");
        }
    }
}
