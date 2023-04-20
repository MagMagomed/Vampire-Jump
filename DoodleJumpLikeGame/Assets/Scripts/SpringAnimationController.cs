using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void StartSpring()
    {
        if (animator != null)
        {
            animator.SetTrigger("Springy");
        }
    }
}
