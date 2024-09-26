using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed, _jumpForce;
    [SerializeField] private SpriteRenderer _heroSprite;

    private Rigidbody2D _samurai;
    private HeroAnimation _heroAnimation;

    private Vector3 input;
    private bool isMove, isJump, isFall;

    public bool isGround { get; private set; }
    
    private void Start()
    {
        _samurai = GetComponent<Rigidbody2D>();
        _heroAnimation = GetComponent<HeroAnimation>();
    }

    private void Update()
    {
        Jump();
        MoveHero();
        //Fall();
    }
    
    private void MoveHero()
    {
        input.x = Input.GetAxis("Horizontal");
        transform.position += input * _speed * Time.deltaTime;
        isMove = input.x != 0 ? true : false;
        
        if (isMove)
        {
            _heroSprite.flipX = input.x < 0;
        }
        _heroAnimation.isRun = isMove;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_samurai.velocity.y)<0.05f)
        {
            _samurai.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _heroAnimation.speed(_samurai.velocity.y);
        }
        
    }

    private void FallAnim()
    {
        float verticalSpeed = _samurai.velocity.y;
    }
    private void Fall() 
    { 
        if (_samurai.velocity.y > 0.05f) 
        { 
            _heroAnimation.isJump = false;
            _heroAnimation.isFall = isFall;
            Invoke("FallAnim", 0.1f);
        } 
    }
    
    

}
