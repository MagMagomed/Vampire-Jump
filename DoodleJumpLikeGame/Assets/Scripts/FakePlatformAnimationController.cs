using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatformAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void StartDestroy()
    {
        if (animator != null)
        {
            animator.SetTrigger("Destroy");
        }
    }
}
