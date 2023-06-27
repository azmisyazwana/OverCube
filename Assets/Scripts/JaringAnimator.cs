using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaringAnimator : MonoBehaviour
{
    private const string IS_WALKING = "PlayNet";

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     animator.SetTrigger(IS_WALKING);
        // }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(IS_WALKING);
            // animator.enabled = true;
        }

        // if (animator.enabled && !animator.GetCurrentAnimatorStateInfo(0).loop)
        // {
        //     animator.enabled = false;
        // }
    }
}
