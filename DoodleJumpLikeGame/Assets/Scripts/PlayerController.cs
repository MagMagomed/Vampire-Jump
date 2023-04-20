using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AnimationController animationController;
    public AudioSource springSource;
    public AudioSource jumpSource;
    public AudioSource dieSource;
    [SerializeField] public float speed = 150f;
    [SerializeField] private float addForce = 7f;
    [SerializeField] private bool lookAtCursor;
    public float MaxJumpHeight { get; set; }
    private float AddForce { get { return addForce + CoinsCounterController.instance.GetCoinsCount(); } set { addForce = value; } }
    [SerializeField] public Rigidbody2D body;
    [SerializeField] private int maxHeight;
    public bool isFalling;
    public int MaxHeight { get { return maxHeight; } }

    public bool IsDie { get; internal set; }

    private void Start()
    {
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        MaxJumpHeight = (addForce / body.mass) * (addForce / body.mass) / (2f * 9.81f * body.gravityScale);
        Debug.Log($"PLAYER CONTROLLER \n\tSTART\n\t\t: MaxJumpHeight{MaxJumpHeight}");
    }
    public void Restart()
    {
        Start();
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        var direction = new Vector2(horizontal, 0f);
        body.AddForce(body.mass * speed * direction);

        UpdateMaxHeight();
        LimitTheVelocity();
    }

    private void UpdateMaxHeight()
    {
        maxHeight = Mathf.Max(maxHeight, (int)Math.Round(transform.position.y));
    }

    private void LimitTheVelocity()
    {
        var velocityAfterClamp = new Vector2(Mathf.Clamp(body.velocity.x, -speed / 100f, speed / 100f), body.velocity.y);
        body.velocity = velocityAfterClamp;
    }

    private void Update()
    {
        if(body.velocity.y < 0)
        {
            if (!isFalling)
            {
                isFalling = true;
                animationController.StartFallAnimation();
            }
        }
        if(body.velocity.y > 0)
        {
            isFalling = false;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
        else
        {
            body.velocity = new Vector2(0f, body.velocity.y);
        }
    }

    public void Jump(float multiplyJumpForce = 1f)
    {
        if (body.velocity.y != 0f)
        {
            body.velocity = new Vector2(body.velocity.x, 0f);
        }
        if(multiplyJumpForce > 1f)
        {
		    SoundVoluemController.instance.Play(springSource);
        }
        else
        {
            SoundVoluemController.instance.Play(jumpSource);
        }
        body.AddForce(Vector2.up * (AddForce* multiplyJumpForce), ForceMode2D.Impulse);
        animationController.StartJumpAnimation();
    }

    internal void Die()
    {
        IsDie = true;
        SoundVoluemController.instance.Play(dieSource);
        animationController.StartDieAnimation();
        body.velocity = Vector2.zero;
        body.angularVelocity = 0f;
        body.isKinematic = true;
    }
}