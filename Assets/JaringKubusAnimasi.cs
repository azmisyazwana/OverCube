using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaringKubusAnimasi : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;

    private void Awake() {
        animator =  GetComponent<Animator>();
    }

    private void Update() {
        if(animator != null){
            if (Input.GetKeyDown(KeyCode.O) && !isOpen)
            {
                animator.SetTrigger("TriggerOpen");
                isOpen = true;
            }

            if (Input.GetKeyDown(KeyCode.C) && isOpen)
            {
                animator.SetTrigger("TriggerClose");
                isOpen = false;
            }
        }
    }
}
