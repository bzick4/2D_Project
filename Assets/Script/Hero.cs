using System;
using System.Collections;
using System.Collections.Generic;
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
        Attack();
        Block();
        //Jump();
        MoveHero();
        Sitdown();
    }
    
    private void MoveHero()
    {
        input.x = Input.GetAxis("Horizontal");
        transform.position += input * _speed * Time.deltaTime;
        isMove = input.x != 0 ? true : false;
        
        if (isMove)
        {
            _heroSprite.flipX = input.x < 0;
            _heroAnimation.SetBool("isWalk", true);
            Debug.Log("walk");   
        }
        else
        {
            _heroAnimation.SetBool("isWalk", false);
        }
        
        if (isMove && Input.GetKey(KeyCode.RightShift))
        {
            _speed = _runSpeed;
            _heroAnimation.SetBool("isRun", true);
            Debug.Log("run");
        }
        else if(isMove && Input.GetKeyUp(KeyCode.RightShift))
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
