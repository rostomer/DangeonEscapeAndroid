using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private SpriteRenderer _spriteRendererToFlip;

    [SerializeField]
    private Animator _sliceAnimator;

    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Flip(float movenentDirection)
    {
        Debug.Log("Movement Direction: " + movenentDirection);
        if (movenentDirection < 0)
        {
            _renderer.flipX = true;
            _spriteRendererToFlip.flipX = true;
        }
        else if (movenentDirection > 0)
        {
            _renderer.flipX = false;
            _spriteRendererToFlip.flipX = false;
        }
    }

    public void RunningAnimation()
    {
        if (_rigidbody2D.velocity.x != 0f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void JumpAnimation( bool isOnGround)
    {
        if(!isOnGround)
            anim.SetBool("Jumping", true);
        else if(isOnGround)      
            anim.SetBool("Jumping", false);        
    }

    public void IdleAttackAnimation()
    {
        if(!anim.GetBool("Jumping"))
        anim.SetTrigger("Attack");
    }

    public void SwordArcAnimation()
    {
        _sliceAnimator.SetTrigger("SwordAnimationTrigger");
    }
}
