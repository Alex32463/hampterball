using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    Animator animator;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        // If the animation is playing reset the animation (name: "Armature|ArmatureAction")
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
        {
            animator.ResetTrigger("Hit"); // Resets animation trigget, so that it doesn't play animation twice \\
        }
        // Checks if animation is playing or not
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("New State"))
        {
            // (then) if the animation is not playing generate a random time to play the animation and generate a random time
            if (Time.time > nextActionTime)
            {
                nextActionTime += period; // Adds the random time for the next time this animation plays \\
                period = Random.Range(1, 5); // Random time to play the animation \\

                // if the animation is not playing
                if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
                {
                    animator.SetTrigger("Hit"); // Starts the animation \\
                    audioSource.Play(); // Plays the SFX from the flipper \\
                }
                
            }
        }
    }
}
