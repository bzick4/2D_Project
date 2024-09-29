using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed,_runSpeed, _jumpForce;
    [SerializeField] private SpriteRenderer _heroSprite;

    private Rigidbody2D _samurai;
    private Animator _heroAnimation;

    private Vector3 input;
    private bool isMove;

    private int _speedWalk = 2;

    public bool isGrounded;
    
    private void Start()
    {
        _samurai = GetComponent<Rigidbody2D>();
        _heroAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        Animation(input.x);
        Attack();
        Block();
        //Jump();
        MoveHero();
        Sitdown();
        Run();
    }
    
    private void MoveHero()
    {
        input.x = Input.GetAxis("Horizontal");
        
        _samurai.velocity = new Vector2(input.x * _speed, _samurai.velocity.y);

        if (!isMove && input.x < 0 || isMove && input.x >0)
        {
            Flip();
        }
    }

    private void Animation(float input)
    {
        _heroAnimation.SetBool("isWalk", Mathf.Abs(input) > 0.1f);
    }
    
    private void Flip()
    {
        isMove = !isMove;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Run()
    {
        if (isMove && Input.GetKey(KeyCode.RightShift) || !isMove && Input.GetKey(KeyCode.RightShift))
        {
            _speed = _runSpeed;
            _heroAnimation.SetBool("isRun", true);
            Debug.Log("run");
        }
        else if(isMove && Input.GetKeyUp(KeyCode.RightShift) || !isMove && Input.GetKeyUp(KeyCode.RightShift))
        {
            _speed = _speedWalk;
            _heroAnimation.SetBool("isRun", false);
            _heroAnimation.SetBool("isWalk", true);
        } 
    }
    
    // private void Jump()
    // {
    //     if (Input.GetKey(KeyCode.UpArrow) && Mathf.Abs(_samurai.velocity.y) <0.05f)
    //     { 
    //         _samurai.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse); 
    //         _heroAnimation.SetBool("isJump", true); 
    //         Debug.Log("jump");
    //     }
    //     if (Input.GetKeyUp(KeyCode.UpArrow))
    //     {
    //         _heroAnimation.SetBool("isJump" ,false);
    //         _heroAnimation.SetBool("isFall",true);
    //         Debug.Log("fall");
    //     }
    // }

    // private void Fall() 
    //     { 
    //         if (_samurai.velocity.y < 0)
    //         { 
    //             _heroAnimation.SetBool("isJump" ,false);
    //             _heroAnimation.SetBool("isFall",true);
    //             Debug.Log("fall");
    //         } 
    //     }

    private void Sitdown()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Mathf.Abs(_samurai.velocity.y) < 0.05f)
        {
            _heroAnimation.SetBool("isSitdown", true);
            Debug.Log("sitdown");
        }
        else
        {
            _heroAnimation.SetBool("isSitdown", false);
        }
    }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _heroAnimation.SetBool("isAttack",true);
            Debug.Log("Attack");
        }
        else
        {
            _heroAnimation.SetBool("isAttack",false);
        }
        
    }

    private void Block()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _heroAnimation.SetBool("isBlock",true);
            Debug.Log("block");
        }
        else
        {
            _heroAnimation.SetBool("isBlock",false);
        }
    }
}
