using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void StartJumpAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("JumpTrigger");
        }
    }
    public void StartFallAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("FallTrigger");
        }
    }
    public void StartLandingAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("isFalling", false);
        }
    }
    public void StartDieAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("DieTrigger");
        }
    }
}
