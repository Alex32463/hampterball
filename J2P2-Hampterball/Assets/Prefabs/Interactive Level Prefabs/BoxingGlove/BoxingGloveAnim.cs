using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxingGloveAnimation : MonoBehaviour
{
    Animator animator;
    RaycastHit hit;
    [SerializeField] LayerMask hitMask;

    [SerializeField] GameObject animatorGameObject;
    [SerializeField] AudioSource audioSource;

    bool soundPlayed = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // SFX van de Boxing glove pakken \\
        animator = animatorGameObject.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        // Creates the raycast
        Physics.Raycast(transform.position, transform.forward, out hit, 3.2f * 3, hitMask);

        // Raycast checking if a player is hit
        if (hit.collider != null) 
        {
            animator.SetTrigger("raycast");
        }
        // If the animation is playing reset the trigger (name: "raycast")
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction"))
        {
            animator.ResetTrigger("raycast"); // Resets animation trigget, so that it doesn't play animation twice \\
        }
        // If the animation is playing and the sound isn't played
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Armature|ArmatureAction") && soundPlayed == false)
        {
            audioSource.Play(); // Plays boxing glove SFX \\
            soundPlayed = true; // Sound is player so set it to true \\
        }
        // if the Animtion is NOT playing and the sound is played
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("New State") && soundPlayed == true)
        {
            soundPlayed = false;
        }
    }
}
