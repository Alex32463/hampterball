using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxingGloveAnimation : MonoBehaviour
{
    Animator animator;
    Ray ray;
    RaycastHit hit;
    [SerializeField] LayerMask hitMask;

    [SerializeField] GameObject animatorGameObject;
    void Start()
    {
        animator = animatorGameObject.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        // Creates the raycast
        Physics.Raycast(transform.position, transform.forward, out hit, 3.2f, hitMask);

        // Raycast checking if a player is hit
        if (hit.collider != null)
        {
            animator.SetTrigger("raycast");
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
        {
            animator.ResetTrigger("raycast");
        }
    }
}
