using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayAnim : MonoBehaviour
{
    private Animator animator;
    public bool pressedE;

    [SerializeField] public Movement playerMovement; // Gets PlayerMovent script
    [SerializeField] private float bounceHeight;
 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Checks if the playes is collided with the collider of the bouncepad
    void OnTriggerStay(Collider collision)
    {
        // (THEN) If the playes is collided with the collider of the bouncepad
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("E");
            pressedE = true;
        }
        if (pressedE == true)
        {
            playerMovement.rb.AddForce(transform.up * bounceHeight);
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
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
