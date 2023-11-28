using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    Animator animator;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {   
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
        {
            animator.ResetTrigger("Hit");
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("New State"))
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                // Random time to play the animation
                period = Random.Range(1, 5);

                animator.SetTrigger("Hit");
            }
        }
    }
}
